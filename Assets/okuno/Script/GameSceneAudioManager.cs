using UnityEngine;

public class GameSceneAudioManager : MonoBehaviour
{
    [Header("�ʏ��SE�p")]
    [SerializeField] private AudioSource audioSource;
    [Header("�p���[�A�b�v��SE�p")]
    [SerializeField] private AudioSource powerUpAudioSource;

    [Header("���ʉ��N���b�v")]
    //���~SE
    [SerializeField] private AudioClip downSound;
    //�㏸SE
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
