using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDetectionSystem : MonoBehaviour
{
    public LayerMask detectionLayer;
    public float detectionRadius = 5f;
    public float detectionDuration = 10f; // The duration for which the detection is active
    private float detectionDurationCounter;

    public InteractableObject _currentItemDetected;
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
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
