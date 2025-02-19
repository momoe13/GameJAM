using UnityEngine;

public class TestGetManager : MonoBehaviour
{
    [SerializeField] private GameObject crane;
    [SerializeField] private GameObject TargetManager;
    [SerializeField] private GameObject audioManager;

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
            audioManager.GetComponent<GameSceneAudioManager>().PowerUpSound();
            crane.GetComponent<MagneticForceVariable>().AddBase();//�N���[���̊�b�p���[�𑝉�
            Destroy(collision.gameObject);//�I�u�W�F�N�g���폜
            ScoreKeep.score += 100;//�X�R�A��100�_���Z
            Debug.Log("��b�l�p���[�A�b�v�I");
        }
        //�{���p���[�A�b�v����ꂽ�Ƃ��̏���
        if (collision.gameObject.tag == "RatePowerUp")
        {
            audioManager.GetComponent<GameSceneAudioManager>().PowerUpSound();
            crane.GetComponent<MagneticForceVariable>().AddMagnification();//�N���[���̔{���p���[�𑝉�
            Destroy(collision.gameObject);//�I�u�W�F�N�g���폜
            ScoreKeep.score += 100;//�X�R�A��100�_���Z
            Debug.Log("�{���p���[�A�b�v�I");
        }
        //�����p���[�A�b�v����ꂽ�Ƃ��̏���
        if(collision.gameObject.tag == "WidthPowerUp")
        {
            audioManager.GetComponent<GameSceneAudioManager>().PowerUpSound();
            Destroy(collision.gameObject);//�I�u�W�F�N�g���폜
            ScoreKeep.score += 100;//�X�R�A��100�_���Z
            Debug.Log("�����p���[�A�b�v�I");
        }
        //�^�[���񕜐��A�b�v����ꂽ�Ƃ��̏���
        if (collision.gameObject.tag == "TurnRecoveryUp")
        {
            audioManager.GetComponent<GameSceneAudioManager>().PowerUpSound();
            Destroy(collision.gameObject);//�I�u�W�F�N�g���폜
            ScoreKeep.score += 100;//�X�R�A��100�_���Z
            Debug.Log("�^�[���񕜐��A�b�v�I");
        }
        //�ڕW�A�C�e�����擾�����ۂ̏���
        if (collision.gameObject.tag == "Target")
        {
            Destroy(collision.gameObject);//�I�u�W�F�N�g���폜
            ScoreKeep.score += 1000;//�X�R�A��1000�_���Z

            if (TargetManager.GetComponent<TargetManager>().TargetNumber == int.Parse(collision.gameObject.name))
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
