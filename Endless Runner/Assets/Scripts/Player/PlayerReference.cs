using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReference : MonoBehaviour
{
    public static GameObject player;
    void Awake()
    {
        player = this.gameObject;
    }
}
