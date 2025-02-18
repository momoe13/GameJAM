using UnityEngine;

public class MagneticForceVariable : MonoBehaviour
{
    [Header("�A�ŏ����̋���")]
    // �X�y�[�X�������ƃJ�E���g�𑝂₷���������Ă��������ǂ���
    public bool isSpace;
    [Header("�A�ŉ�")]
    [SerializeField] private int pushCount = 0;

    [Header("���ݗ͔{��")]
    // ���݂̔{��
    [SerializeField] private float magnification = 0.01f;
    // ���Z����{���l
    [SerializeField] private float addMagnificationValue = 0.01f;

    [Header("��b�l")]
    // ���݂̊�b�l
    [SerializeField] private float baseValue = -100f;
    // ���Z�����b�l
    [SerializeField] private float addBaseValue = -3f;

    [Header("�ŏI�l")]
    // ���f������Ƃ��̍ŏI�l
    [SerializeField] private float resultValue;

    void Update()
    {
        if (isSpace)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // �X�y�[�X����������J�E���g�����Z
                pushCount++;
                Reflection();
            }
        }        
    }

    /// <summary>
    /// �N���[���Ɏ��͂̒l�𔽉f�����郁�\�b�h
    /// </summary>
    public void Reflection()
    {
        // �ŏI�l�̌v�Z
        resultValue = baseValue + ((magnification * pushCount) * baseValue);
        // �v�Z���ꂽ���͂��N���[���ɔ��f������
        gameObject.GetComponent<PointEffector2D>().forceMagnitude = resultValue;
    }

    /// <summary>
    /// ���ݗ͔{�������Z����i�p���[�A�b�v�A�C�e���l�����ɌĂяo�����j
    /// </summary>
    public void AddMagnification()
    {
        magnification += addMagnificationValue;
        //�@���f������
        Reflection();
    }

    public void AddBase()
    {
        baseValue += addBaseValue;
        // ���f������
        Reflection();
    }
}
