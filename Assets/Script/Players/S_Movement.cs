using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class S_Movement : MonoBehaviour
{
    private float speed;
    private Vector2 movement;
    private Vector2 moveDirection;
    private Vector2 lastMoveDirection;
    private Rigidbody2D rb;
    [SerializeField] private Animator animator;

    PhotonView p_view;

    [Header("speeds")]
    public float _initialSpeed;
    public float _sprintSpeed;

    /*private void Start()
    {
        p_view = GetComponent<PhotonView>();
    }*/
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        moveDirection = new Vector2(movement.x, movement.y).normalized;

        if((movement.x == 0  && movement.y == 0) && moveDirection.x != 0 || moveDirection.y != 0)
        {
            lastMoveDirection = moveDirection;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        { speed = _sprintSpeed; }
        else
        { speed = _initialSpeed; }

        animator.SetFloat("Horizontal", moveDirection.x);
        animator.SetFloat("Vertical", moveDirection.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        animator.SetFloat("LastMoveX", lastMoveDirection.x);
        animator.SetFloat("LastMoveY", lastMoveDirection.y);

    }

    private void FixedUpdate()
    {
        Vector2 velocity = movement.normalized * speed;
        rb.velocity = velocity;

    }
}