using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Movement : MonoBehaviour
{
    #region Variables here:-

    public ParticleSystem dust;

    public float jumpForce;
    public float speed = 1;
    public float velocity = 0;
    public float jumpMovementSlowness;
    public float fallMovementSlowness;
    
    public float groundAccelerationSlowness;
    public float groundBreakSlowness;
    
    
    public Rigidbody2D rb2D;
    

    public bool isGrounded;
    public bool isInJump;
    public bool isBlockedRight;
    public bool isBlockedLeft;
    #endregion

    void Start()
    {
        rb2D = transform.GetComponent<Rigidbody2D>();
        
    }

    void FixedUpdate()
    {
        #region Movement_Code
        if (isGrounded)
        {
            isInJump = false;
        }

        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {

            rb2D.AddForce(new Vector2(0, 1) * jumpForce * 20f, ForceMode2D.Force);
            isInJump = true;

        }

        

        if (isGrounded)
        {
            if (Input.GetKey(KeyCode.D))
            {
                if (velocity > 0)
                {
                    velocity -= speed / groundBreakSlowness;
                    CreateDust();
                }
                else if (velocity > -speed)
                {
                    velocity -= speed / groundAccelerationSlowness;
                }
                else
                {
                    velocity = -speed;
                }
            }
            else if (Input.GetKey(KeyCode.A))
            {
                if (velocity < 0)
                {
                    velocity += speed / groundBreakSlowness;
                }
                else if (velocity < speed)
                {
                    velocity += speed / groundAccelerationSlowness;
                }
                else
                {
                    velocity = speed;
                }
            }
            else
            {
                if (velocity < 0)
                {
                    velocity += speed / groundBreakSlowness;
                }
                else if (velocity > 0)
                {
                    velocity -= speed / groundBreakSlowness;
                }

                if(Mathf.Abs(velocity) < 0.5)
                {
                    velocity = 0;
                }
            }
        }
        else{
            if (Input.GetKey(KeyCode.D))
            {
                if(velocity > -speed)
                {
                    velocity -= speed / jumpMovementSlowness;
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
                    velocity += speed / jumpMovementSlowness;
                } 
                else
                {
                    velocity = speed;
                }
            }
            else if(!isInJump)
            {
                if(velocity < 0)
                {
                    velocity += speed / fallMovementSlowness;
                }
                else if(velocity > 0)
                {
                    velocity -= speed / fallMovementSlowness;
                }

                if ( Mathf.Abs(velocity) < 1)
                {
                    velocity = 0;
                }
            }
            
        }

        if(isBlockedRight && velocity < 0)
        {
            velocity = 0;
        }else if(isBlockedLeft && velocity > 0)
        {
            velocity = 0;
        }

        #endregion
        
        MapCreator.instance.Move(velocity * Time.deltaTime);
    }

    public void CreateDust()
    {
        dust.Play();
    }

    
}
