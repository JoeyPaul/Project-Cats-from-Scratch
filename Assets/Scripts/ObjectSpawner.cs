using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    // How many objects on screen of each type
    public int foregroundObjectCount;
    public int middlegroundObjectCount;
    public int backgroundObjectCount;

    // Spawn Locations
    GameObject backgroundSpawner;
    GameObject middlegroundSpawner;
    GameObject foregroundSpawner;

    // The prefabs
    public GameObject foregroundObject;
    // New instances
    private GameObject foregroundObjectInstance;

    // Parent gameobject for the prefabs
    private GameObject foregroundObjects;
    private GameObject middlegroundObjects;
    private GameObject backgroundObjects;

    void Start()
    {
        // Get the spawn location gameobjects
         backgroundSpawner = transform.GetChild(0).gameObject; 
         middlegroundSpawner = transform.GetChild(1).gameObject; 
         foregroundSpawner = transform.GetChild(2).gameObject;
     
        // Finding parent gameobjects for instantiated prefabs
        // just to make it look neat
        foregroundObjects = GameObject.Find("foreground_Objects");
        middlegroundObjects = GameObject.Find("middleground_Objects");
        backgroundObjects = GameObject.Find("background_Objects");


        SpawnForegroundObject();
    }

    void Update()
    {
        if (foregroundObjectInstance != null)
        {
            // if the object passes the edge of the screen on the left 
            if (foregroundObjectInstance.transform.position.x < -8.0f)
            {
                Destroy(foregroundObjectInstance);
                foregroundObjectCount--; // decrease the count
            }
        }
    }

    void SpawnForegroundObject()
    {
        // Instantiate the object
        foregroundObjectInstance = Instantiate(foregroundObject, new Vector3(foregroundSpawner.transform.position.x, foregroundSpawner.transform.position.y, 0), Quaternion.identity);
        // increase the count
        foregroundObjectCount++;
        // Set parent gameobjects for instantiated prefabs
        foregroundObjectInstance.transform.parent = foregroundObjects.transform;
    }
}
