using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//this script manages all of the procedural generation as well as managing movement of the map and spawning and despawning of elements
public class MapCreator : MonoBehaviour
{
    //to move enviroment call: MapCreator.instance.Move(distance to move in float)
    
    List<Segment> segments;//segments currently present
    //A segment is a part of the map containing a list of obstacles and a platform that should be inside the segment

    //Add biomes to this list to have several biomes
    public List<Biome> biomes;

    //A biome is a scriptable object storing all the prefabs of a specific biome. Example, a city biome would store buildings and
    //chimneys, while a forest biome would store trees and platforms.
    Biome currentBiome;

    //stores how many segments are left before the script gets a new random biome.
    int segmentsLeftOfBiome;

    public float despawnX;         //the X coordinate where segments will spawn
    public float spawnX;           //the X coordinate where segments will despawn
    public float maxY;             //the highest the platform can be
    public float minY;             //the lowest the platform can be
    public Vector2 playerStartPosition; // controls the position of the first platforms
    public float segmentLenght;
    
    public float difficulty;       //used to determine the distance of jumps etc.
                                   //will be changed during the run

    //Singleton gives you the opportunity to call MapCreator.instance instead of storing a reference to the script
    #region Singleton

    public static MapCreator instance;
    
    private void Awake()
    {
        instance = this;
    }
    #endregion

    private void Start()
    {
        //The objectPooler will get all of the objects in the biomes and create a pool for each of them
        SetupBiomes();

        //creates the segmentList
        segments = new List<Segment>();

        //Gets a random biome to start the map with
        GetBiome();

        float distanceSpawnDespawn = Mathf.Abs(despawnX) + Mathf.Abs(spawnX);

        //max number of segments possible between spawn and despawn.
        int numberOfSegments = Mathf.RoundToInt(distanceSpawnDespawn / segmentLenght);

        // sets up the first segments
        for(int i = 1; i <= numberOfSegments; i++)
        {
            float x = despawnX + i * segmentLenght;
            Segment segment = new Segment(x, i - 1);
            segments.Add(segment);
            CalculateSegment(segment);
            
            segment.Spawn();
        }
    }

    //This is the function to call to move all segments, meaning the whole map.
    public void Move(float distance)
    {
        //calls the move.function on each segment
        foreach(Segment segment in segments)
        {
            segment.Move(distance);
        }
    }

    //this function calculates the height of the platform based on the previous one.
    private void CalculateSegment(Segment segment)
    {
        //calculate height and store the groundelement
        if(segment.listIndex > 0)
        {
            float height = GetHeight(segments[segment.listIndex - 1].ground.height);
            if(segment.Xpos < playerStartPosition.x)
            {
                height = playerStartPosition.y - 5;
            }
            segment.ground = new Ground(height, currentBiome.GroundName);
        }
        else
        {
            segment.ground = new Ground(0, currentBiome.GroundName);
        }

        //create the list og elements inside the current segment
        segment.elements = new List<ProceduralElement>();

        //Adds a single obstacle element. The element wont get a position until Spawn is calles on the segment it belongs to
        segment.elements.Add(new Obstacle(currentBiome.ObstacleName));
    }

    private void Update()
    {
        //check if the last segment should despawn
        if(segments[0].Xpos < despawnX)
        {
            DeleteLastSegment();
        }

        //check if there is need for a new element in front
        if(segments[segments.Count - 1].Xpos < spawnX)
        {
            float firstSegmentDistance = spawnX - segments[segments.Count - 1].Xpos;
            if(firstSegmentDistance > segmentLenght)
            {
                SpawnNewSegment(segments[segments.Count - 1].Xpos + segmentLenght);
                Debug.Log("hello");
            }
        }
    }

    //creates a new segment in front of the others
    void SpawnNewSegment(float xPos)
    {
        Segment segment = new Segment(xPos, segments.Count);
        segments.Add(segment);
        CalculateSegment(segment);

        segment.Spawn();
    }

    //deletes the last segment
    void DeleteLastSegment()
    {
        Segment lastSegment = segments[0];
        lastSegment.Delete();
        segments.RemoveAt(0);
        foreach(Segment segment in segments)
        {
            segment.listIndex--;
        }
    }

    //Calculates a height based on a height passed in and the current difficulty
    private float GetHeight(float previousHeight)
    {
        float value = previousHeight + Random.Range(-difficulty, difficulty);
        value = Mathf.Clamp(value, minY, maxY);
        
        return value;
    }

    //sets currentBiome to a randomBiome inside the biomes-list
    void GetBiome()
    {
        int random = Random.Range(0, biomes.Count - 1);
        currentBiome = biomes[random];
        //lenghtOfBiomeHaveToBeAdded
    }

    //sets up the objectPooler with each item in each of the biome.
    void SetupBiomes()
    {
        foreach(Biome biome in biomes)
        {
            biome.SetUpObjectPooler();
        }
    }

    
}
