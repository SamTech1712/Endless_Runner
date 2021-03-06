﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomCollisionDetection : MonoBehaviour
{
    public NewPlayerMovement player_Movement;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "ground")
        {
            player_Movement.isGrounded = true;
            player_Movement.CreateDust();
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "ground")
        {
            player_Movement.isGrounded = false;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "ground")
        {
            player_Movement.isGrounded = true;
        }
    }
}
