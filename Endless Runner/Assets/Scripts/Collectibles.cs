using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    public float gravityImpact;
    public Player_Movement player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player = collision.GetComponent<Player_Movement>();
            player.AddGravity(gravityImpact);
            gameObject.SetActive(false);
        }
    }
}
