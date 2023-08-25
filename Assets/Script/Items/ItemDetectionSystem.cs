using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.Rendering;

public class ItemDetectionSystem : MonoBehaviour
{
    public LayerMask detectionLayer;
    public float detectionRadius = 5f;
    public float detectionDuration = 10f; // The duration for which the detection is active
    private float detectionDurationCounter;

    public InteractableObject _currentItemDetected;
    public Inventory _Inventory;
    public event Action<InteractableObject> _itemPickedUp;

    [Header("Hiding mechanics")]
    public HidingMechanics _hideSystem;
    private void Start()
    {
        _Inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
    }
    private void Update()
    {

        if (detectionDurationCounter > detectionDuration)
        {
            Collider2D detectedObject = Physics2D.OverlapCircle(transform.position, detectionRadius, detectionLayer);
            if (detectedObject == null)
            {
                if (_currentItemDetected != null)
                {
                    _currentItemDetected._isUnderDetection = false;
                    _currentItemDetected = null;
                }
                return;
            }


            if (_currentItemDetected == null)
            {
                _currentItemDetected = detectedObject.GetComponent<InteractableObject>();
                if (_currentItemDetected != null)
                {
                    _currentItemDetected._isUnderDetection = true;
                }
            }
        }
        else detectionDurationCounter += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.F) && _currentItemDetected)
        {
            interactableObjectType type = _currentItemDetected.ObjectType;
            switch(type)
            {
                case interactableObjectType.item:
                    {
                        if (_Inventory.isSlotAvailable())
                        {
                            _currentItemDetected.ItemFunction();
                            _itemPickedUp?.Invoke(_currentItemDetected);
                            _currentItemDetected = null;
                        }
                        else if (!_Inventory.isSlotAvailable() && _currentItemDetected)
                        {
                            Debug.Log("slot is full");
                            _currentItemDetected.shakeUI();
                        }
                    }
                    break;
                case interactableObjectType.door:
                    {
                        _currentItemDetected.ItemFunction();
                    }
                    break;
              
            }
           
        }

         if (Input.GetKeyDown(KeyCode.E) && _currentItemDetected)
        {
            interactableObjectType type = _currentItemDetected.ObjectType;
            if(type==interactableObjectType.hidePlace)
            {
                if (_hideSystem.isHiding) _hideSystem.UnHide();
                else _hideSystem.Hide();
            }
        }
        }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
