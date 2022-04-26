using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public float cameraWalkSpeed, cameraRunSpeed;
    Vector3 directionRight = new Vector3(1.0f, 0.0f, 0.0f);
    
      // Create an enum type so we can pick the speed from a different game manager script
    public enum Speed
    {
        WALK, // 0
        RUN, // 1 
    };

    public Speed speed;

    // Start is called before the first frame update
    void Start()
    {
        cameraWalkSpeed = 1.0f;
        cameraRunSpeed = 3.0f;
    }
    void Update()
    {
        // Check if walking or running to set the correct speed and movement.
        if (speed == Speed.WALK)
        {
            // Create The Movement by direction 
            Vector3 velocityPerSecond = directionRight.normalized * cameraWalkSpeed;
            Vector3 velocityThisFrame = velocityPerSecond * Time.deltaTime;
            transform.position += velocityThisFrame;
        }
        else if (speed == Speed.RUN) 
        {
            Vector3 velocityPerSecond = directionRight.normalized * cameraRunSpeed;
            Vector3 velocityThisFrame = velocityPerSecond * Time.deltaTime;
            transform.position += velocityThisFrame;
        }
    }
}
