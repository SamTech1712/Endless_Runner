using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float jumpForce;
    public float speed = 1;
    public float velocity = 0;
    public float airMovementSlowness;
    
    
    public Rigidbody2D rb2D;

    public bool isGrounded;

    void Start()
    {
        rb2D = transform.GetComponent <Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        #region Movement_Code
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {

            rb2D.AddForce(new Vector2(0, 1) * jumpForce * 20f, ForceMode2D.Force);

        }

        if (isGrounded)
        {
            if (Input.GetKey(KeyCode.D))
            {
                velocity = -speed;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                velocity = speed;
            }
            else
            {
                velocity = 0;
            }

        }else{
            if (Input.GetKey(KeyCode.D))
            {
                if(velocity > -speed)
                {
                    velocity -= airMovementSlowness;
                }
                else
                {
                    velocity = -speed;
                }
            }
            else if (Input.GetKey(KeyCode.A))
            {
                if(velocity < speed)
                {
                    velocity += airMovementSlowness;
                } 
                else
                {
                    velocity = speed;
                }
            }
        }
        #endregion
        MapCreator.instance.Move(velocity * Time.deltaTime);
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
