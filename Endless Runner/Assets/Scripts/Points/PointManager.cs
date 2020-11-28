using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointManager : MonoBehaviour
{
    public int score{get; private set;}
    public PointUI pointText;

    #region Singleton
    public static PointManager instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        score = 0;   
    }

    // Update is called once per frame
    void LateUpdate()
    {
        pointText.UpdateScore(score);
    }

    public void IncreaseScore()
    {
        score += 1;
    }
}
