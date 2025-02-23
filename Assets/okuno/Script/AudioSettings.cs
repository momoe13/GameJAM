using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    [SerializeField] private Slider bgmSlider;
    [SerializeField] private Slider seSlider;

    private const string audioBGMValueKey = "BGMValue";
    private const string audioSEValueKey = "SEValue";

    private void Start()
    {
        float savedBGMVolume = PlayerPrefs.GetFloat(audioBGMValueKey, 1f);
        float savedSEVolume = PlayerPrefs.GetFloat (audioSEValueKey, 1f);

        AudioManager.Instance.UpdateBGMVolume(savedBGMVolume);
        AudioManager.Instance.UpdateSEVolume(savedSEVolume);

        bgmSlider.value = 0;
        seSlider.value = 0;

        bgmSlider.onValueChanged.AddListener(SetBGMVolume);
        seSlider.onValueChanged.AddListener(SetSEVolume);
    }

    public void SetBGMVolume(float value)
    {
        // åªç›ÇÃâπó Ç©ÇÁëäëŒìIÇ…ïœâª
        float currentVolume = AudioManager.Instance.GetCurrentBGMVolume();
        float newVolume = currentVolume + value;


        // âπó ê›íËÇ∆ï€ë∂
        AudioManager.Instance.UpdateBGMVolume(newVolume);
        PlayerPrefs.SetFloat(audioBGMValueKey, newVolume);
        PlayerPrefs.Save();
    }

    public void SetSEVolume(float value)
    {
        float currentVolume = AudioManager.Instance.GetCurrentSEVolume();
        float newVolume = currentVolume + value;

        AudioManager.Instance.UpdateSEVolume(newVolume);
        PlayerPrefs.SetFloat(audioSEValueKey, newVolume);
        PlayerPrefs.Save();
    }
}
