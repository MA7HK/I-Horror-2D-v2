using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

public class Enemy : MonoBehaviour
{

    public bool isSeen;
    public float speed;
    public float rageSpeed;
    public Transform player;
    public UnityEvent  PlayerCaught;
    public bool _playerHide=false;
    public float _followRadius;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if(PlayerCaught!=null) PlayerCaught.Invoke();
        }
    }
    public virtual void PlayerHide()
    {

    }
    public virtual void Die()
    { }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _followRadius);
    }

}
