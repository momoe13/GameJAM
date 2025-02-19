using UnityEngine;

public class Title : MonoBehaviour
{
    [SerializeField] private GameObject helpUi;
    [SerializeField] private GameObject spaceUi;
    // �t�F�[�h�̏���������Ȃ�A���ꂪ�I������Ƃ���true�ɂ��Ă��炤
    [SerializeField] private bool isSpace = false;

    [Header("�I�[�f�B�I�n")]
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
                // ���̉��ɃV�[���̃��[�h�̖���

            }
        }
    }
}
