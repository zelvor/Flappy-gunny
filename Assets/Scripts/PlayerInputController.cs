using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    [SerializeField]
    private float jumpForce = 50f;

    private Rigidbody2D rb;
    private bool onFloor;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Jump(float keyHoldTime)
    {
        if (onFloor)
        {
            float jumpVelocityX = Mathf.Sqrt(2 * jumpForce * keyHoldTime * Mathf.Cos(Mathf.PI / 3));
            float jumpVelocityY = Mathf.Sqrt(2 * jumpForce * keyHoldTime * Mathf.Sin(Mathf.PI / 3));

            rb.velocity = new Vector2(jumpVelocityX, jumpVelocityY);

            // Set onFloor to false so the player can't jump again until they touch the ground
            onFloor = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            onFloor = true;
        }
    }

}
