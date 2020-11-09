using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float jumpForce;
    public float gravity;
    public float speed = 1;
    
    public Rigidbody2D rb2D;

    public bool isGrounded;

    void Start()
    {
        rb2D = transform.GetComponent <Rigidbody2D>();
        //don't have to do this because it can easily be set and changed in the inspector
        //jumpForce = 25f;
        //gravity = 5f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {

            rb2D.AddForce(new Vector2(0, 1) * jumpForce * 20f, ForceMode2D.Force);

        }
        rb2D.gravityScale = gravity;

        if (Input.GetKey(KeyCode.D))
        {
            MapCreator.instance.Move(-speed * Time.deltaTime);
        } else if (Input.GetKey(KeyCode.A))
        {
            MapCreator.instance.Move(speed * Time.deltaTime);
        }
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
