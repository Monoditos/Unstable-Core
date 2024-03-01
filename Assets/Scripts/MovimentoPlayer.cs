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
    public float raycastDistance = 2.5f;
    // Rotation duration
    public float rotationDuration = 0.5f;
    // Flag to check if rotation is in progress
    private bool isRotating = false;
    // Target rotation angle
    private Quaternion targetRotation;

    // Update is called once per frame
    void Update()
    {
        // Rotation
        if (!isRotating && Input.GetKeyDown(KeyCode.A))
        {
            // Calculate target rotation angle
            targetRotation = transform.rotation * Quaternion.Euler(Vector3.up * -90f);
            // Start rotating
            StartCoroutine(RotateOverTime(targetRotation, rotationDuration));
        }
        else if (!isRotating && Input.GetKeyDown(KeyCode.D))
        {
            // Calculate target rotation angle
            targetRotation = transform.rotation * Quaternion.Euler(Vector3.up * 90f);
            // Start rotating
            StartCoroutine(RotateOverTime(targetRotation, rotationDuration));
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            // Raycast to check for terrain
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, raycastDistance))
            {
                Debug.Log("PAREDE RAYCASTED");
                Debug.Log(hit.distance);
                Debug.Log(hit.transform.tag);
                // Check if the collider hit has the tag "Terrain"
                if (hit.distance > 4f && hit.transform.tag == "Terrain"){
                    Debug.Log("PAREDE PERTO");
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

    // Coroutine to rotate over time
    IEnumerator RotateOverTime(Quaternion targetRotation, float duration)
    {
        isRotating = true;
        float elapsedTime = 0;

        Quaternion startingRotation = transform.rotation;

        while (elapsedTime < duration)
        {
            transform.rotation = Quaternion.Lerp(startingRotation, targetRotation, (elapsedTime / duration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.rotation = targetRotation;
        isRotating = false;
    }
}
