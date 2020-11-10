using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomCollisionDetection : MonoBehaviour
{
    public Player_Movement player_Movement;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "ground")
        {
            player_Movement.isGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "ground")
        {
            player_Movement.isGrounded = false;
        }
    }
}
