﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "collectibles")
        {
            collision.gameObject.SetActive(false);
        }
    }
}
