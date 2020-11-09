using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Here all the prefabs and objectPool - sizes for a object is stored for each biome.
[CreateAssetMenu(fileName = "Biome", menuName = "ScriptableObjects/Biome", order = 1)]
public class Biome : ScriptableObject
{
    public DefaultBiomeNames defaultBiomeNames;
    public string BiomeName;

    public GameObject ground;
    public int groundPoolSize;
    public GameObject obstacle;
    public int obstaclePoolSize;

    public void SetUpObjectPooler()
    {
        ObjectPooler.Instance.AddPool(GroundName, ground, groundPoolSize);
        ObjectPooler.Instance.AddPool(ObstacleName, obstacle, groundPoolSize);
    }

    public string ObstacleName
    {
        get
        {
            return BiomeName + defaultBiomeNames.ground;
        }
    }

    public string GroundName
    {
        get
        {
            return BiomeName + defaultBiomeNames.obstacle;
        }
    }
}

    


