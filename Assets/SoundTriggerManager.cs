using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTriggerManager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("STri"))
        {
            int ran = Random.Range(0, 17);
            S_SoundManager.SFX.HitSound_1(ran);
        }
    }
}
