using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ripple : MonoBehaviour
{

    private Animator rippleAnim;
    private SpriteRenderer rippleRenderer;
    public int Time;

    private void Start()
    {
        rippleAnim = GetComponent<Animator>();
        rippleRenderer = GetComponent<SpriteRenderer>();
        rippleAnim.enabled = false;
        rippleRenderer.enabled = false;
    }

    void Update()
    {
       
        Invoke("playAnim", Time);
    }

    void playAnim()
    {
        rippleAnim.enabled = true;
        rippleRenderer.enabled = true;
    }    

}
