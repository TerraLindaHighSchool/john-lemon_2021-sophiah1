﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb;
    private Vector3 moveDirection;
    private Quaternion rotation;
    private bool IsWalking;

    [SerializeField] private float turnSpeed = 20f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        rotation = Quaternion.identity;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Get user input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        // Use user input to set direction player will move
        moveDirection.Set(horizontal, 0f, vertical);
        moveDirection.Normalize();
        // Set animator to walking or idle depending on user input
        IsWalking = !(Mathf.Approximately(horizontal, 0f) && Mathf.Approximately(vertical, 0f));
        animator.SetBool("IsWalking", IsWalking);
        // Assign rotation towards move direction
        Vector3 desiredDirection = Vector3.RotateTowards(transform.forward, moveDirection, turnSpeed * Time.deltaTime, 0f);
        rotation = Quaternion.LookRotation(desiredDirection);
    }
    // Animator event
    private void OnAnimatorMove()
    {
        rb.MovePosition(rb.position + moveDirection * animator.deltaPosition.magnitude);
        rb.MoveRotation(rotation);
    }
}