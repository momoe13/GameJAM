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
    [Header("タイトル")]
    [SerializeField] private AudioClip title;
    [SerializeField] private float titleBGMBaseVolume;
    [Header("ゲーム")]
    [SerializeField] private AudioClip game;
    [SerializeField] private float gameBGMBaseVolume;
    [Header("リザルト")]
    [SerializeField] private AudioClip result;
    [SerializeField] private float resultBGMBaseVolume;
    [Header("--------SE--------")]
    [Header("セレクト")]
    [SerializeField] private AudioClip select;
    [SerializeField] private float selectSeBaseVolume;
    [Header("画面遷移SE")]
    [SerializeField] private AudioClip fade;
    [SerializeField] private float fadeSeBaseVolume;
    [Header("クレーンSE")]
    [SerializeField] private AudioClip craneDown;
    [SerializeField] private AudioClip craneUp;
    [SerializeField] private float craneSeBaseVolume;
    [Header("アイテム獲得")]
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

        //第二引数にはセットする値
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
            //ゲームBGM再生
            GameBGMPlay();
        }
        else
        {
            //リザルトBGM再生
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
        //再生中なら止める
        StopIfPlaying(bgmSource);
        isTitleBgm = true;
        //タイトルのBGMクリップをBGMSourceで再生
        float titleBGMVolume = (PlayerPrefs.GetFloat(audioBGMValueKey, titleBGMBaseVolume) * titleBGMBaseVolume) + titleBGMBaseVolume;

        bgmSource.volume = titleBGMVolume;
        //AudioSurceのClipにタイトルのClipを格納
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
    /// 引数のAudioSourceでなにか再生していた場合、止める
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
