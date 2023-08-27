using UnityEngine;

public class S_SoundManager : MonoBehaviour
{
    public static S_SoundManager SFX;

    public AudioSource audioSource;
    
    [Header("Thunder")]
    public AudioClip[] thundersfx;

    [Header("Player")]
    public AudioClip heartBeat;

    private void Awake()
    {
        if(SFX != null && SFX != this)
        {
            Destroy(this);
        }
        else
        {
            SFX = this;
            DontDestroyOnLoad(this);
        }
    }

    public void ThunderSfx()
    {
        int ranInd = Random.Range(0, 3);
        audioSource.PlayOneShot(thundersfx[ranInd]);
        audioSource.volume = 0.6f;
    }

    public void HeartBeat()
    {
        audioSource.loop = true;
        audioSource.volume = 1.0f;
        audioSource.PlayOneShot(heartBeat);
    }
}
