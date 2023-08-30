using Photon.Pun.Demo.Cockpit.Forms;
using Photon.Pun.Demo.SlotRacer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    private void Awake()
    {
    }
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
                S_SoundManager.SFX.PickUpSound();
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
    public void DiscardItem(string s)
    {
        for(int i=0;i<slotItems.Length;i++)
        {
            if (slotItems[i] == s)
            {
                DiscardItem(i); return;
            }
        }
        Debug.Log("Item not found");
    }
    public void DiscardItem(int i)
    {
        if (!_slotBools_isAvailable[i])
        {

        //instantiate the particular item 
        _slotBools_isAvailable[i] = true;
        slotItems[i] = null;

            _slotImages[i].sprite = null;
            //   CollectEffect(io.transform.position, _slotImages[i].rectTransform);
            _slotBools_isAvailable[i] = true;
            Color c = _slotImages[i].color;
            c.a = 0f;
            _slotImages[i].color = c;

        }
        else
        {
            Debug.Log("Nothing in the slot");
        }

    }

}
