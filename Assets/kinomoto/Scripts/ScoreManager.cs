using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public GameObject scoreObject = null;
    public int score = 0;//スコア変数

    private void Start()
    {
        //初期化
    }
    private void Update()
    {
        Text scoreText = scoreObject.GetComponent<Text>();

        //テキストの表示入替
        scoreText.text = "スコア:" + score.ToString();
    }
}
