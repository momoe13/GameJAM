using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [Header("AudioSource")]
    [SerializeField] private AudioSource bgmSource;
    [SerializeField] private AudioSource seSource;

    [Header("BGM")]
    [SerializeField] private AudioClip title;
    [SerializeField] private AudioClip game;
    [SerializeField] private AudioClip result;
    [Header("SE")]
    [SerializeField] private AudioClip select;
    [SerializeField] private AudioClip fade;
    [SerializeField] private AudioClip craneDown;
    [SerializeField] private AudioClip craneUp;
    [SerializeField] private AudioClip itemGet;

    public const string audioBGMValueKey = "BGMValue";
    public const string audioSEValueKey = "SEValue";


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
        PlayerPrefs.SetFloat(audioBGMValueKey, 0.01f);
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
        }
        else
        {
            //���U���gBGM�Đ�
        }
    }

    public void TitleBGMPlay()
    {
        //�^�C�g����BGM�N���b�v��BGMSource�ōĐ�
        //
        float titleBGMVolume = PlayerPrefs.GetFloat(audioBGMValueKey, 0.01f);

        bgmSource.volume = titleBGMVolume;
        //AudioSurce��Clip�Ƀ^�C�g����Clip���i�[
        bgmSource.clip = title;
        bgmSource.Play();
    }
}
