using System.Collections;
using UnityEngine;

public class ItmGet : MonoBehaviour
{
    [SerializeField] private GameObject crane;
    [SerializeField] private TargetItem TargetItem;
    [SerializeField] private GameObject audioManager;

    [SerializeField] private GameObject itemGetParticle;
    [SerializeField] private GeneratingManager generatingManager;
    [SerializeField] private GameObject turnManager;

    private void Start()
    {
        TargetItem.TargetSet();
        generatingManager.Generation();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�l�����̃p�[�e�B�N������
        Destroy(Instantiate(itemGetParticle, collision.gameObject.transform.position, Quaternion.identity), 1.0f);
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
            ScoreKeep.basePowerUpScore += 1;
            AddScoreOnDestroy(collision, 100);
        }
        //�{���p���[�A�b�v����ꂽ�Ƃ��̏���
        if (collision.gameObject.tag == "RatePowerUp")
        {
            audioManager.GetComponent<GameSceneAudioManager>().PowerUpSound();
            crane.GetComponent<MagneticForceVariable>().AddMagnification();//�N���[���̔{���p���[�𑝉�
            ScoreKeep.ratePowerUpScore += 1;
            AddScoreOnDestroy(collision, 100);
        }
        //�����p���[�A�b�v����ꂽ�Ƃ��̏���
        if (collision.gameObject.tag == "WidthPowerUp")
        {
            audioManager.GetComponent<GameSceneAudioManager>().PowerUpSound();
            ScoreKeep.widthPowerUpScore += 1;
            AddScoreOnDestroy(collision, 100);
        }
        //�^�[���񕜐��A�b�v����ꂽ�Ƃ��̏���
        if (collision.gameObject.tag == "TurnRecoveryUp")
        {
            audioManager.GetComponent<GameSceneAudioManager>().PowerUpSound();
            turnManager.GetComponent<TurnManager>().ItemGetTurnCountUp();
            ScoreKeep.turnRecoveryUpScore += 1;
            AddScoreOnDestroy(collision, 100);
        }
        //�ڕW�A�C�e�����擾�����ۂ̏���
        if (collision.gameObject.tag == "Target")
        {
            audioManager.GetComponent<GameSceneAudioManager>().PowerUpSound();
            AddScoreOnDestroy(collision, 1000);
            ScoreKeep.prizeScore += 1;

            if (TargetItem.PushItem[0].name + "(Clone)" == collision.gameObject.name)
            {
                Debug.Log("�ڕW�̃A�C�e�����Q�b�g�I");
                TargetItem.TargetSet();
                generatingManager.Generation();
                ScoreKeep.score += 1000;

            }
            else
            {
                Debug.Log("�^�[�Q�b�g�A�C�e�����Q�b�g�I");
            }
        }
    }

    private void AddScoreOnDestroy(Collider2D collision, int addScore)
    {
        Destroy(collision.gameObject);
        ScoreKeep.score += addScore;//�X�R�A�����Z
    }
}
