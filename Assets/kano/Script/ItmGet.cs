using UnityEngine;

public class ItmGet : MonoBehaviour
{
    [SerializeField] private GameObject crane;
    [SerializeField] private TargetItem TargetItem;
    [SerializeField] private GameObject audioManager;

 [SerializeField] private GameObject itemGetParticle;
    [SerializeField] private GeneratingManager generatingManager;
    private void Start()
    {
        TargetItem.TargetSet();
        generatingManager.Generation();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�l�����̃p�[�e�B�N������
        Instantiate(itemGetParticle,collision.gameObject.transform.position,Quaternion.identity);
        //�X�^�[����ꂽ���̏���
        if (collision.gameObject.tag == "Star")
        {
            AddScoreOnDestroy(collision, 10);//�X�R�A��10�_���Z
        }
        //��b�p���[�A�b�v�A�C�e������ꂽ�Ƃ��̏���
        if (collision.gameObject.tag == "BasePowerUp")
        {
            audioManager.GetComponent<GameSceneAudioManager>().PowerUpSound();
            crane.GetComponent<MagneticForceVariable>().AddBase();//�N���[���̊�b�p���[�𑝉�
            AddScoreOnDestroy(collision, 100);
            Debug.Log("��b�l�p���[�A�b�v�I");
        }
        //�{���p���[�A�b�v����ꂽ�Ƃ��̏���
        if (collision.gameObject.tag == "RatePowerUp")
        {
            audioManager.GetComponent<GameSceneAudioManager>().PowerUpSound();
            crane.GetComponent<MagneticForceVariable>().AddMagnification();//�N���[���̔{���p���[�𑝉�
            AddScoreOnDestroy(collision, 100);
            Debug.Log("�{���p���[�A�b�v�I");
        }
        //�����p���[�A�b�v����ꂽ�Ƃ��̏���
        if (collision.gameObject.tag == "WidthPowerUp")
        {
            audioManager.GetComponent<GameSceneAudioManager>().PowerUpSound();
            AddScoreOnDestroy(collision, 100);
            Debug.Log("�����p���[�A�b�v�I");
        }
        //�^�[���񕜐��A�b�v����ꂽ�Ƃ��̏���
        if (collision.gameObject.tag == "TurnRecoveryUp")
        {
            audioManager.GetComponent<GameSceneAudioManager>().PowerUpSound();
            AddScoreOnDestroy(collision, 100);
            Debug.Log("�^�[���񕜐��A�b�v�I");
        }
        //�ڕW�A�C�e�����擾�����ۂ̏���
        if (collision.gameObject.tag == "Target")
        {
            AddScoreOnDestroy(collision, 1000);
            Debug.Log("�폜�I");

            if (TargetItem.PushItem[0].name == collision.gameObject.name)
            {
                Debug.Log("�ڕW�̃A�C�e�����Q�b�g�I");
                TargetItem.TargetSet();
                generatingManager.Generation();
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
        ScoreKeep.score += addScore;//�X�R�A�����Z
    }
}
