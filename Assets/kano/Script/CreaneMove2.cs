using UnityEngine;

public class CreaneMove2 : MonoBehaviour
{

    [SerializeField]//Space������������
    private bool isPush = false;

    //[SerializeField]
    Rigidbody2D rb2d;

    //private float x, y;
    //position.x, position.y
    Vector2 position;

    [SerializeField]
    Vector3[] armSpeed = new Vector3[(int)State.ENUM_END];

    float time;

    [SerializeField] private MagneticForceManager magneticForceManager;

    private enum State{ 
     PUSH,       //�v���C���[�������^�[��
     MASHING,    //�A�Ń^�[��
     DOWN,       //�A�[����������
     WAIT,       //�A�[����~
     UP,         //�A�[�������グ
     LEFT, //���ړ�

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
        //�X�y�[�X�L�[����
        //�E�Ɉړ�
        //�A�Ń^�[��
        //

        /*
        if (isPush) {
            time += Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (isPush) { return; }

            //�E�Ɉړ�
            rb2d.velocity = new Vector2(2.0f, 0);
        }
        else if(Input.GetKeyUp(KeyCode.Space))
        {
            if (isPush) { return; }
            isPush = true;
            rb2d.velocity = Vector3.zero;   
            ARMMove();
        }

        if (time >  3) {
            if (num > 5) { return; }
            num++;
            time = 0;
        }
        if (transform.position.x <-6.0f) { num = 4; }
        */


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

            default:
                Debug.Log("�Ȃ�����ĂȂ��̂ɂ���ꂽ");
                break;
        }
        Debug.Log(state.ToString());
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
                //���͂𑝂₷����
                magneticForceManager.GetKey();
            }
        }
        else if (transform.position.y <= 30 || wait <= 0)
        {
            wait = 5.0f;
            state++;
        }
    }

    void ArmCommand3()
    {
        transform.position += armSpeed[(int)State.DOWN];
        if(transform.position.y < -2.0f)
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
        Debug.Log("aaa");
        transform.position += armSpeed[(int)State.UP];
        if(transform.position.y >= 3)
        {
            time = 0;
            state++;
        }
    }
    
    void ArmCommand6()
    {
        transform.position += armSpeed[(int)State.LEFT];
        if(transform.position.x <= -6)
        {
            time = 0;
            state = 0;
        }
    }

    private void ARMMove()
    {
        switch (num)
        {
            case 0:
                
                break;
            case 1:
                time = 0;   
                rb2d.velocity = Vector3.zero;
                magneticForceManager.GetKey();

                Debug.Log("aaa");
                break;
                
            case 2:
                Debug.Log("aaa");
                //���Ɍ�����
                rb2d.velocity = new Vector2(0, -2.0f);
                break;

            case 3:
                rb2d.velocity = Vector3.zero;
                break;
            case 4:
                //��ɏオ��
                rb2d.velocity = new Vector2(0, 2.0f);
                break;
            case 5:
                //���Ɉړ�
                rb2d.velocity = new Vector2(-2.0f, 0);
                break;
            case 6:
                rb2d.velocity = Vector3.zero;
                break;

            default: break;
        }

        Debug.Log(num.ToString());
    }
}
