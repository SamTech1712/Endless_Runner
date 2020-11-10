using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Stores all the procedural elements in one segment of the map.
//Will also call Spawn, Delete and Move functions on all of its elements.
public class Segment
{
    public List<ProceduralElement> elements;

    public float Xpos;

    public int listIndex;

    public Ground ground;

    public void Move(float distance)
    {
        Xpos += distance;
        ground.Move(distance);
        foreach (ProceduralElement element in elements)
        {
            element.Move(distance);
        }
    }

    public void Spawn()
    {
        ground.Spawn(Xpos);
        if(elements != null)
        {
            foreach (ProceduralElement element in elements)
            {
                element.CalculateAndSpawn(this);
            }
        }
        
    }

    public Segment(float x, int index)
    {
        Xpos = x;
        listIndex = index;
    }

    public void Delete()
    {
        ground.element.SetActive(false);
        if (elements != null)
        {
            foreach (ProceduralElement element in elements)
            {
                element.element.SetActive(false);
            }
        }
    }
}
