using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Movement : MonoBehaviour
{
    #region Variables here:-
    public static float gravity=1;
    public float GravityTime=1f;
    public float gravityScale=0.1f;
    public float jumpForce;
    public float speed = 1;
    public float velocity = 0;
    public float airMovementSlowness;
    
    
    public Rigidbody2D rb2D;

    public bool isGrounded;
    public bool isBlockedRight;
    public bool isBlockedLeft;
    #endregion

    void Start()
    {
        rb2D = transform.GetComponent<Rigidbody2D>();
        StartCoroutine(changeGravity());
    }

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

        if(isBlockedRight && velocity < 0)
        {
            velocity = 0;
        }else if(isBlockedLeft && velocity > 0)
        {
            velocity = 0;
        }

        #endregion
        rb2D.gravityScale = gravity;
        MapCreator.instance.Move(velocity * Time.deltaTime);
    }

    
    IEnumerator changeGravity()
    {
        while (true)
        {
            if (gravity > 1.8)
            {
                yield return new WaitForSeconds(GravityTime);
                gravity -= gravityScale;
                //Debug.Log("Coroutine working");
            }
            
            else if (gravity <= 1.8)
            {
                //change these else if statement for the restart of game
                SceneManager.LoadScene("Endless Runner");
            }
        }
    }
}
