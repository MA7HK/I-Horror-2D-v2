using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UIElements;

public class Trapper : Enemy
{
    public float LifeTime;
    public float stareTime=1f;
    public bool ischasing=false;
   
    public List<GameObject> visibleObjects= new List<GameObject>();
    private bool _isvisible = false;
    private void Start()
    {
        _enemySprite.DOFade(1f, 1f).From(0f);
        foreach (GameObject g in visibleObjects) g.SetActive(false);
    }
    private void Update()
    {
        if(isSeen )
        {
            if (!_isvisible)
            {
                foreach (GameObject g in visibleObjects) g.SetActive(true);
                _isvisible = true;
            }
            if (stareTime > 0f) stareTime -= Time.deltaTime;
            else if(stareTime<=0f && !ischasing)
            {
                //start chasing effect. jumpscare
                transform.DOShakePosition(.25f,1, 7,90).OnComplete(() =>
                {
                ischasing = true;
                    if (player.TryGetComponent<PlayerHealth>(out PlayerHealth playerh))
                    {
                        playerh.addEnemy(this);
                    }
                });
            }
        }
        if (ischasing && !_playerHide)
        {
           
            //find player;
            ChasePlayer();
        }
        if(_playerHide)
        {
            /*if (player.TryGetComponent<PlayerHealth>(out PlayerHealth playerH))
            {
                //playerH.isDecreasingHealth = false;
                playerH.removeFromEnemyList(this);
            }*/
            player = null;
            if (LifeTime <= 0f)
                Die();
            LifeTime -= Time.deltaTime;
        }
    }
    public SpriteRenderer _enemySprite;
    public override void Die()
    {
        _enemySprite.DOFade(0f, 1f).OnComplete(() =>{
            Destroy(gameObject);
        });
        
    }
    void ChasePlayer()
    {
        if (Vector3.Distance(transform.position, player.position) < _followRadius)
        {
            if (player.TryGetComponent<PlayerHealth>(out PlayerHealth playerh))
            {
                playerh.addEnemy(this); 
            }
            // calculate the direction towards the target
            Vector3 direction = (player.position - transform.position).normalized;

            // move the game object towards the target
            if (isSeen)
                transform.position += direction * rageSpeed * Time.deltaTime;
            else
                transform.position += direction * speed * Time.deltaTime;
        }
        else
        {
            if(player.TryGetComponent<PlayerHealth>(out PlayerHealth playerH))
            {
                //playerH.isDecreasingHealth = false;
                playerH.removeFromEnemyList(this); 
            }
            _playerHide = true;
        }

    }
    public override void PlayerHide()
    {
        
    }

}
