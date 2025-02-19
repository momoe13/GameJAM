using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour
{
    [SerializeField] private GameObject helpUi;
    private int spaceCount = 0;
    // フェードの処理があるなら、それが終わったときにtrueにしてもらう
    [SerializeField] private bool isSpace = false;

    void Update()
    {
        if (isSpace)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (spaceCount == 0)
                {
                    spaceCount++;
                    helpUi.SetActive(true);
                }
                else if(spaceCount == 1) 
                {
                    spaceCount++;
                }
                // この下にシーンのロードの命令

            }
        }
    }
}
