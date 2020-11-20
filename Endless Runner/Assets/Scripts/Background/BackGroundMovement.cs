using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMovement : MonoBehaviour
{
    public GameObject player;
    Player_Movement player_Movement;
    public float xMultiplier;
    public float yMultiplier;
    public float yOffset;
    public bool isCheckingPosition;
    public float waitTime;
    public string tag;
    bool isRunningCheck = true;
    // Start is called before the first frame update
    void Start()
    {
        player = PlayerReference.player;
        player_Movement = player.GetComponent<Player_Movement>();
        StartCoroutine(checkPosition());
    }

    // Update is called once per frame
    void Update()
    {
        float x = transform.position.x + player_Movement.velocity * xMultiplier * Time.deltaTime;
        float y = player.transform.position.y * yMultiplier + yOffset;
        transform.position = new Vector3(x, y, transform.position.y);
    }

    IEnumerator checkPosition()
    {
        isRunningCheck = true;
        while (isCheckingPosition)
        {
            if(transform.position.x < BackGroundManager.instance.spawnX && isRunningCheck)
            {
                BackGroundManager.instance.setupNewBackground(transform.position.x + BackGroundManager.instance.backgroundWidth, tag);
                isRunningCheck = false;
            }
            yield return new WaitForSeconds(waitTime);

            if(transform.position.x < BackGroundManager.instance.despawnX)
            {
                BackGroundManager.instance.deleteBackgroundSegment(gameObject);
            }
        }
    }
}
