using UnityEngine;

public class Title : MonoBehaviour
{
    [SerializeField] private GameObject helpUi;
    [SerializeField] private GameObject spaceUi;
    // フェードの処理があるなら、それが終わったときにtrueにしてもらう
    [SerializeField] private bool isSpace = false;

    [Header("オーディオ系")]
    [SerializeField] private AudioSource bgmAudioSource;
    [SerializeField] private AudioSource seAudioSource;
    private int spaceCount = 0;

    void Update()
    {
        if (isSpace)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {             
                if (spaceCount == 0)
                {
                    seAudioSource.PlayOneShot(seAudioSource.clip);
                    spaceCount++;
                    spaceUi.SetActive(false);
                    helpUi.SetActive(true);
                }
                else if(spaceCount == 1) 
                {
                    seAudioSource.PlayOneShot(seAudioSource.clip);
                    spaceCount++;
                }
                // この下にシーンのロードの命令

            }
        }
    }
}
