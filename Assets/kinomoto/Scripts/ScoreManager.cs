using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public GameObject scoreObject = null;
    public GameObject sterScoreObject = null;
    public GameObject basePowerUpScoreObject = null;
    public GameObject ratePowerUpScoreObject = null;
    public GameObject widthPowerUpScoreObject = null;
    public GameObject turnRecoveryUpScoreObject = null;
    //public GameObject prizeScoreObject = null;

    private void Start()
    {
        //������
    }
    private void Update()
<<<<<<< Updated upstream
    {  Text scoreText = scoreObject.GetComponent<Text>();
        //    Text sterScoreText = sterScoreObject.GetComponent<Text>();
        //    Text basePowerUpScoreText = basePowerUpScoreObject.GetComponent<Text>();
        //    Text ratePowerUpScoreText = ratePowerUpScoreObject.GetComponent<Text>();
        //    Text widthPowerUpScoreText = widthPowerUpScoreObject.GetComponent<Text>();
        //    Text turnRecoveryUpScoreText = turnRecoveryUpScoreObject.GetComponent<Text>();
        //    Text prizeScoreText = prizeScoreObject.GetComponent<Text>();

        //�e�L�X�g�̕\������
=======
<<<<<<< HEAD
    {
        Text scoreText = scoreObject.GetComponent<Text>();
        Text sterScoreText = sterScoreObject.GetComponent<Text>();
        Text basePowerUpScoreText = basePowerUpScoreObject.GetComponent<Text>();
        Text ratePowerUpScoreText = ratePowerUpScoreObject.GetComponent<Text>();
        Text widthPowerUpScoreText = widthPowerUpScoreObject.GetComponent<Text>();
        Text turnRecoveryUpScoreText = turnRecoveryUpScoreObject.GetComponent<Text>();
        //Text prizeScoreText = prizeScoreObject.GetComponent<Text>();

        //�e�L�X�g�̕\������
        scoreText.text = ScoreKeep.score.ToString() + "�Ă�";
        sterScoreText.text = "�ق�:" + ScoreKeep.sterScore.ToString();
        basePowerUpScoreText.text = "��b�p���[�A�b�v�l����:" + ScoreKeep.basePowerUpScore.ToString();
        ratePowerUpScoreText.text = "�{���p���[�A�b�v�l����:" + ScoreKeep.ratePowerUpScore.ToString();
        widthPowerUpScoreText.text = "�����p���[�A�b�v�l����:" + ScoreKeep.widthPowerUpScore.ToString();
        turnRecoveryUpScoreText.text = "�^�[���񕜃A�C�e���l����:" + ScoreKeep.turnRecoveryUpScore.ToString();
        //prizeScoreText.text = "�i�i�̊l����:" + ScoreKeep.prizeScore.ToString();
=======
    {  Text scoreText = scoreObject.GetComponent<Text>();
        //    Text sterScoreText = sterScoreObject.GetComponent<Text>();
        //    Text basePowerUpScoreText = basePowerUpScoreObject.GetComponent<Text>();
        //    Text ratePowerUpScoreText = ratePowerUpScoreObject.GetComponent<Text>();
        //    Text widthPowerUpScoreText = widthPowerUpScoreObject.GetComponent<Text>();
        //    Text turnRecoveryUpScoreText = turnRecoveryUpScoreObject.GetComponent<Text>();
        //    Text prizeScoreText = prizeScoreObject.GetComponent<Text>();

        //�e�L�X�g�̕\������
>>>>>>> Stashed changes
        scoreText.text = "�X�R�A:" + ScoreKeep.score.ToString();
        //    sterScoreText.text = "���̊l����:" + ScoreKeep.sterScore.ToString();
        //    basePowerUpScoreText.text = "��b�p���[�A�b�v�l����:" + ScoreKeep.basePowerUpScore.ToString();
        //    ratePowerUpScoreText.text = "�{���p���[�A�b�v�l����:" + ScoreKeep.ratePowerUpScore.ToString();
        //    widthPowerUpScoreText.text = "�����p���[�A�b�v�l����:" + ScoreKeep.widthPowerUpScore.ToString();
        //    turnRecoveryUpScoreText.text = "�^�[���񕜃A�C�e���l����:" + ScoreKeep.turnRecoveryUpScore.ToString();
        //    prizeScoreText.text = "�i�i�̊l����:" + ScoreKeep.prizeScore.ToString();
<<<<<<< Updated upstream
=======
>>>>>>> a0cc5b4139dc7bfd90e65c1f1752929886b717f2
>>>>>>> Stashed changes



        //�i���j�G�X�P�[�v�������ă��U���g�Ɉړ�
        //�X�R�A�̈��p���m�F�p
        if (Input.GetKeyDown(KeyCode.N))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("resultScene");
        }
    }
}
