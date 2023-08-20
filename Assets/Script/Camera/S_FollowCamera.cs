using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_FollowCamera : MonoBehaviour
{
    public Transform player;
    [Header("Clamp Axis")]
    [SerializeField] float minX;
    [SerializeField] float maxX;
    [SerializeField] float minY;
    [SerializeField] float maxY;
    
    Vector3 CameraAxis;

    // Update is called once per frame
    void Update()
    {
        Vector3 newpos = player.transform.position + new Vector3(0, 1, -5);

        CameraAxis.x = Mathf.Clamp(newpos.x, minX, maxX);
        CameraAxis.y = Mathf.Clamp(newpos.y, minY, maxY);
        CameraAxis.z = -5;

        transform.position = CameraAxis;
    }
}
