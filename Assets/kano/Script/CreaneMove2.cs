using UnityEngine;

public class CreaneMove2 : MonoBehaviour
{

    [SerializeField]//Spaceを押した判定
    private bool isPush = false;

    Rigidbody2D rb2d;

    [SerializeField]
    Vector3[] armSpeed = new Vector3[(int)State.ENUM_END];

    [SerializeField] private MagneticForceVariable magneticForceVariable;

    [SerializeField]
    bool IsHit = false;

    private enum State{ 
     PUSH,       //プレイヤーが押すターン
     MASHING,    //連打ターン
     DOWN,       //アームを下げる
     WAIT,       //アーム停止
     UP,         //アーム引き上げ
     LEFT,       //横移動
     RELEASE,  //解放　
     RESET,      //全値初期化
     
     ENUM_END
    }
    private State state;

    int num = 0;
    float wait = 0.0f;

    private void Start()
    {
        GetComponent<Rigidbody2D>();

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
                magneticForceVariable.MagneticOff();
                state = State.PUSH;
                Debug.Log("解放");
                break;

            case State.RESET:
                magneticForceVariable.ResetPushCount();
                magneticForceVariable.Reflection();

                Debug.Log("1ターン終了");
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
            state++;
        }
    }

    void ArmCommand3()
    {
        transform.position += armSpeed[(int)State.DOWN];
        if(IsHit)
        {
            state++;
            wait = 3.0f;
        }
    }

    void ArmCommand4()
    {
        wait -= Time.deltaTime;
        if(0 > wait)
        {
            state++;
        }
    }

    void ArmCommand5()
    {
        transform.position += armSpeed[(int)State.UP];
        if(transform.position.y >= 3)
        {
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
}
