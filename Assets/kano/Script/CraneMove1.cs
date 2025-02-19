using UnityEngine;

public class CraneMove1 : MonoBehaviour
{

    [SerializeField]//Space������������
    private bool isPush;

    [SerializeField]
    Rigidbody2D rb2d;

    private float x, y;

    float time;

    private enum State
    {
        DOWN,       //�A�[����������
        WAIT,       //�A�[����~
        UP,         //�A�[�������グ
        HORIZONTAL, //���ړ�
    }
    private State state;
    int num = 0;

    private void Start()
    {
        state = State.DOWN;
    }
    private void Update()
    {
        time += Time.deltaTime;

        ARMMove();

        if (time > 2)
        {
            if (num > 3) { return; }
            num++;
            time = 0;
        }
        if (transform.position.x < -6.0f) { num = 4; }

    }

    private void ARMMove()
    {
        switch (num)
        {
            case 0:

                //���Ɍ�����
                rb2d.velocity = new Vector2(0, -2.0f);
                break;

            case 1:
                rb2d.velocity = Vector3.zero;
                break;
            case 2:
                //��ɏオ��
                rb2d.velocity = new Vector2(0, 2.0f);
                break;
            case 3:
                //���Ɉړ�
                rb2d.velocity = new Vector2(-2.0f, 0);
                break;
            case 4:
                rb2d.velocity = Vector3.zero;
                break;

            default: break;
        }

    }
}

