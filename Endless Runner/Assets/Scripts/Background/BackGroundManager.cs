using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BackgroundPrefab
{
    public GameObject background;
    public string tag;
    public float y;
}

public class BackGroundManager : MonoBehaviour
{
    public GameObject player;
    public List<BackgroundPrefab> backgroundPrefabs;
    List<GameObject> currentBackgrounds;
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
        currentBackgrounds = new List<GameObject>();
        int numberOfBackgronds = Mathf.RoundToInt((Mathf.Abs(despawnX) + Mathf.Abs(spawnX)) / backgroundWidth);
        
        foreach(BackgroundPrefab background in backgroundPrefabs)
        {
            for (int i = 0; i < numberOfBackgronds + 1; i++)
            {
                float x = despawnX + i * backgroundWidth;
                setupNewBackground(x, background.y, background.tag);
                
            }
        }
    }

   

    public void deleteBackgroundSegment(GameObject background)
    {
        currentBackgrounds.Remove(background);
        background.SetActive(false);
    }

    public void setupNewBackground(float xPos, float yPos, string tag)
    {
        Vector3 position = new Vector3(xPos, yPos, 0);
        GameObject background = ObjectPooler.Instance.SpawnFromPool(tag, position, Quaternion.identity);
        currentBackgrounds.Add(background);
        background.transform.position = position;
        
    }
}
