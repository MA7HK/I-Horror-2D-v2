using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallTrigger : MonoBehaviour
{
    private BoxCollider2D hallTrigger;
        
    void Start()
    {
        hallTrigger = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.gameObject.CompareTag("Player"))
        {
            SceneManage.Instance.LoadHall();
            print("Hall is ready to Load");
        }
    }
}
