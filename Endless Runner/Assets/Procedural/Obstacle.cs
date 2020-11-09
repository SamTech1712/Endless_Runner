using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Adds functionality to the proceduralElement script making it a obstacle.
//this is how all special procedural elements should be written.
public class Obstacle : ProceduralElement
{
    public Obstacle(string _tag)
    {
        objectTag = _tag;
    }

    public override void CalculateAndSpawn(Segment segment)
    {
        int halfSegmentlenght = (int)MapCreator.instance.segmentLenght / 2;
        int random = Random.Range(- halfSegmentlenght , halfSegmentlenght);
        position = new Vector3(segment.Xpos + random, segment.ground.height + 1);
        rotation = Quaternion.Euler(0, 0, 0);
        element = ObjectPooler.Instance.SpawnFromPool(objectTag, position, rotation);
    }
}
