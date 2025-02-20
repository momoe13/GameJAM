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
    [SerializeField] GameObject PushAnim;

    [SerializeField]
    bool IsHit = false;

    [SerializeField]
    private GameObject audioManager;

    [SerializeField]
    ButtonImageChangeManager ButtonImgChange;

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
        PushAnim.SetActive(false);

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
    }
    

    void ArmCommand1()
    {
        ButtonImgChange.SpriteChange(1);
        
        //if(isKey){
        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
        {
            ButtonImgChange.SpriteChange(2);
            transform.position += armSpeed[(int)State.PUSH] *Time.deltaTime;
        }
        else if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0) || 6.5 <= transform.position.x)
        {
            ButtonImgChange.SpriteChange(3);
            wait = 2.0f;
            PushAnim.SetActive(true);
            state++;
        }
    }

    void ArmCommand2()
    {
        wait -= Time.deltaTime;

        if (0 < wait)
        {
            if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                //���͂𑝂₷����
                magneticForceVariable.GetKey();
            }
        }
        else if (transform.position.y <= 30 || wait <= 0)
        {
            PushAnim.SetActive(false);
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
        transform.position += armSpeed[(int)State.DOWN] * Time.deltaTime;
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
        transform.position += armSpeed[(int)State.UP] * Time.deltaTime;
        if(transform.position.y >= 3)
        {
            // �㏸SE��~
            audioManager.GetComponent<GameSceneAudioManager>().SoundStop();
            state++;
        }
    }
    
    void ArmCommand6()
    {
        transform.position += armSpeed[(int)State.LEFT] * Time.deltaTime;
        if(transform.position.x <= -6)
        {
            wait = 2;
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
