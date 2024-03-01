using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoPlayer : MonoBehaviour
{
    // Rotation speed in degrees per second
    public float rotationSpeed = 90f;
    // Teleport distance
    public float teleportDistance = 3f;
    // Raycast distance
    public float raycastDistance = 3f;

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

        if (Input.GetKeyDown(KeyCode.W))
        {
            // Raycast to check for terrain
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, raycastDistance))
            {
                Debug.Log("PAREDE RAYCASTED");
                Debug.Log(hit.distance);
                // Check if the collider hit has the tag "Terrain"
                if (hit.distance > 3f){
                    Debug.Log("MUITO PERTO");
                    // Debug.Log("GHRROKJITHGIJERO");
                    transform.Translate(Vector3.forward * teleportDistance);
                }
            } else {
                transform.Translate(Vector3.forward * teleportDistance);
            }
        }



        else if (Input.GetKeyDown(KeyCode.S))
        {
            // Move the game object backward by teleportDistance units
            transform.Translate(Vector3.back * teleportDistance);
        }
    }
}
