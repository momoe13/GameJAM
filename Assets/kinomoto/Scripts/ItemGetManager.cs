using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemGetManager : MonoBehaviour
{
    [SerializeField] private GameObject crane;

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
            crane.GetComponent<MagneticForceVariable>().AddBase();//�N���[���̊�b�p���[�𑝉�
            Destroy(collision.gameObject);//�I�u�W�F�N�g���폜
            ScoreKeep.score += 100;//�X�R�A��100�_���Z
            Debug.Log("��b�l�p���[�A�b�v�I");
        }
        //�{���p���[�A�b�v����ꂽ�Ƃ��̏���
        if (collision.gameObject.tag == "RatePowerUp")
        {
            crane.GetComponent<MagneticForceVariable>().AddMagnification();//�N���[���̔{���p���[�𑝉�
            Destroy(collision.gameObject);//�I�u�W�F�N�g���폜
            ScoreKeep.score += 100;//�X�R�A��100�_���Z
            Debug.Log("�{���p���[�A�b�v�I");
        }
        //�ڕW�A�C�e�����擾�����ۂ̏���
        if (collision.gameObject.tag == "Target")
        {
            Destroy(collision.gameObject);//�I�u�W�F�N�g���폜
            ScoreKeep.score += 1000;//�X�R�A��1000�_���Z
            Debug.Log("�ڕW�̃A�C�e�����Q�b�g�I");
        }
    }
}
