using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "collectibles")
        {
            Destroy(collision.gameObject);
            Player_Movement.gravity += 0.5f;
        }
        
    }
}
