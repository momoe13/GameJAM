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
        //èâä˙âª
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

        //ÉeÉLÉXÉgÇÃï\é¶ì¸ë÷
        scoreText.text = ScoreKeep.score.ToString() + "ÇƒÇÒ";
        sterScoreText.text = "Å~:" + ScoreKeep.sterScore.ToString();
        basePowerUpScoreText.text = "Å~" + ScoreKeep.basePowerUpScore.ToString();
        ratePowerUpScoreText.text = "Å~" + ScoreKeep.ratePowerUpScore.ToString();
        widthPowerUpScoreText.text = "Å~" + ScoreKeep.widthPowerUpScore.ToString();
        turnRecoveryUpScoreText.text = "Å~" + ScoreKeep.turnRecoveryUpScore.ToString();
    }
}
