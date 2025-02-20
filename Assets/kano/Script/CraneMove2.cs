using System.Collections;
using UnityEngine;

public class CraneMove2 : MonoBehaviour
{
    [SerializeField]
    Vector3[] armSpeed = new Vector3[(int)State.ENUM_END];

    [SerializeField] private MagneticForceVariable magneticForceVariable;

    [SerializeField]
    TurnManager turnManager;

    [SerializeField] GameObject UFOanim;

    [SerializeField]
    bool IsHit = false;

    [SerializeField]
    private GameObject audioManager;

    private enum State{ 
     PUSH,       //�v���C���[�������^�[��
     MASHING,    //�A�Ń^�[��
     DOWN,       //�A�[����������
     WAIT,       //�A�[����~
     UP,         //�A�[�������グ
     LEFT,       //���ړ�
     RELEASE,    //����@
     RESET,      //�S�l������
     
     ENUM_END
    }
    private State state;

    float wait = 0.0f;

    private void Start()
    {
        state = State.PUSH;
        UFOanim.SetActive(false);


    }
    private void Update()
    {
        /*
         //fixed�ɂ���ꍇ
        bool isKeyDown, isKey, isKeyUp; 
        isKeyDown = Input.GetKeyDown(KeyCode.Space);
        isKey = Input.GetKey(KeyCode.Space);
        isKeyUp = Input.GetKeyUp(KeyCode.Space);
         */


        switch (state)
        {
            case State.PUSH:
                ArmCommand1();
                break;

            case State.MASHING:
                ArmCommand2();
                break;

            case State.DOWN:
                ArmCommand3();
                break;

            case State.WAIT:
                ArmCommand4();
                break;

            case State.UP:
                ArmCommand5();
                break;

            case State.LEFT:
                ArmCommand6();
                break;
            case State.RELEASE:
                ArmCommand7();
                break;

            case State.RESET:
                magneticForceVariable.ResetPushCount();
                magneticForceVariable.Reflection();
                turnManager.TurnCountDown();
                state = State.PUSH;
                break;

            default:
                Debug.Log("�Ȃ�����ĂȂ��̂ɂ���ꂽ");
                break;
        }
        // Debug.Log(state.ToString());
    }
    

    void ArmCommand1()
    {
        //if(isKey){
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("�Ăяo������");
            transform.position += armSpeed[(int)State.PUSH] *Time.deltaTime;
        }
        else if (Input.GetKeyUp(KeyCode.Space) || 8 <= transform.position.x)
        {
            wait = 2.0f;
            state++;
        }
    }

    void ArmCommand2()
    {
        Debug.Log("�Ăяo������");
        wait -= Time.deltaTime;

        if (0 < wait)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                //���͂𑝂₷����
                magneticForceVariable.GetKey();
            }
        }
        else if (transform.position.y <= 30 || wait <= 0)
        {
            IsHit = false;
            wait = 5.0f;
            // �~�����ʉ��Đ�
            audioManager.GetComponent<GameSceneAudioManager>().ArmDownSound();
            UFOanim.SetActive(true);
            state++;
        }
    }

    void ArmCommand3()
    {
        transform.position += armSpeed[(int)State.DOWN];
        if(IsHit)
        {
            // 1�b��ɍ~��SE��~
            StartCoroutine(StopSoundAfterHit(1.5f));
            state++;
            wait = 3.0f;
        }
    }

    void ArmCommand4()
    {
        wait -= Time.deltaTime;
        if(0 > wait)
        {
            // �㏸SE�Đ�
            audioManager.GetComponent<GameSceneAudioManager>().ArmUpSound();
            state++;
        }
    }

    void ArmCommand5()
    {
        transform.position += armSpeed[(int)State.UP];
        if(transform.position.y >= 3)
        {
            // �㏸SE��~
            audioManager.GetComponent<GameSceneAudioManager>().SoundStop();
            state++;
        }
    }
    
    void ArmCommand6()
    {
        transform.position += armSpeed[(int)State.LEFT];
        if(transform.position.x <= -6)
        {
            wait = 3;
            UFOanim.SetActive(false);
            state++;
        }
    }
    void ArmCommand7()
    {
        magneticForceVariable.MagneticOff();
        wait -= Time.deltaTime ;
        if (0 > wait)
        {
            state++;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        IsHit = true;
    }

    private IEnumerator StopSoundAfterHit(float waitSeconds)
    {
        yield return new WaitForSeconds(waitSeconds);
        audioManager.GetComponent<GameSceneAudioManager>().SoundStop();
    }
}
