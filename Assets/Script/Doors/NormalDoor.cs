using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalDoor : InteractableObject
{

    public GameObject closedObject;
    public GameObject openedObject;
    public bool isOpen = false;
    private void Awake()
    {
        closedObject.SetActive(true);
        openedObject.SetActive(false);
    }
    public void DoorAction()
    {
        isOpen = !isOpen;
        closedObject.SetActive(!isOpen);
        openedObject.SetActive(isOpen);
    }
    public override void ItemFunction()
    {
        DoorAction();
    }

}
