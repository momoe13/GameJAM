using UnityEngine;

public class GameSceneAudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip upSound;
    [SerializeField] private AudioClip downSound;

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

    public void SoundStop()
    {
        audioSource.Stop();
    }
}
