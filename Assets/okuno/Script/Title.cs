using UnityEngine;

public class Title : MonoBehaviour
{
    [SerializeField] private GameObject helpUi;

    [Header("効果音")]
    [SerializeField] private AudioSource audioSource;
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
                    audioSource.PlayOneShot(audioSource.clip);
                    spaceCount++;
                    helpUi.SetActive(true);
                }
                else if(spaceCount == 1) 
                {
                    audioSource.PlayOneShot(audioSource.clip);
                    spaceCount++;
                }
                // この下にシーンのロードの命令

            }
        }
    }
}
