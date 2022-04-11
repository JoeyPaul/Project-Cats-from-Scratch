using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {

    [SerializeField] private float zMinPosition;
    [SerializeField] private float zMaxPosition;
    [SerializeField] private float xMinPosition;
    [SerializeField] private float xMaxPosition;
    [SerializeField] private float yPosition;
    [SerializeField] private int minObstacleCount;
    [SerializeField] private int maxObstacleCount;

    [SerializeField] private GameObject obstaclePrefab;

    //private ObjectPooler objectPooler;
    
    private void Start() {
       // objectPooler = GetComponent<ObjectPooler>();
        
        // int numberToGenerate = Random.Range(minObstacleCount, maxObstacleCount);
        
        // Debug.Log(":: gameobj name :: " + gameObject.transform.parent.name);

        // for (int i = 0; i < numberToGenerate; i++) {
        //     float xPosn = Random.Range(xMinPosition, xMaxPosition);
        //     float zPosn = Random.Range(zMinPosition, zMaxPosition);
        //
        //     Vector3 posn = new Vector3(xPosn, yPosition, zPosn);
        //
        //     //GameObject go = objectPooler.GetPooledObject();
        //     GameObject go = Instantiate(obstaclePrefab, transform, false);
        //     // go.transform.parent = gameObject.transform;
        //     go.transform.position = posn;
        // }
    }
}
