using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavePlayerDead : MonoBehaviour
{
    public float timer;
    private NewPlayerMovement player;
    public float maxReverseSpeed;
    public float maxTimer;
    public float lerpSpeed;
    public float minDistanceFromWave;
    private float lerpTime;
    private float lerpTime2;
    private Vector3 originalPosition;

    // Start is called before the first frame update
    void Start()
    {
        player = PlayerReference.player.GetComponent<NewPlayerMovement>();
        originalPosition = transform.position;
    }

    
    // Update is called once per frame
    void Update()
    {
        if(player.velocity > maxReverseSpeed)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer -= Time.deltaTime;
            timer = Mathf.Clamp(timer, 0, 100);
        }
        if(timer > maxTimer)
        {
            lerpTime += Time.deltaTime * lerpSpeed;
            transform.position = Vector3.Lerp(transform.position, player.transform.position, lerpTime);
            lerpTime2 = 0;
        }
        else
        {
            lerpTime2 += Time.deltaTime * lerpSpeed;
            transform.position = Vector3.Lerp(transform.position, originalPosition, lerpTime);
            lerpTime = 0;
        }

        if(Vector3.Distance(transform.position , player.transform.position) < minDistanceFromWave)
        {
            GameOverMenu.instance.GameOver();
            transform.position = originalPosition;
            timer = 0;
        }

    }
}
