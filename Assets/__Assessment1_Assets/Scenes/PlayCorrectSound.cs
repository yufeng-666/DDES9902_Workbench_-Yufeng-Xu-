using UnityEngine;

public class PlayCorrectSound : MonoBehaviour
{
    
    public AudioClip correctSound;
    private AudioSource audioSource;

    void Start()
    {
        
        audioSource = gameObject.AddComponent<AudioSource>();
    }

   
    public void PlaySound()
    {
        if (correctSound != null)
        {
            audioSource.PlayOneShot(correctSound);
        }
    }
}