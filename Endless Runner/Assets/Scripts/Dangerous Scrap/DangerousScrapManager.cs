using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerousScrapManager : MonoBehaviour
{
    public float waitTime { get; private set; }
    public GameObject dangerousScrap;
    private bool run = true;

    public float interval;
    public float intervalChange;
    public float minInterval;
    public float maxX;
    public float minX;

    private GameObject player;

    public static DangerousScrapManager instance;
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        player = PlayerReference.player;
        StartCoroutine(SpawnScrap());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnScrap()
    {
        while (run)
        {
            yield return new WaitForSeconds(interval);

            Vector3 position = new Vector3(Random.Range(minX, maxX),0, 0);
            Instantiate(dangerousScrap, position, Quaternion.identity);
            
            

            if(intervalChange != 0)
            {
                interval -= intervalChange;
                interval = Mathf.Clamp(interval, minInterval, 1000);
            }
        }
    }
}
