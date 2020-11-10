using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//A scriptable object to store some defaultnames. Specific names for each of the elements in a biome will be
//created by adding the biomename to the defaultname of its type stored in this script.
//If a new type of element is added it should have a string stored in this script
[CreateAssetMenu(fileName = "DefaulBiomeNames", menuName = "ScriptableObjects/DefaultBiomeNames", order = 2)]
public class DefaultBiomeNames : ScriptableObject
{
    public string ground = "ground";
    public string obstacle = "obstacle";
}
