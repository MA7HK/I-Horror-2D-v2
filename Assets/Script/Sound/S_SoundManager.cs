using UnityEngine;

public class S_SoundManager : MonoBehaviour
{
    public static S_SoundManager SFX;

    public AudioSource audioSource;
    
    [Header("Thunder")]
    public AudioClip[] thundersfx;

    private void Awake()
    {
        if(SFX != null && SFX != this)
        {
            Destroy(this);
        }
        else
        {
            SFX = this;
        }
    }

    public void ThunderSfx()
    {
        int ranInd = Random.Range(0, 3);
        audioSource.PlayOneShot(thundersfx[ranInd]);
    }

}
