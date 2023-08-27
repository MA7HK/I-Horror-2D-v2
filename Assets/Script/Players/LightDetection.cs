using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDetection : MonoBehaviour
{
    public Transform player;
    private void Start()
    {
        Physics2D.queriesStartInColliders = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<OutlineScript>(out OutlineScript s))
        {
            //RaycastHit2D hit = Physics2D.Raycast(transform.position, collision.transform.position - transform.position,Vector3.Distance(transform.position,collision.transform.position));
            //if (hit.collider == collision)
            {
                s.Outline(true);
            }
        }
        else if(collision.TryGetComponent<Enemy>(out Enemy e))
        {
            e.player = this.player;
            e.isSeen = true;
            e._playerHide = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<OutlineScript>(out OutlineScript s))
        {
            s.Outline(false);
        }
        else if (collision.TryGetComponent<Enemy>(out Enemy e))
        {
            e.player = this.player;
            e.isSeen = false;
        }
    }
}


       