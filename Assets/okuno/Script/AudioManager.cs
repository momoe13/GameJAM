using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [Header("AudioSource")]
    [SerializeField] private AudioSource bgmSource;
    [SerializeField] private AudioSource craneSeSource;
    [SerializeField] private AudioSource normalSeSource;

    [Header("--------BGM--------")]
    [Header("�^�C�g��")]
    [SerializeField] private AudioClip title;
    [SerializeField] private float titleBGMBaseVolume;
    [Header("�Q�[��")]
    [SerializeField] private AudioClip game;
    [SerializeField] private float gameBGMBaseVolume;
    [Header("���U���g")]
    [SerializeField] private AudioClip result;
    [SerializeField] private float resultBGMBaseVolume;
    [Header("--------SE--------")]
    [Header("�Z���N�g")]
    [SerializeField] private AudioClip select;
    [SerializeField] private float selectSeBaseVolume;
    [Header("��ʑJ��SE")]
    [SerializeField] private AudioClip fade;
    [SerializeField] private float fadeSeBaseVolume;
    [Header("�N���[��SE")]
    [SerializeField] private AudioClip craneDown;
    [SerializeField] private AudioClip craneUp;
    [SerializeField] private float craneSeBaseVolume;
    [Header("�A�C�e���l��")]
    [SerializeField] private AudioClip itemGet;
    [SerializeField] private float itemGetSeBaseVolume;

    public const string audioBGMValueKey = "BGMValue";
    public const string audioSEValueKey = "SEValue";

    private bool isTitleBgm = false;
    private bool isGameBgm = false;
    private bool isResultBgm = false;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        //�������ɂ̓Z�b�g����l
        PlayerPrefs.SetFloat(audioBGMValueKey, 1f);
        PlayerPrefs.SetFloat(audioSEValueKey, 1f);
        PlayerPrefs.Save();
    }

    private void Start()
    {
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "0_TitleScene")
        {
            TitleBGMPlay();
        }
        else if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "1_InGameScene")
        {
            //�Q�[��BGM�Đ�
            GameBGMPlay();
        }
        else
        {
            //���U���gBGM�Đ�
            ResultBGMPlay();
        }
    }

    private void Update()
    {
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "0_TitleScene")
        {
            if (!isTitleBgm)
            {
                TitleBGMPlay();
            }
        }
        else if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "1_InGameScene")
        {
            if (!isGameBgm)
            {
                GameBGMPlay();
            }
        }
        else
        {
            if (!isResultBgm)
            {
                ResultBGMPlay();
            }
        }
    }

    public void TitleBGMPlay()
    {
        //�Đ����Ȃ�~�߂�
        StopIfPlaying(bgmSource);
        isTitleBgm = true;
        //�^�C�g����BGM�N���b�v��BGMSource�ōĐ�
        float titleBGMVolume = (PlayerPrefs.GetFloat(audioBGMValueKey, titleBGMBaseVolume) * titleBGMBaseVolume) + titleBGMBaseVolume;

        bgmSource.volume = titleBGMVolume;
        //AudioSurce��Clip�Ƀ^�C�g����Clip���i�[
        bgmSource.clip = title;
        bgmSource.Play();
    }

    public void GameBGMPlay()
    {
        StopIfPlaying(bgmSource);
        isGameBgm = true;

        float gameBGMVolume = (PlayerPrefs.GetFloat(audioBGMValueKey, gameBGMBaseVolume) * gameBGMBaseVolume) + gameBGMBaseVolume;
        bgmSource.volume = gameBGMVolume;
        bgmSource.clip = game;
        bgmSource.Play();
    }

    public void ResultBGMPlay()
    {
        StopIfPlaying(bgmSource);
        isResultBgm = true;

        float resultBGMVolume = (PlayerPrefs.GetFloat(audioBGMValueKey, resultBGMBaseVolume) * titleBGMBaseVolume) + resultBGMBaseVolume;
        bgmSource.volume = resultBGMVolume;
        //bgmSource.clip = result;
        //bgmSource.Play();
    }

    public void SelectSEPlay()
    {
        float selectSEVolume = (PlayerPrefs.GetFloat(audioSEValueKey, selectSeBaseVolume) * selectSeBaseVolume) + selectSeBaseVolume;
        normalSeSource.volume = selectSEVolume;
        normalSeSource.clip = select;
        normalSeSource.PlayOneShot(normalSeSource.clip);
    }

    public void CraneDownSEPlay()
    {
        float craneDownSEVolume = (PlayerPrefs.GetFloat(audioSEValueKey, craneSeBaseVolume) * craneSeBaseVolume) + craneSeBaseVolume;
        craneSeSource.volume = craneDownSEVolume;
        craneSeSource.clip = craneDown;
        craneSeSource.Play();
    }

    public void CraneUpSEPlay()
    {
        float craneUpSEVolume = (PlayerPrefs.GetFloat(audioSEValueKey, craneSeBaseVolume) * craneSeBaseVolume) + craneSeBaseVolume;
        craneSeSource.volume = craneUpSEVolume;
        craneSeSource.clip = craneUp;
        craneSeSource.Play();
    }

    public void ItemGetSEPlay()
    {
        float itemGetSEVolume = (PlayerPrefs.GetFloat(audioSEValueKey, itemGetSeBaseVolume) * itemGetSeBaseVolume) + itemGetSeBaseVolume;
        normalSeSource.volume = itemGetSEVolume;
        normalSeSource.clip = itemGet;
        normalSeSource.PlayOneShot(normalSeSource.clip);
    }

    public void StopSEPlay()
    {
        craneSeSource.Stop();
    }

    public float GetCurrentBGMVolume()
    {
        return bgmSource.volume;
    }

    public float GetCurrentSEVolume()
    {
        return normalSeSource.volume;
    }


    public void UpdateBGMVolume(float newVolume)
    {
        bgmSource.volume = newVolume;
    }

    public void UpdateSEVolume(float volume)
    {
        craneSeSource.volume = volume;
        normalSeSource.volume = volume;
    }

    /// <summary>
    /// ������AudioSource�łȂɂ��Đ����Ă����ꍇ�A�~�߂�
    /// </summary>
    /// <param name="audioSourceName"></param>
    private void StopIfPlaying(AudioSource audioSourceName)
    {
        if (audioSourceName.isPlaying)
        {
            isTitleBgm = false ;
            isGameBgm = false;
            isResultBgm = false;
            audioSourceName.Stop();
        }
    }
}
