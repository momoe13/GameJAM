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
        //初期化
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

        //テキストの表示入替
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

        //テキストの表示入替
        scoreText.text = ScoreKeep.score.ToString() + "てん";
        sterScoreText.text = "ほし:" + ScoreKeep.sterScore.ToString();
        basePowerUpScoreText.text = "基礎パワーアップ獲得数:" + ScoreKeep.basePowerUpScore.ToString();
        ratePowerUpScoreText.text = "倍率パワーアップ獲得数:" + ScoreKeep.ratePowerUpScore.ToString();
        widthPowerUpScoreText.text = "横幅パワーアップ獲得数:" + ScoreKeep.widthPowerUpScore.ToString();
        turnRecoveryUpScoreText.text = "ターン回復アイテム獲得数:" + ScoreKeep.turnRecoveryUpScore.ToString();
        //prizeScoreText.text = "景品の獲得数:" + ScoreKeep.prizeScore.ToString();
=======
    {  Text scoreText = scoreObject.GetComponent<Text>();
        //    Text sterScoreText = sterScoreObject.GetComponent<Text>();
        //    Text basePowerUpScoreText = basePowerUpScoreObject.GetComponent<Text>();
        //    Text ratePowerUpScoreText = ratePowerUpScoreObject.GetComponent<Text>();
        //    Text widthPowerUpScoreText = widthPowerUpScoreObject.GetComponent<Text>();
        //    Text turnRecoveryUpScoreText = turnRecoveryUpScoreObject.GetComponent<Text>();
        //    Text prizeScoreText = prizeScoreObject.GetComponent<Text>();

        //テキストの表示入替
>>>>>>> Stashed changes
        scoreText.text = "スコア:" + ScoreKeep.score.ToString();
        //    sterScoreText.text = "星の獲得数:" + ScoreKeep.sterScore.ToString();
        //    basePowerUpScoreText.text = "基礎パワーアップ獲得数:" + ScoreKeep.basePowerUpScore.ToString();
        //    ratePowerUpScoreText.text = "倍率パワーアップ獲得数:" + ScoreKeep.ratePowerUpScore.ToString();
        //    widthPowerUpScoreText.text = "横幅パワーアップ獲得数:" + ScoreKeep.widthPowerUpScore.ToString();
        //    turnRecoveryUpScoreText.text = "ターン回復アイテム獲得数:" + ScoreKeep.turnRecoveryUpScore.ToString();
        //    prizeScoreText.text = "景品の獲得数:" + ScoreKeep.prizeScore.ToString();
<<<<<<< Updated upstream
=======
>>>>>>> a0cc5b4139dc7bfd90e65c1f1752929886b717f2
>>>>>>> Stashed changes



        //（仮）エスケープを押してリザルトに移動
        //スコアの引継ぎ確認用
        if (Input.GetKeyDown(KeyCode.N))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("resultScene");
        }
    }
}
