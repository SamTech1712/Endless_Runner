using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Projectile : MonoBehaviour
{
    

    public float gravityChange;
    
    public Rigidbody2D rb2D;

    public GameObject explosion;

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
            Instantiate(explosion, transform.position, Quaternion.identity);
            StartCoroutine(GameOverDelay());
        }
    }

    IEnumerator GameOverDelay()
    {
        yield return new WaitForSeconds(1);
        GameOverMenu.instance.GameOver();
    }
}
