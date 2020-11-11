using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//the parent class to all elements that should be placed proceduraly.
public class ProceduralElement
{
    
    public Vector3 position;
    public Quaternion rotation;
    public string objectTag;
    public GameObject element;



    public void Move(float distance)
    {
        if(element != null)
        {
            element.transform.position = new Vector3(element.transform.position.x + distance, element.transform.position.y, 0);
            position = element.transform.position;
        }
    }

    public virtual void CalculateAndSpawn(Segment segment)
    {
        element = ObjectPooler.Instance.SpawnFromPool(objectTag, position, rotation);
    }
}
