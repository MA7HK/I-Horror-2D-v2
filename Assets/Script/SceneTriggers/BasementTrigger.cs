using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTrigger : MonoBehaviour
{
    private BoxCollider2D basementTrigger;

    void Start()
    {
        basementTrigger = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.gameObject.CompareTag("Player"))
        {
            SceneManage.Instance.LoadBasement();
            //print("Basement is ready to Load");
        }
    }
}
