using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovimentoPlayer : MonoBehaviour
{
    // Rotation speed in degrees per second
    public float rotationSpeed = 90f;
    // Teleport distance
    public float teleportDistance = 3f;
    // Raycast distance
    public float raycastDistance = 2.5f;
    // Rotation duration
    public float rotationDuration = 0.1f;
    // Timeout duration after movement or rotation
    public float inputTimeoutDuration = 1f;

    public GameObject consoleTxt;

    // Flag to check if rotation is in progress
    private bool isRotating = false;
    // Flag to check if input is currently disabled
    private bool isInputDisabled = false;
    // Target rotation angle
    private Quaternion targetRotation;

    // Update is called once per frame
    void Update()
    {
        // Raycast to check for terrain
        RaycastHit hit;

        if (!isInputDisabled)
        {
            // Rotation
            if (!isRotating && Input.GetKeyDown(KeyCode.A))
            {
                // Calculate target rotation angle
                targetRotation = transform.rotation * Quaternion.Euler(Vector3.up * -90f);
                // Start rotating
                StartCoroutine(RotateOverTime(targetRotation, rotationDuration));
                StartCoroutine(DisableInputForDuration(inputTimeoutDuration));
            }
            else if (!isRotating && Input.GetKeyDown(KeyCode.D))
            {
                // Calculate target rotation angle
                targetRotation = transform.rotation * Quaternion.Euler(Vector3.up * 90f);
                // Start rotating
                StartCoroutine(RotateOverTime(targetRotation, rotationDuration));
                StartCoroutine(DisableInputForDuration(inputTimeoutDuration));
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                if (Physics.Raycast(transform.position, transform.forward, out hit, raycastDistance))
                {
                    Debug.Log(hit.transform.tag);
                    Debug.Log(hit.distance);
                    // Check if the collider hit has the tag "Terrain" and if the distance is greater than 4f
                    if (hit.distance > 3.5f && (!hit.transform.CompareTag("Terrain") || !hit.transform.CompareTag("Interactive")))
                    {
                        transform.Translate(Vector3.forward * teleportDistance);
                        StartCoroutine(DisableInputForDuration(inputTimeoutDuration));
                    }
                }
                else
                {
                    transform.Translate(Vector3.forward * teleportDistance);
                    StartCoroutine(DisableInputForDuration(inputTimeoutDuration));
                }
            }
        }

        if (Physics.Raycast(transform.position, transform.forward, out hit, 3f))
        {
            if (hit.transform.CompareTag("Interactive"))
            {   
                consoleTxt.SetActive(true);
            } else {
                consoleTxt.SetActive(false);
            }
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

    // Coroutine to disable input for a duration
    IEnumerator DisableInputForDuration(float duration)
    {
        isInputDisabled = true;
        yield return new WaitForSeconds(duration);
        isInputDisabled = false;
    }
}
