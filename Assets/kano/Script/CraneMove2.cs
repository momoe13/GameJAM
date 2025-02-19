using System.Collections;
using UnityEngine;

public class CraneMove2 : MonoBehaviour
{
    [SerializeField]
    Vector3[] armSpeed = new Vector3[(int)State.ENUM_END];

    [SerializeField] private MagneticForceVariable magneticForceVariable;

    [SerializeField]
    TurnManager turnManager;

    [SerializeField]
    bool IsHit = false;

    [SerializeField]
    private GameObject audioManager;

    private enum State{ 
     PUSH,       //プレイヤーが押すターン
     MASHING,    //連打ターン
     DOWN,       //アームを下げる
     WAIT,       //アーム停止
     UP,         //アーム引き上げ
     LEFT,       //横移動
     RELEASE,    //解放　
     RESET,      //全値初期化
     
     ENUM_END
    }
    private State state;

    float wait = 0.0f;

    private void Start()
    {
        state = State.PUSH;

    }
    private void Update()
    {
        /*
        //fixedにする場合
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
                Debug.Log("なんもしてないのにこわれた");
                break;
        }
       // Debug.Log(state.ToString());
    }

    void ArmCommand1()
    {
        //if(isKey){
        if (Input.GetKey(KeyCode.Space)) 
        {
            transform.position += armSpeed[(int)State.PUSH];

        }
        else if(100 <= transform.position.x || Input.GetKeyUp(KeyCode.Space))
        {
            wait = 4.0f;
            state++;
        }
    }

    void ArmCommand2()
    {
        wait -= Time.deltaTime;

        if (0 < wait)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                //磁力を増やす命令
                magneticForceVariable.GetKey();
            }
        }
        else if (transform.position.y <= 30 || wait <= 0)
        {
            IsHit = false;
            wait = 5.0f;
            // 降りる効果音再生
            audioManager.GetComponent<GameSceneAudioManager>().ArmDownSound();
            state++;
        }
    }

    void ArmCommand3()
    {
        transform.position += armSpeed[(int)State.DOWN];
        if(IsHit)
        {
            // 1秒後に降下SE停止
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
            // 上昇SE再生
            audioManager.GetComponent<GameSceneAudioManager>().ArmUpSound();
            state++;
        }
    }

    void ArmCommand5()
    {
        transform.position += armSpeed[(int)State.UP];
        if(transform.position.y >= 3)
        {
            // 上昇SE停止
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
