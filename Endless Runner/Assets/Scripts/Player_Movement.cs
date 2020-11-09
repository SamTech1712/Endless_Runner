using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float jumpForce;
    public float gravity;
    
    public Rigidbody2D rb2D;

    private bool isGrounded;

    void Start()
    {
        rb2D = transform.GetComponent <Rigidbody2D>();
        jumpForce = 25f;
        gravity = 5f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            rb2D.AddForce(Vector3.up * jumpForce * 20f);
        }
        rb2D.gravityScale = gravity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "ground")
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "ground")
        {
            isGrounded = false;
        }
    }
}
