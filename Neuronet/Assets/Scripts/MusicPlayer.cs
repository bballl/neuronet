using UnityEngine;

/// <summary>
/// Проигрывает фоновую музыку.
/// </summary>
public class MusicPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip[] clips;
    private AudioSource audioSource;
    private int index;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = clips[0];
        audioSource.Play();
    }

    private void FixedUpdate()
    {
        ChangeClip();
    }

    private void ChangeClip()
    {
        if (audioSource.isPlaying)
            return;
        
        index++;
        if(index >= clips.Length)
            index= 0;
        
        audioSource.clip = clips[index];
        audioSource.Play();
    }
}
