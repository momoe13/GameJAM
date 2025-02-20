using System.Collections;
using UnityEngine;

public class Title : MonoBehaviour
{
    [SerializeField] private GameObject helpUi;
    [SerializeField] private GameObject spaceUi;
    // �t�F�[�h�̏���������Ȃ�A���ꂪ�I������Ƃ���true�ɂ��Ă��炤
    [SerializeField] private bool isSpace = false;
    [SerializeField] private GameObject fadeParticle;
    [SerializeField] private GameObject fadeImage;

    [SerializeField] private GameObject fadeManager;

    [Header("�I�[�f�B�I�n")]
    [SerializeField] private AudioSource bgmAudioSource;
    [SerializeField] private AudioSource seAudioSource;
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
                    seAudioSource.PlayOneShot(seAudioSource.clip);
                    spaceCount++;
                    spaceUi.SetActive(false);
                    helpUi.SetActive(true);
                }
                else if (spaceCount == 1)
                {
                    seAudioSource.PlayOneShot(seAudioSource.clip);
                    spaceCount++;
                    if (fadeManager == null)
                    {
                        fadeManager = GameObject.Find("FadeManager");
                    }
                    fadeManager.GetComponent<TestParticle>().fadeCall();
                    spaceCount++;
                }

            }
        }
    }
}
