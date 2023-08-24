using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerDoor : InteractableObject
{

    public  UnityEvent action;
    public override void ItemFunction()
    {
        action.Invoke();
    }

}
