using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    public float gravityImpact;
    public PlayerGravity player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player = collision.GetComponent<PlayerGravity>();
            player.AddGravity(gravityImpact);
            gameObject.SetActive(false);
        }
    }
}
