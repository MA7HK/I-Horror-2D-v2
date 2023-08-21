using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private Inventory inventory;
    public GameObject ItemButtom;

    /*private void Awake()
    {
        DontDestroyOnLoad(this);
    }*/

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        DontDestroyOnLoad(this);
       
    }

    void OnTriggerEnter2D(Collider2D Other)
    {
        if(Other.CompareTag("Player"))
        {
            for(int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                {
                    inventory.isFull[i] = true;
                    Instantiate(ItemButtom, inventory.slots[i].transform, false);
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}
