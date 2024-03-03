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
    public float inputTimeoutDuration = 2f;

    public UiController UiController;

    public GameObject eventController;
    public GameObject consoleTxt;
    public GameObject TerminalConsole;

    public GameObject FuseboxMenu;
    public GameObject HexMenu;
    public GameObject QTEMenu;
    public GameObject FishingMenu;

    // Flag to check if rotation is in progress
    private bool isRotating = false;
    // Flag to check if input is currently disabled
    public bool isInputDisabled = false;
    // Target rotation angle
    private Quaternion targetRotation;

    public bool menuopen = false;

    public AudioSource soundSource;

    void Start(){
        TerminalConsole.GetComponent<RectTransform>( ).SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 0);
        TerminalConsole.GetComponent<RectTransform>( ).SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 0);
        UiController = GameObject.Find("UI Canvas").GetComponent<UiController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Raycast to check for terrain
        RaycastHit hit;

        if (!isInputDisabled)
        {
            // Rotation
            if (!isRotating && Input.GetKey(KeyCode.A))
            {
                // Calculate target rotation angle
                targetRotation = transform.rotation * Quaternion.Euler(Vector3.up * -90f);
                // Start rotating
                StartCoroutine(RotateOverTime(targetRotation, rotationDuration));
                StartCoroutine(DisableInputForDuration(inputTimeoutDuration));
            }
            else if (!isRotating && Input.GetKey(KeyCode.D))
            {
                // Calculate target rotation angle
                targetRotation = transform.rotation * Quaternion.Euler(Vector3.up * 90f);
                // Start rotating
                StartCoroutine(RotateOverTime(targetRotation, rotationDuration));
                StartCoroutine(DisableInputForDuration(inputTimeoutDuration));
            }

            if (Input.GetKey(KeyCode.W))
            {
                if (Physics.Raycast(transform.position, transform.forward, out hit, raycastDistance))
                {
                    // Debug.Log(hit.transform.tag);
                    // Debug.Log(hit.distance);
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
                // Check if Enter key is pressed
                if (Input.GetKeyDown(KeyCode.F))
                {
                    string objectName = hit.transform.name;
                    if (menuopen)
                    {
                        CloseMenu(objectName);
                    } else {
                        OpenMenu(objectName);
                    }
                }
            } else {
                consoleTxt.SetActive(false);
            }
        } else {
            consoleTxt.SetActive(false);
        }
    }

    void OpenMenu(string objectName)
    {
        menuopen = true;
        isInputDisabled = true;
        // Logic to open the right menu based on objectName
        switch (objectName)
        {
            case "Fusebox":
                // Open Fusebox menu
                if(EventController.GetFusebox){
                    // Debug.Log("Opening Fusebox menu...");
                    FuseboxMenu.gameObject.SetActive(true);
                    } else {
                        // Debug.Log("nuh uh");
                        CloseMenu(objectName);
                    }
                    
                break;

            case "HexcodePanel":
                // Open HexcodePanel menu
                // Debug.Log("Opening HexcodePanel menu...");
                if(EventController.GetHexcode){
                    HexMenu.gameObject.SetActive(true);
                } else {
                    CloseMenu(objectName);
                }
                break;

            case "Terminal":
                // Debug.Log("Terminal:");
                TerminalConsole.GetComponent<RectTransform>( ).SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 400);
                TerminalConsole.GetComponent<RectTransform>( ).SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 905);
                Transform childTransform = TerminalConsole.transform.Find("Viewport");
                childTransform.gameObject.SetActive(true);
                Debug.ClearDeveloperConsole();
                UiController.showHideStability();
                UiController.showHideMinimap();
                break;

            case "QTE":
                if(EventController.GetQTE)
                {
                    QTEMenu.gameObject.SetActive(true);
                } else {
                    CloseMenu(objectName);
                }
                break;
            case "Fishing":
                if(EventController.GetFishing)
                {
                    FishingMenu.gameObject.SetActive(true);
                } else {
                    CloseMenu(objectName);
                }
                break;

            default:
                // Default case or handle unrecognized object names
                Debug.Log("No menu found for object: " + objectName);
                break;
        }
    }

    void CloseMenu(string objectName)
    {
        menuopen = false;
        isInputDisabled = false;
        // Logic to open the right menu based on objectName
        switch (objectName)
        {
            case "Fusebox":
                // Open Fusebox menu
                // Debug.Log("Closing Fusebox menu...");
                FuseboxMenu.gameObject.SetActive(false);
                break;

            case "HexcodePanel":
                // Open HexcodePanel menu
                // Debug.Log("Closing HexcodePanel menu...");
                HexMenu.gameObject.SetActive(false);
                break;

            case "Terminal":
                // Debug.Log("Closing Terminal menu...");
                TerminalConsole.GetComponent<RectTransform>( ).SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 0);
                TerminalConsole.GetComponent<RectTransform>( ).SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 0);
                Transform childTransform = TerminalConsole.transform.Find("Viewport");
                childTransform.gameObject.SetActive(false);
                UiController.showHideStability();
                UiController.showHideMinimap();
                break;
            
            case "QTE":
                QTEMenu.gameObject.SetActive(false);
                break;

            case "Fishing":
                FishingMenu.gameObject.SetActive(false);
                break;

            default:
                // Default case or handle unrecognized object names
                Debug.Log("No menu to close. " + objectName);
                break;
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
        if(menuopen){
            isInputDisabled = true;
        } else {
            isInputDisabled = false;
        }
    }
}
