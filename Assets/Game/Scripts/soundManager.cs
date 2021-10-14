using UnityEngine;

public class soundManager : MonoBehaviour
{
    public static soundManager instance;

    AudioSource audioSource;

    [Header ("SOUNDS")]
    public AudioClip playerSound;
    public AudioClip diamondSound;
    public AudioClip playerSpawnSound;
    public AudioClip gameOverSound;
    public AudioClip winSound;
    public AudioClip starsound;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }

   

    public void PlayerSound()
    {
        audioSource.PlayOneShot(playerSound);
    }

    public void DiamondSound()
    {
        audioSource.PlayOneShot(diamondSound);
    }

    public void PlayerSpawnSound()
    {
        audioSource.PlayOneShot(playerSpawnSound);
    }

    public void GameOverSound()
    {
        audioSource.PlayOneShot(gameOverSound);
    }
    public void WinSound()
    {
        audioSource.PlayOneShot(winSound);
    }

    public void StarSound()
    {
        audioSource.PlayOneShot(starsound);
    }

}
