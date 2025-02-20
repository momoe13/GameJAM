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
        sterScoreText.text = "�~:" + ScoreKeep.sterScore.ToString();
        basePowerUpScoreText.text = "�~" + ScoreKeep.basePowerUpScore.ToString();
        ratePowerUpScoreText.text = "�~" + ScoreKeep.ratePowerUpScore.ToString();
        widthPowerUpScoreText.text = "�~" + ScoreKeep.widthPowerUpScore.ToString();
        turnRecoveryUpScoreText.text = "�~" + ScoreKeep.turnRecoveryUpScore.ToString();
    }
}
