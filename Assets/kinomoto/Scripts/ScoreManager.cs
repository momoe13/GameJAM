using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public GameObject scoreObject = null;

    private void Start()
    {
        //������
    }
    private void Update()
    {
        Text scoreText = scoreObject.GetComponent<Text>();

        //�e�L�X�g�̕\������
        scoreText.text = "�X�R�A:" + ScoreKeep.score.ToString();
    }
}
