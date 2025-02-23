using System.Collections;
using UnityEngine;

public class Title : MonoBehaviour
{
    [SerializeField] private GameObject helpUi;
    [SerializeField] private GameObject spaceUi;
    // フェードの処理があるなら、それが終わったときにtrueにしてもらう
    [SerializeField] private bool isSpace = false;


    private int spaceCount = 0;


    private void Start()
    {
        ScoreKeep.AllValueReset();
    }

    void Update()
    {
        if (isSpace)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                if (spaceCount == 0)
                {
                    AudioManager.Instance.SelectSEPlay();
                    spaceCount++;
                    spaceUi.SetActive(false);
                    helpUi.SetActive(true);
                }
                else if (spaceCount == 1)
                {
                    AudioManager.Instance.SelectSEPlay();
                    spaceCount++;
                    TestParticle.Instance.fadeCall();
                    spaceCount++;
                }

            }
        }
    }
}
