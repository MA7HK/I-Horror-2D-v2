

using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Rendering;

public class ThrowMechanic : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public Rigidbody2D rb;
    public float throwForce = 10f;
    public float minRadius = 1f;
    public float maxRadius = 5f;
    public bool throwable = false;
    private bool thrown = false;
    private Vector3 targetPos;
    public bool canThrow = false;
    private Vector3 mousePos;
    public float stopRadius;
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (canThrow)
        {
            if (Input.GetMouseButton(1))
            {
                 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5f));

                float distance = Vector3.Distance(mousePos, transform.position);

                if (distance > minRadius && distance <= maxRadius)
                {
                    throwable = true;
                    DrawTrajectory(mousePos);
                }
                else
                {
                    throwable = false;
                    lineRenderer.positionCount = 0;
                }
            }
            else if (Input.GetMouseButtonUp(1) && throwable)
            {
                // Run function here
                lineRenderer.positionCount = 0;
                ThrowTowards(mousePos);
                throwable = false;
            }
        }

        if(thrown)
        {
            if (Vector3.Distance(transform.position, mousePos) <= stopRadius)
            {
                rb.velocity = Vector3.zero;
                rb.isKinematic = true;
                thrown= false;
            }
        }
    }
    /* public void ThrowTowards(Vector3 targetPosition)
     {
         rb.transform.parent = null;
         rb.GetComponent<Collider2D>().enabled = true;
         rb.isKinematic = false; 
         Vector3 direction = (targetPosition - transform.position).normalized;
         rb.AddForce(direction * throwForce);
     }*/
    public void ThrowTowards(Vector3 targetPosition)
    {
        rb.transform.parent = null;
        rb.GetComponent<Collider2D>().enabled = true;
        rb.isKinematic = false;
        Vector3 direction = (targetPosition - transform.position).normalized;
        rb.velocity = direction * throwForce;
        canThrow = false;
        thrown = true;
        mousePos = lineRenderer.GetPosition(lineRenderer.positionCount - 1);
    } 


    void DrawTrajectory(Vector3 targetPosition)
    {
        Vector3[] points = new Vector3[20];
        lineRenderer.positionCount = points.Length;

        Vector3 direction = (targetPosition - transform.position).normalized;
        Vector3 velocity = direction * throwForce;

        for (int i = 0; i < points.Length; i++)
        {
            float time = i * 0.1f;
            points[i] = transform.position + velocity * time + 0.5f * new Vector3(Physics2D.gravity.x, Physics2D.gravity.y, 0) * time * time;

        }

        lineRenderer.SetPositions(points);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, minRadius);
        Gizmos.DrawWireSphere(transform.position, maxRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, stopRadius);
    }
}
