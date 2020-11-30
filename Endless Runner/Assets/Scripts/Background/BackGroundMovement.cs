using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMovement : MonoBehaviour
{
    public GameObject player;
    NewPlayerMovement playerMovement;
    public float xMultiplier;
    public float yMultiplier;
    public float yOffset;
    public bool isCheckingPosition;
    public float waitTime;
    public string tag;
    

    public bool isFirstInRow = false;

    public bool firstTimeEnabling = true;
    // Start is called before the first frame update
    void Start()
    {
        player = PlayerReference.player;
        playerMovement = player.GetComponent<NewPlayerMovement>();
        StartCoroutine(checkPosition());
    }

    private void OnEnable()
    {
        if (!firstTimeEnabling)
        {
            isFirstInRow = true;
        }
        firstTimeEnabling = false;
    }

    // Update is called once per frame
    void Update()
    {
        float x = transform.position.x + playerMovement.velocity * xMultiplier * Time.deltaTime;
        float y = player.transform.position.y * yMultiplier + yOffset;
        transform.position = new Vector3(x, y, transform.position.z);
    }

    IEnumerator checkPosition()
    {
        
        while (isCheckingPosition)
        {
            if(transform.position.x < BackGroundManager.instance.spawnX && isFirstInRow)
            {
                BackGroundManager.instance.setupNewBackground(transform.position.x + BackGroundManager.instance.backgroundWidth, tag);
                isFirstInRow = false;
                Debug.Log("jepp");
            }
            yield return new WaitForSeconds(waitTime);

            if(transform.position.x < BackGroundManager.instance.despawnX)
            {
                BackGroundManager.instance.deleteBackgroundSegment(gameObject);
            }
        }
    }
}
