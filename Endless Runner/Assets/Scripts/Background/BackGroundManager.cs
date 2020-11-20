﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundManager : MonoBehaviour
{
    public GameObject player;
    public List<string> backgroundTags;
    public float spawnX;
    public float despawnX;
    public float backgroundWidth;

    #region singleton
    public static BackGroundManager instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion

    void Start()
    {
        
        int numberOfBackgronds = Mathf.RoundToInt((Mathf.Abs(despawnX) + Mathf.Abs(spawnX)) / backgroundWidth);
        
        foreach(string tag in backgroundTags)
        {
            for (int i = 0; i < numberOfBackgronds + 1; i++)
            {
                float x = despawnX + i * backgroundWidth;
                setupNewBackground(x, tag);
            }
        }
    }

    public void deleteBackgroundSegment(GameObject background)
    {
        
        background.SetActive(false);
    }

    public void setupNewBackground(float xPos, string tag)
    {
        Vector3 position = new Vector3(xPos, 0, 0);
        GameObject background = ObjectPooler.Instance.SpawnFromPool(tag, position, Quaternion.identity);
        
        background.transform.position = position;
        
    }
}
