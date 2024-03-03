using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiController : MonoBehaviour
{

    [Header("Minimap Alerts")]
    public static int switchAlert = 0, hexAlert = 1, qteAlert = 2;
    public GameObject[] minimapAlerts;

    void Start() {

    }

    void Update() {
        if (EventController.GetFusebox) {
            ShowMinimapAlert(switchAlert);
        } else if(EventController.GetFuseboxCompleted || !EventController.GetFusebox) {
            HideMinimapAlert(switchAlert);
        }
    }

    public void ShowMinimapAlert(int alertType) {
        minimapAlerts[alertType].SetActive(true);
    }

    public void HideMinimapAlert(int alertType) {
        minimapAlerts[alertType].SetActive(false);
    }

}
