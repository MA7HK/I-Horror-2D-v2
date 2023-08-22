using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Rendering.UI;
using UnityEngine.UI;

[RequireComponent(typeof(Collider2D))]
public class InteractableObject : MonoBehaviour
{
    public string _itemName="";
    public bool _isUnderDetection = false;
    private GameObject _indicationObject;
    public Sprite _objectSprite;
    private void Start()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }
    public void ShowIndication()
    {
        if (_indicationObject == null)
        {
            GameObject indicationObjectPrefab = (GameObject)Resources.Load("IndicationObject");
            if (indicationObjectPrefab != null)
            {
                _indicationObject = Instantiate(indicationObjectPrefab, transform.position + Vector3.up * 1f, Quaternion.identity,transform);
            }
            else
            {
                Debug.LogError("IndicationObject not found in Resources folder.");
            }
        }
        //_indicationObject.SetActive(true);
        
    }
    public Color LockedUicolor;
    public void RemoveIndication()
    {
        //
        if(_indicationObject!= null)
        Destroy(_indicationObject);
        // _indicationObject.SetActive(false);
    }
    public void shakeUI()
    {
        if(_indicationObject)
        {
            Image _im = _indicationObject.GetComponentInChildren<Button>().image;
            _indicationObject.GetComponent<RectTransform>().DOShakeScale(.1f, .5f, 4, 90).OnStart(() =>
            {
                _im.color = LockedUicolor;
            }).OnComplete(() =>
            {
                _im.color = Color.white;
            });
        }
    }

    private void FixedUpdate()
    {
        if(_isUnderDetection)
        {
            ShowIndication();
        }
        else
        {
            RemoveIndication();
        }
    }
     public virtual void  ItemFunction()
    {
        // item function here

        Debug.Log("Item picked up");

    }
}
