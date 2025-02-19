using UnityEngine;

public class CreaneMove : MonoBehaviour
{

    [SerializeField]//Spaceを押した判定
    private bool isPush = false;

    [SerializeField]
    Rigidbody2D rb2d;

    private float x, y;

    float time;

    [SerializeField] private MagneticForceManager magneticForceManager;

    private enum State{ 
     PUSH,       //プレイヤーが押すターン
     MASHING,    //連打ターン
     DOWN,       //アームを下げる
     WAIT,       //アーム停止
     UP,         //アーム引き上げ
     LEFT,       //左移動
    }
    private State state;
    int num =0;

    private void Start()
    {
        state = State.PUSH;
    }
    private void Update()
    {
        //スペースキー押してる間右に移動
        //連打ターン
        //下におろす
        //上がる
        //左に戻る

        if (isPush)
        {
           // Debug.Log(num);
            time += Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (isPush) { return; }

            //右に移動
            rb2d.velocity = new Vector2(2.0f, 0);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            if (isPush) { return; }
            isPush = true;
            rb2d.velocity = Vector3.zero;
            ARMMove();
        }

        if (time > 3)
        {
            if (num > 5) { return; }
            num++;
            time = 0;
        }
        if (transform.position.x < -6.0f) { num = 4; }


    }

    private void ARMMove()
    {
        switch (num)
        {
            case 1:
                Debug.Log("aaa");
                time = 0;   
                rb2d.velocity = Vector3.zero;
                magneticForceManager.GetKey();

                break;
                
            case 2:
                //下に向かう
                rb2d.velocity = new Vector2(0, -2.0f);
                break;

            case 3:
                rb2d.velocity = Vector3.zero;
                break;
            case 4:
                //上に上がる
                rb2d.velocity = new Vector2(0, 2.0f);
                break;
            case 5:
                //左に移動
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
