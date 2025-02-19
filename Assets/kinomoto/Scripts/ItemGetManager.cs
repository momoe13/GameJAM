using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TestItemGetManager : MonoBehaviour
{
    [SerializeField] private GameObject cranePowerErea;
    [SerializeField] private GameObject targetManager;
    [SerializeField] private GameObject turnManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�X�^�[����ꂽ���̏���
        if (collision.gameObject.tag == "Star")
        {
            Destroy(collision.gameObject);//�I�u�W�F�N�g���폜
            ScoreKeep.score += 10;//�X�R�A��10�_���Z
        }
        //��b�p���[�A�b�v�A�C�e������ꂽ�Ƃ��̏���
        if (collision.gameObject.tag == "BasePowerUp")
        {
            cranePowerErea.GetComponent<MagneticForceVariable>().AddBase();//�N���[���̊�b�p���[�𑝉�
            Destroy(collision.gameObject);//�I�u�W�F�N�g���폜
            ScoreKeep.score += 100;//�X�R�A��100�_���Z
            Debug.Log("��b�l�p���[�A�b�v�I");
        }
        //�{���p���[�A�b�v����ꂽ�Ƃ��̏���
        if (collision.gameObject.tag == "RatePowerUp")
        {
            cranePowerErea.GetComponent<MagneticForceVariable>().AddMagnification();//�N���[���̔{���p���[�𑝉�
            Destroy(collision.gameObject);//�I�u�W�F�N�g���폜
            ScoreKeep.score += 100;//�X�R�A��100�_���Z
            Debug.Log("�{���p���[�A�b�v�I");
        }
        //�����p���[�A�b�v����ꂽ�Ƃ��̏���
        if(collision.gameObject.tag == "WidthPowerUp")
        {
            //�N���[���̃r�[�������̉����𑝉�
            cranePowerErea.GetComponent<MagneticForceVariable>().ColliderSizeUp();
            Destroy(collision.gameObject);//�I�u�W�F�N�g���폜
            ScoreKeep.score += 100;//�X�R�A��100�_���Z
            Debug.Log("�����p���[�A�b�v�I");
        }
        //�^�[����+1����ꂽ�Ƃ��̏���
        if (collision.gameObject.tag == "TurnRecoveryUp")
        {
            turnManager.GetComponent<TurnManager>().TurnCountUp();//�^�[��+1
            Destroy(collision.gameObject);//�I�u�W�F�N�g���폜
            ScoreKeep.score += 100;//�X�R�A��100�_���Z
            Debug.Log("�^�[����+1�I");
        }
        //�ڕW�A�C�e�����擾�����ۂ̏���
        if (collision.gameObject.tag == "Target")
        {
            Destroy(collision.gameObject);//�I�u�W�F�N�g���폜
            ScoreKeep.score += 1000;//�X�R�A��1000�_���Z

            if (targetManager.GetComponent<TargetManager>().TargetNumber == int.Parse(collision.gameObject.name))
            {
                Debug.Log("�ڕW�̃A�C�e�����Q�b�g�I");
            }
            else
            {
                Debug.Log("�^�[�Q�b�g�A�C�e�����Q�b�g�I");
            }
        }
    }
}
