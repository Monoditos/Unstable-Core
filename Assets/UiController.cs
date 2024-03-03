using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiController : MonoBehaviour
{

    [Header("Minimap Alerts")]
    public static int switchAlert = 0, hexAlert = 1, qteAlert = 2;
    public GameObject[] minimapAlerts;
    
    [Header("Stability Meter")]
    public Slider instabilityMeter;
    public TMP_Text instabilityText;

    void Start() {

    }

    void Update() {
        if (EventController.GetFusebox) {
            ShowMinimapAlert(switchAlert);
        } else if(EventController.GetFuseboxCompleted || !EventController.GetFusebox) {
            HideMinimapAlert(switchAlert);
        }

        instabilityMeter.value = (float)EventController.GetInstability / 100;
        instabilityText.text = "Instability Status: " + EventController.GetInstability.ToString() + "%";
    }

    public void ShowMinimapAlert(int alertType) {
        minimapAlerts[alertType].SetActive(true);
    }

    public void HideMinimapAlert(int alertType) {
        minimapAlerts[alertType].SetActive(false);
    }

}
