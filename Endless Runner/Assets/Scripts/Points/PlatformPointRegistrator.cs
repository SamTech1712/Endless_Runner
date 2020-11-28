using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPointRegistrator : MonoBehaviour
{
    PointManager pointManager;
    bool isFirstTimeLanding = true;
    // Start is called before the first frame update

    private void Start()
    {
        pointManager = PointManager.instance;
    }
    void OnEnable()
    {
        isFirstTimeLanding = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player" && isFirstTimeLanding )
        {
            pointManager.IncreaseScore();
            isFirstTimeLanding = false;
        }
    }

}
