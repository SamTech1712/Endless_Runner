using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Another procedural element. This one is not different because the ground or platform should take the position of other
// platforms into account when it is beeing placed. That's why it doesn't have the calculateAndSpawn function.
public class Ground : ProceduralElement
{
    public float height
    {
        get
        {
            return position.y;
        }
        set
        {
            
            position = new Vector3(position.x, value, position.z);
            
        }
    }

    public Ground(float _height, string _tag)
    {
        height = _height;
        objectTag = _tag;
    }

    public void Spawn(float xPos)
    {
        position = new Vector3(xPos, position.y, position.z);


        rotation = new Quaternion(1, 0, 0, 0);

        element = ObjectPooler.Instance.SpawnFromPool(objectTag, position, rotation);
    }
}
