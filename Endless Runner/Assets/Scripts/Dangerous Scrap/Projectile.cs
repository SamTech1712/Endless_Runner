using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float gravityChange;
    
    public Rigidbody2D rb2D;

    private void Start()
    {
        rb2D.gravityScale = 0;
    }

    private void FixedUpdate()
    {
        rb2D.gravityScale -= gravityChange;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
            //game over or loose lives;
            Debug.LogWarning("Game Over");
        }
    }
}
