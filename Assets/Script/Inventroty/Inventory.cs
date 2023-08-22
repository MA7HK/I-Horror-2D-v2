using Photon.Pun.Demo.Cockpit.Forms;
using Photon.Pun.Demo.SlotRacer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{


    private void Start()
    {
        GameObject.FindGameObjectWithTag("ItemDetection").GetComponent<ItemDetectionSystem>()._itemPickedUp += InsertItem;
       // for (int i = 0; i < _slotBools_isAvailable.Length; i++) _slotBools_isAvailable[i] = true;
    }

   
    public string[] slotItems;
    public bool[] _slotBools_isAvailable;
    public List<Image> _slotImages = new List<Image>();
    /*public Sprite _keyImage;
    public Sprite _firstAidBoxImage;
    public Sprite _stoneImage;*/
    
    public bool isSlotAvailable()
    {
        for(int i=0;i<_slotBools_isAvailable.Length;i++) { if (_slotBools_isAvailable[i]) return true; }
        return false;
    }
    public void InsertItem(InteractableObject io)
    {
        Sprite sp = io._objectSprite;
        
        for(int i=0;i<_slotImages.Count;i++)
        {
            if (_slotBools_isAvailable[i])
            {
                slotItems[i] = io._itemName;
                _slotImages[i].sprite = sp;
             //   CollectEffect(io.transform.position, _slotImages[i].rectTransform);
                _slotBools_isAvailable[i] = false;
                Color c = _slotImages[i].color;
                c.a = 1f;
                _slotImages[i].color = c;
                return;
            }
        }
        Debug.Log("No space");
    }
    public void CollectEffect(Vector3 objectPosition, RectTransform targetPos)
    {
         //
    }
    public void DiscardItem(string itemName)
    {
        //check the items
        //change the opacity back and remove item.
    }

}
