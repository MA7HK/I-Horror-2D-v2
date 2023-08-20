using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering.UI;

public class InteractableObject : MonoBehaviour
{
    public bool _isUnderDetection = false;
    private GameObject _indicationObject;
    public void ShowIndication()
    {
        if (_indicationObject == null)
        {
            GameObject indicationObjectPrefab = (GameObject)Resources.Load("IndicationObject");
            if (indicationObjectPrefab != null)
            {
                _indicationObject = Instantiate(indicationObjectPrefab, transform.position + Vector3.up * 1f, Quaternion.identity);
            }
            else
            {
                Debug.LogError("IndicationObject not found in Resources folder.");
            }
        }
        //_indicationObject.SetActive(true);
        
    }
    public void RemoveIndication()
    {
        //
        if(_indicationObject!= null)
        Destroy(_indicationObject);
        // _indicationObject.SetActive(false);
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

}
