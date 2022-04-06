using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float backgroundSpeed, middlePlayAreaSpeed, foregroundSpeed;
    public float speed;

    Vector3 directionLeft = new Vector3(-1.0f, 0.0f, 0.0f);

    // Create an enum type so we can pick which type of object it is in the editor.
    // Example: Background, will move slower than the Foreground type. 
    public enum Distance
    {
        Background, // 0
        MiddlePlayArea, // 1 
        Foreground // 2
    };

    public Distance distance;

    void Start()
    {
        // Set the default start values
        backgroundSpeed = 1.0f;
        middlePlayAreaSpeed = 1.5f;
        foregroundSpeed = 2.0f;
    }

    void Update()
    {
        // Check the distance/depth of the object to set the correct speed and movement.
        if (distance == Distance.Background)
        {
            // Create The Movement by direction * the speed of the background
            speed = backgroundSpeed;
            Vector3 velocityPerSecond = directionLeft.normalized * speed;
            Vector3 velocityThisFrame = velocityPerSecond * Time.deltaTime;
            transform.position += velocityThisFrame;
        }
        else if (distance == Distance.MiddlePlayArea) // same for the next two types
        {
            speed = middlePlayAreaSpeed;
            Vector3 velocityPerSecond = directionLeft.normalized * speed;
            Vector3 velocityThisFrame = velocityPerSecond * Time.deltaTime;
            transform.position += velocityThisFrame;
        }
        else if (distance == Distance.Foreground)
        {
            speed = foregroundSpeed;
            Vector3 velocityPerSecond = directionLeft.normalized * speed;
            Vector3 velocityThisFrame = velocityPerSecond * Time.deltaTime;
            transform.position += velocityThisFrame;
        }
    }
}
