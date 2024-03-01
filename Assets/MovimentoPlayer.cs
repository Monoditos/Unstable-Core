using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoPlayer : MonoBehaviour
{
    // Rotation speed in degrees per second
    public float rotationSpeed = 90f;
    // Teleport distance
    public float teleportDistance = 3f;

    public bool AllowForwardMovement = true;

    // Update is called once per frame
    void Update()
    {
        // Rotation
        if (Input.GetKeyDown(KeyCode.A))
        {
            // Rotate the game object 90 degrees to the left (counter-clockwise)
            transform.Rotate(Vector3.up, -90f);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            // Rotate the game object 90 degrees to the right (clockwise)
            transform.Rotate(Vector3.up, 90f);
        }

        // Teleportation
        if (Input.GetKeyDown(KeyCode.W))
        {
            if AllowForwardMovement{
                // Move the game object forward by teleportDistance units
            transform.Translate(Vector3.forward * teleportDistance);
            }
        }
    }

    void FixedUpdate()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

         if (Physics.Raycast (transform.position, fwd, hit, Reach) && hit.transform.tag == "Terrain") {
            print("There is Terrain in front of the object!");
         }
    }
}
