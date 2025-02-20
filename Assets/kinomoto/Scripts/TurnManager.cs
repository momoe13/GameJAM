using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TurnManager : MonoBehaviour
{
    public GameObject turnObject = null;
    public float turnCount = 3;

    private void Start()
    {
        //初期化
    }

    private void Update()
    {
        Text turnText = turnObject.GetComponent<Text>();
        turnText.text = turnCount.ToString();//残りターン数を表示

       // Debug.Log(turnCount);
        if (turnCount <= 0)
        {
            //SceneManager.LoadScene("");
            //ゲームを終了
        }

        
    }
    /// <summary>
    /// ターン数のカウント減少
    /// </summary>
    public void TurnCountDown()
    {
        turnCount--;
    }


    /// <summary>
    /// ターン数のカウント上昇
    /// </summary>
    public void TurnCountUp()
    {
        turnCount++;
    }
}
