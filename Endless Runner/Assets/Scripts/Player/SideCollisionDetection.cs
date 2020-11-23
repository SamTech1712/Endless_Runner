using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideCollisionDetection : MonoBehaviour
{
    public bool isCheckingRight;
    public NewPlayerMovement player_Movement;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "ground")
        {
            if (isCheckingRight)
            {
                player_Movement.isBlockedRight = true;
            }
            else
            {
                player_Movement.isBlockedLeft = true;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "ground")
        {
            if (isCheckingRight)
            {
                player_Movement.isBlockedRight = false;
            }
            else
            {
                player_Movement.isBlockedLeft = false;
            }
        }
    }
}
