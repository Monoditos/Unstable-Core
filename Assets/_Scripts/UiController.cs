using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiController : MonoBehaviour
{

    [Header("Minimap Alerts")]
    public static int switchAlert = 0, hexAlert = 1, qteAlert = 2, pipeAlert = 3;
    public GameObject minimap;
    public GameObject amogus;
    public GameObject[] minimapAlerts;

    [Header("Stability Meter")]
    public GameObject instabilityIndicator;
    public Image sliderBarFill;
    public Slider instabilityMeter;
    public TMP_Text instabilityText;

    [Header("Game Over Screen")]
    public GameObject gameOverScreen;
    public TMP_Text gameOverScore;

    public AudioController audioController;

    public Timer timer;

    void Start()
    {
        gameOverScreen.SetActive(false);
        instabilityIndicator.SetActive(false);
        audioController = GameObject.Find("AudioManager").GetComponent<AudioController>();
    }

    public void showHideStability()
    {
        if (instabilityIndicator.activeSelf)
        {
            instabilityIndicator.SetActive(false);
        }
        else
        {
            instabilityIndicator.SetActive(true);
        }
    }

    public void showHideMinimap()
    {
        if (minimap.activeSelf)
        {
            minimap.SetActive(false);
            amogus.SetActive(false);
        }
        else
        {
            minimap.SetActive(true);
            amogus.SetActive(true);
        }
    }

    public void GameOver()
    {
        EventController.GetTimer = false;
        gameOverScreen.SetActive(true);
        audioController.StopMusic();
        audioController.PlaySoundEffect("reactorExplode");
        gameOverScore.text = "You survived for " + Mathf.Round(timer.elapsedTime*100)/100 + " seconds!";
    }

    void Update()
    {
        if (EventController.GetFusebox)
        {
            ShowMinimapAlert(switchAlert);
        }
        else if (EventController.GetFuseboxCompleted || !EventController.GetFusebox)
        {
            HideMinimapAlert(switchAlert);
        }

        if (EventController.GetHexcode)
        {
            ShowMinimapAlert(hexAlert);
        }
        else if (EventController.GetHexcodeCompleted || !EventController.GetHexcode)
        {
            HideMinimapAlert(hexAlert);
        }

        if (EventController.GetQTE)
        {
            ShowMinimapAlert(qteAlert);
        }
        else if (EventController.GetQTECompleted || !EventController.GetQTE)
        {
            HideMinimapAlert(qteAlert);
        }

        if (EventController.GetFishing)
        {
            ShowMinimapAlert(pipeAlert);
        }
        else if (EventController.GetFishingCompleted || !EventController.GetFishing)
        {
            HideMinimapAlert(pipeAlert);
        }

        instabilityMeter.value = (float)EventController.GetInstability / 100;
        sliderBarFill.color = Color.Lerp(Color.green, Color.red, instabilityMeter.value);
        instabilityText.text = "Instability percentage: " + EventController.GetInstability.ToString();
    }

    public void ShowMinimapAlert(int alertType)
    {
        minimapAlerts[alertType].SetActive(true);
    }

    public void HideMinimapAlert(int alertType)
    {
        minimapAlerts[alertType].SetActive(false);
    }

}
