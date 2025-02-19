using UnityEngine;

public class Title : MonoBehaviour
{
    [SerializeField] private GameObject helpUi;

    [Header("���ʉ�")]
    [SerializeField] private AudioSource audioSource;
    private int spaceCount = 0;
    // �t�F�[�h�̏���������Ȃ�A���ꂪ�I������Ƃ���true�ɂ��Ă��炤
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
                // ���̉��ɃV�[���̃��[�h�̖���

            }
        }
    }
}
