using UnityEngine;

public class MagneticForceVariable : MonoBehaviour
{
    //�X�y�[�X�������ƃJ�E���g�𑝂₷���������Ă��������ǂ���
    public bool isSpace;
    [Header("�A�ŉ�")]
    [SerializeField] private int pushCount = 0;

    [Header("���ݗ͔{��")]
    [SerializeField] private float magnification = 0.01f;
    //���Z����{���l
    [SerializeField] private float addMagnificationValue = 0.01f;

    [Header("��b�l")]
    [SerializeField] private float baseValue = -100f;
    //���Z�����b�l
    [SerializeField] private float addBaseValue = -3f;

    [Header("�ŏI�l")]
    [SerializeField] private float resultValue;
    void Update()
    {
        if (isSpace)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                pushCount++;
                Reflection();
            }
            //��

            //�{�����Z
            if (Input.GetKeyDown(KeyCode.M))
            {
                AddMagnification();
                Debug.Log("�{�������Z���ꂽ");
            }
            //��b���Z
            if (Input.GetKeyDown(KeyCode.B))
            {
                AddBase();
                Debug.Log("��b�l�����Z���ꂽ");
            }
        }        
    }

    public void Reflection()
    {
        resultValue = baseValue + ((magnification * pushCount) * baseValue);
        gameObject.GetComponent<PointEffector2D>().forceMagnitude = resultValue;
    }

    public void AddMagnification()
    {
        magnification = magnification + addMagnificationValue;
        Reflection();
    }

    public void AddBase()
    {
        baseValue = baseValue + addBaseValue;
        Reflection();
    }
}
