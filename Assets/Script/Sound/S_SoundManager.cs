using UnityEngine.SceneManagement;
using UnityEngine;

public class S_SoundManager : MonoBehaviour
{
    public static S_SoundManager SFX;

    public AudioSource audioSource;

    [Header("Player")]
    public AudioClip WalkingSfx;
    public AudioClip heartBeat;
    public AudioClip PickupSfx;

    [Header("Door")]
    public AudioClip OuterdoorSfx;

    [Header("Ambience")]
    public AudioClip AmbienceSfx;
    public AudioClip HallAmbienceSfx;
    public AudioClip BasementSfx;
    public AudioClip BasementUpperRoomSfx;
    
    [Header("Thunder")]
    public AudioClip[] thundersfx;

    [Header("Ghosts")]
    public AudioClip Hit_1;
    

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
    private void Start()
    {
        audioSource.PlayOneShot(AmbienceSfx);
        audioSource.volume = 0.1f;
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

    public void PlayerWalking()
    {
        audioSource.PlayOneShot(WalkingSfx);
        
    }

    public void HallSound()
    {
        if(SceneManager.GetActiveScene().buildIndex == 3)
        {
            audioSource.PlayOneShot(HallAmbienceSfx);
        }
    }
    
    public void BasementSound()
    {
        if(SceneManager.GetActiveScene().buildIndex == 4)
        {
            audioSource.PlayOneShot(BasementSfx);
        }
    }
    
    public void BasementUpperRoomSound()
    {
        if(SceneManager.GetActiveScene().buildIndex == 5)
        {
            audioSource.PlayOneShot(BasementUpperRoomSfx);
        }
    }

    public void OuterDoorSound(bool isOpen) 
    {
        if(isOpen) 
        {
            audioSource.PlayOneShot(OuterdoorSfx);
            audioSource.volume = 0.2f;
        }
        else if(!isOpen)
        {
            audioSource.PlayOneShot(OuterdoorSfx);
            audioSource.volume = 0.2f;
        }
    }

    public void PickUpSound()
    {
        audioSource.PlayOneShot(PickupSfx);
        audioSource.volume = 1.5f;
    }

    public void HitSound()
    {
        audioSource.PlayOneShot(Hit_1);
        audioSource.volume = 1.5f;
    }
}
