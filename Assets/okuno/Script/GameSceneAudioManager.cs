using UnityEngine;

public class GameSceneAudioManager : MonoBehaviour
{
    [Header("通常のSE用")]
    [SerializeField] private AudioSource audioSource;
    [Header("パワーアップのSE用")]
    [SerializeField] private AudioSource powerUpAudioSource;

    [Header("効果音クリップ")]
    //下降SE
    [SerializeField] private AudioClip downSound;
    //上昇SE
    [SerializeField] private AudioClip upSound;

    public void ArmUpSound()
    {
        audioSource.clip = upSound;
        audioSource.Play();
    }

    public void ArmDownSound()
    {
        audioSource.Stop();
        audioSource.clip = downSound;
        audioSource.Play();
    }

    public void PowerUpSound()
    {
        powerUpAudioSource.Play();
    }

    public void SoundStop()
    {
        audioSource.Stop();
    }
}
