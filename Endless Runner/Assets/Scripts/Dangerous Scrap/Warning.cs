using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warning : MonoBehaviour
{
    private GameObject player;
    public float yOffset;
    // Start is called before the first frame update
    void Start()
    {
        player = PlayerReference.player;
        transform.position = new Vector3(transform.position.x, player.transform.position.y - yOffset);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, player.transform.position.y - yOffset);
    }
}
