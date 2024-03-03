using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController : Singleton
{
    private bool isCountingFuse, isCountingHex, isCountingQTE, isCountingFishing;
    private float timeToDamageFuse, timeToDamageHex, timeToDamageQTE, timeToDamageFishing;
    public static EventController instance;

    // Constants for minigame probabilities and durations
    private const float initialMinigameActivationProbability = 0.20f; // Adjust this value as needed
    private float currentMinigameActivationProbability;
    public const float initialWaitTime = 4f;
    public float currentWaitTime;

    public GameObject player;
    private CameraShake cameraShake;
    public AudioController audioManager;
    public UiController uiController;

    private MovimentoPlayer playerScript;
    // Minigame states
    private static bool timer = true;
    public static int switchCounter = 0;
    public static int streak = 0;
    private static bool fusebox = false;
    private static bool fuseboxCompleted = false;
    private static bool hexcode = false;
    private static bool hexcodeCompleted = false;

    private static bool qte = false;

    private static bool qteCompleted = false;
    private static bool fishing = false;

    private static bool fishingCompleted = false;

    // Countdown timer for active minigames
    private static float minigameTimer = 0f;

    public static int instability = 0;

    public GameObject fuseboxMenu;
    public GameObject hexMenu;
    public GameObject QTEMenu;
    public GameObject FishingMenu;

    public GameObject terminalMenu;


    public static bool GetTimer
    {
        get { return timer; }
        set { timer = value; }
    }

    public static int GetSwitches
    {
        get { return switchCounter; }
        set { switchCounter = value; }
    }
    public static int GetStreak
    {
        get { return streak; }
        set { streak = value; }
    }

    public static bool GetFusebox
    {
        get { return fusebox; }
        set { fusebox = value; }
    }

    public static bool GetFuseboxCompleted
    {
        get { return fuseboxCompleted; }
        set { fuseboxCompleted = value; }
    }

    public static bool GetHexcode
    {
        get { return hexcode; }
        set { hexcode = value; }
    }

    public static bool GetHexcodeCompleted
    {
        get { return hexcodeCompleted; }
        set { hexcodeCompleted = value; }
    }

    public static bool GetQTE
    {
        get { return qte; }
        set { qte = value; }
    }

    public static bool GetQTECompleted
    {
        get { return qteCompleted; }
        set { qteCompleted = value; }
    }

    public static bool GetFishing
    {
        get { return fishing; }
        set { fishing = value; }
    }

    public static bool GetFishingCompleted
    {
        get { return fishingCompleted; }
        set { fishingCompleted = value; }
    }
    public static int GetInstability
    {
        get { return instability; }
        set
        {
            if (value > 100)
            {
                instability = 100;
            }
            else if (value < 0)
            {
                instability = 0;
            }
            else
            {
                instability = value;
            }
        }
    }

    private void ActivateMinigame()
    {
        audioManager.PlaySoundEffect("somquandopassathreshold");
        while (true)
        {

            int randomNumber = Random.Range(0, 100);
            // int randomNumber = 40;
            // Determine which minigame to activate (for example, randomly)
            if (randomNumber < 25)
            {
                if (GetFusebox)
                {
                    break;
                }
                GetFusebox = true;
                GetSwitches = 0;
                Debug.Log("Fusebox anomaly, fix it before critical failure.");
                break;
            }
            if (randomNumber < 50)
            {
                if (GetHexcode)
                {
                    break;
                }
                GetHexcode = true;
                Debug.Log("Hex Binaries scrambled, fix it before critical failure.");
                break;
            }
            if (randomNumber < 75)
            {
                if (GetQTE)
                {
                    break;
                }
                GetQTE = true;
                GetStreak = 0;
                Debug.Log("Anomaly at doorstep, secure it.");
                break;
            }
            if (randomNumber < 100)
            {
                if (GetFishing)
                {
                    break;
                }
                GetFishing = true;
                Debug.Log("Pipes stuck, fix it before critical failure.");
                break;
            }
        }
    }

    private void Start()
    {

        currentWaitTime = initialWaitTime;
        currentMinigameActivationProbability = initialMinigameActivationProbability;
        StartCoroutine(ActivateMinigameCoroutine());

        cameraShake = player.GetComponentInChildren<CameraShake>();

    }
    private IEnumerator ActivateMinigameCoroutine()

    {
        while (true)
        {
            yield return new WaitForSeconds(currentWaitTime);

            // Calculate if a minigame should activate based on probability
            if ((!GetFusebox || !GetHexcode || !GetFishing || !GetQTE) && (Random.Range(0f,1f) < currentMinigameActivationProbability))
            {
                ActivateMinigame();
            }
            else
            {
                currentWaitTime *= 0.995f; // Decrease wait time by 1% (adjust this value as needed)
                currentWaitTime = Mathf.Max(currentWaitTime, 1f); // Ensure wait time doesn't go below 0.1 seconds
                currentMinigameActivationProbability *= 1.01f;
                currentMinigameActivationProbability = Mathf.Min(currentMinigameActivationProbability, 0.33f);

                // Debug.Log(currentMinigameActivationProbability + "% Probability");
                // Debug.Log(currentWaitTime + ": Time of Wait");
            }
        }
    }


    private void Update()
    {
        if (GetInstability >= 80)
        {
            // Activate the cameraShake script
            if (cameraShake != null)
            {
                cameraShake.enabled = true;
            }
        }
        else
        {
            // Deactivate the cameraShake script
            if (cameraShake != null)
            {
                cameraShake.enabled = false;
            }
        }
        if (GetInstability >= 100)
        {
            EndGame();
        }

        if (GetFuseboxCompleted)
        {
            GetInstability -= 5;
            isCountingFuse = false;
            GetFuseboxCompleted = false;
            MovimentoPlayer playerScript = player.GetComponent<MovimentoPlayer>();
            audioManager.PlaySoundEffect("sommagicocompletaralgo");
            fuseboxMenu.gameObject.SetActive(false);
            Debug.Log("Fusebox fixed!");
            playerScript.menuopen = false;
            playerScript.isInputDisabled = false;
        }

        if (GetHexcodeCompleted)
        {
            GetInstability -= 5;
            isCountingHex = false;
            GetHexcodeCompleted = false;
            MovimentoPlayer playerScript = player.GetComponent<MovimentoPlayer>();
            audioManager.PlaySoundEffect("sommagicocompletaralgo");
            hexMenu.gameObject.SetActive(false);
            playerScript.menuopen = false;
            playerScript.isInputDisabled = false;
        }
        if (GetQTECompleted)
        {
            GetInstability -= 5;
            isCountingQTE = false;
            GetQTECompleted = false;
            MovimentoPlayer playerScript = player.GetComponent<MovimentoPlayer>();
            audioManager.PlaySoundEffect("sommagicocompletaralgo");
            QTEMenu.gameObject.SetActive(false);
            Debug.Log("Security door secured!");
            playerScript.menuopen = false;
            playerScript.isInputDisabled = false;
        }
        if (GetFishingCompleted)
        {
            GetInstability -= 5;
            isCountingFishing = false;
            GetFishingCompleted = false;
            MovimentoPlayer playerScript = player.GetComponent<MovimentoPlayer>();
            audioManager.PlaySoundEffect("sommagicocompletaralgo");
            FishingMenu.gameObject.SetActive(false);
            Debug.Log("Pipes Unblocked!");
            playerScript.menuopen = false;
            playerScript.isInputDisabled = false;
        }


        if (GetFusebox)
        {
            if (isCountingFuse)
            {
                if (Time.time - timeToDamageFuse > 5)
                {
                    GetInstability += 2;
                    isCountingFuse = false;
                    Debug.LogWarning("Fusebox anomaly increasing instability.");
                }
            }
            else
            {
                timeToDamageFuse = Time.time;
                isCountingFuse = true;

            }
        }
        if (GetHexcode)
        {
            if (isCountingHex)
            {
                if (Time.time - timeToDamageHex > 5)
                {
                    GetInstability += 2;
                    isCountingHex = false;
                    Debug.LogWarning("Cooling Binaries anomaly increasing instability.");
                }
            }
            else
            {
                timeToDamageHex = Time.time;
                isCountingHex = true;

            }
        }
        if (GetQTE)
        {
            if (isCountingQTE)
            {
                if (Time.time - timeToDamageQTE > 5)
                {
                    Debug.LogWarning("Door anomaly increasing instability.");
                    GetInstability += 2;
                    isCountingQTE = false;
                }
            }
            else
            {
                timeToDamageQTE = Time.time;
                isCountingQTE = true;

            }
        }
        if (GetFishing)
        {
            if (isCountingFishing)
            {
                if (Time.time - timeToDamageFishing > 5)
                {
                    Debug.LogWarning("Pipes anomaly increasing instability.");
                    GetInstability += 2;
                    isCountingFishing = false;
                }
            }
            else
            {
                timeToDamageFishing = Time.time;
                isCountingFishing = true;

            }
        }
    }

    public static void AddSwitch(int count)
    {
        switchCounter += count;
        if (switchCounter == 8)
        {
            GetFusebox = false;
            GetSwitches = 0;
        }
    }

    public static void CriticalError(int game)
    {
        switch (game)
        {
            case 1:
                GetFusebox = false;
                GetSwitches = 0;
                GetFuseboxCompleted = true;
                GetInstability += 15;
                break;
            case 2:
                GetHexcode = false;
                GetHexcodeCompleted = true;
                GetInstability += 15;
                break;
            case 3:
                GetQTE = false;
                GetQTECompleted = true;
                GetStreak = 0;
                GetInstability += 15;
                break;
        }
    }

    public void EndGame()
    {
        uiController = GameObject.Find("UI Canvas").GetComponent<UiController>();
        terminalMenu.gameObject.SetActive(false);
        fuseboxMenu.gameObject.SetActive(false);
        hexMenu.gameObject.SetActive(false);
        FishingMenu.gameObject.SetActive(false);
        QTEMenu.gameObject.SetActive(false);
        uiController.GameOver();
        Time.timeScale = 0;
    }
}
