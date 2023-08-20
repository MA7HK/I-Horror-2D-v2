using UnityEngine;


public class S_Lighting : MonoBehaviour
{

    private float Timer;
    private float delayTime;

    public Animator animator;
    
    void Update()
    {
        Counter();
        delayTime = Random.Range(1, 30);

    }

    void Counter()
    {
        if (Timer == 0)
        {
            animator.SetBool("Lighting", true);
            Timer = delayTime;
            //Debug.Log("True");
            S_SoundManager.SFX.ThunderSfx();
        }
        else
        {
            animator.SetBool("Lighting", false);
        }

        if (Timer > 0)
        {
            Timer -= Time.deltaTime;
            Timer = Mathf.Max(Timer, 0);
            //Debug.Log("false");
        }
        
    }

    
}
