using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class HealthItem : InteractableObject
{

    public string _doorName;
    public GameObject _keyObject;
    public override void ItemFunction()
    {
        // 
          /*        Debug.Log("Key picked");
        Debug.Log("Door key found: "+ _doorName);*/
        Destroy(_keyObject);
    }
}
