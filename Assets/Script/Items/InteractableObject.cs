using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Rendering.UI;
using UnityEngine.UI;

public enum interactableObjectType { item, door,hidePlace,triggerPoint}
[RequireComponent(typeof(Collider2D))]
public class InteractableObject : MonoBehaviour
{
    public interactableObjectType ObjectType;
    public string _itemName="";
    public bool _isUnderDetection = false;
    public Transform _UIpos;
    private GameObject _indicationObject;
    public Sprite _objectSprite;
    public string UI_indication_name = "IndicationObject";
    private void Start()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }
    public void ShowIndication()
    {
        if (_indicationObject == null)
        {
            GameObject indicationObjectPrefab = (GameObject)Resources.Load(UI_indication_name);
            if (indicationObjectPrefab != null)
            {
                _indicationObject = Instantiate(indicationObjectPrefab,_UIpos.position, Quaternion.identity,transform);
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
