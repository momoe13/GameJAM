using UnityEngine;

public class ItmGet : MonoBehaviour
{
    [SerializeField] private GameObject crane;
    [SerializeField] private TargetItem TargetItem;
    [SerializeField] private GameObject audioManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�X�^�[����ꂽ���̏���
        if (collision.gameObject.tag == "Star")
        {
            //Destroy(collision.gameObject);//�I�u�W�F�N�g���폜
            //ScoreKeep.score += 10;//�X�R�A��10�_���Z
            AddScoreOnDestroy(collision, 10);//�X�R�A��10�_���Z
        }
        //��b�p���[�A�b�v�A�C�e������ꂽ�Ƃ��̏���
        if (collision.gameObject.tag == "BasePowerUp")
        {
            audioManager.GetComponent<GameSceneAudioManager>().PowerUpSound();
            crane.GetComponent<MagneticForceVariable>().AddBase();//�N���[���̊�b�p���[�𑝉�
            //Destroy(collision.gameObject);//�I�u�W�F�N�g���폜
            //ScoreKeep.score += 100;//�X�R�A��100�_���Z
            AddScoreOnDestroy(collision, 100);
            Debug.Log("��b�l�p���[�A�b�v�I");
        }
        //�{���p���[�A�b�v����ꂽ�Ƃ��̏���
        if (collision.gameObject.tag == "RatePowerUp")
        {
            audioManager.GetComponent<GameSceneAudioManager>().PowerUpSound();
            crane.GetComponent<MagneticForceVariable>().AddMagnification();//�N���[���̔{���p���[�𑝉�
            //Destroy(collision.gameObject);//�I�u�W�F�N�g���폜
            //ScoreKeep.score += 100;//�X�R�A��100�_���Z
            AddScoreOnDestroy(collision, 100);
            Debug.Log("�{���p���[�A�b�v�I");
        }
        //�����p���[�A�b�v����ꂽ�Ƃ��̏���
        if (collision.gameObject.tag == "WidthPowerUp")
        {
            //Destroy(collision.gameObject);//�I�u�W�F�N�g���폜
            //ScoreKeep.score += 100;//�X�R�A��100�_���Z
            audioManager.GetComponent<GameSceneAudioManager>().PowerUpSound();
            AddScoreOnDestroy(collision, 100);
            Debug.Log("�����p���[�A�b�v�I");
        }
        //�^�[���񕜐��A�b�v����ꂽ�Ƃ��̏���
        if (collision.gameObject.tag == "TurnRecoveryUp")
        {
            //Destroy(collision.gameObject);//�I�u�W�F�N�g���폜
            //ScoreKeep.score += 100;//�X�R�A��100�_���Z
            audioManager.GetComponent<GameSceneAudioManager>().PowerUpSound();
            AddScoreOnDestroy(collision, 100);
            Debug.Log("�^�[���񕜐��A�b�v�I");
        }
        //�ڕW�A�C�e�����擾�����ۂ̏���
        if (collision.gameObject.tag == "Target")
        {
            //Destroy(collision.gameObject);//�I�u�W�F�N�g���폜

            //    Debug.Log("�폜�I");
            //ScoreKeep.score += 1000;//�X�R�A��1000�_���Z
            AddScoreOnDestroy(collision, 1000);
            Debug.Log("�폜�I");

            if (TargetItem.PushItem[0].name == collision.gameObject.name)
            {
                Debug.Log("�ڕW�̃A�C�e�����Q�b�g�I");
            }
            else
            {
                Debug.Log("�^�[�Q�b�g�A�C�e�����Q�b�g�I");
            }
        }
    }

    private void AddScoreOnDestroy(Collider2D collision,int addScore)
    {
        Destroy(collision.gameObject);
        ScoreKeep.score += addScore;//�X�R�A��100�_���Z
    }
}
