using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundManager : MonoBehaviour
{
    [SerializeField]private GameObject backGroundObject_1;
    [SerializeField]private GameObject backGroundObject_2;
    [SerializeField]private GameObject backGroundObject_3;

    private void Start()
    {
        backGroundObject_1.SetActive(false);
        backGroundObject_2.SetActive(false);
        backGroundObject_3.SetActive(false);
    }
    private void Update()
    {
        if (ScoreKeep.prizeScore >= 1)
        {
            backGroundObject_1.SetActive(true);
            if(ScoreKeep.prizeScore >= 3)
            {
                backGroundObject_2.SetActive(true);
                if(ScoreKeep.prizeScore >= 5)
                {
                    backGroundObject_3.SetActive(true);
                }
            }
        }
    }
}
