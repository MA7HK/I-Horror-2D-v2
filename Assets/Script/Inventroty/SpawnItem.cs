using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    public GameObject item;
    private Transform playerPos;

    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void SpawnDroppedItem()
    {
        Vector2 P_Pos = new Vector2(playerPos.position.x, playerPos.position.y + 3);
        Instantiate(item, P_Pos, Quaternion.identity);
    }
    
}
