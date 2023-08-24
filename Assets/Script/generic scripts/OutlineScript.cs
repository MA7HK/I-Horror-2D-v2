using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineScript : MonoBehaviour
{

    public GameObject _outlineObject;
    private void Awake()
    {
        _outlineObject.SetActive(false);
    }

    private void Start()
    {
        //_outlineObject.SetActive(false);
    }
    public void Outline(bool show)
    {
        _outlineObject.SetActive(show);
    }

}
