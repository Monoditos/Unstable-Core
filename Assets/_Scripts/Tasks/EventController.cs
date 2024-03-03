using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController : Singleton
{
    private bool isCountingFuse, isCountingHex, isCountingQTE, isCountingFishing;
    private float timeToDamageFuse, timeToDamageHex, timeToDamageQTE, timeToDamageFishing;
    public static EventController instance;

    // Constants for minigame probabilities and durations
    private const float minigameActivationProbability = 0.00009f; // Adjust this value as needed


    public GameObject player;

    private MovimentoPlayer playerScript;
    // Minigame states
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
        set { instability = value; }
    }
    private void ActivateMinigame()
    {
        while (true)
        {

            int randomNumber = Random.Range(0, 100);
            // Determine which minigame to activate (for example, randomly)
            if (randomNumber < 25)
            {
                if (GetFusebox)
                {
                    continue;
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
                    continue;
                }
                GetHexcode = true;
                Debug.Log("Cooling binaries anomaly, fix it before critical failure.");
                break;
            }
            if (randomNumber < 75)
            {
                if (GetQTE)
                {
                    continue;
                }
                GetQTE = true;
                GetStreak = 0;
                Debug.Log("Exit door is beeing forced, fix it before critical failure.");
                break;
            }
            if (randomNumber < 100)
            {
                if (GetFishing)
                {
                    continue;
                }
                GetFishing = true;
                Debug.Log("Something got stuck in the pipes, fix it before critical failure.");
                break;
            }
        }
    }
    private void Update()
    {
        // Check for minigame activation
        if ((!GetFusebox || !GetHexcode || !GetFishing || !GetQTE) && (Random.value < minigameActivationProbability))
        {
            ActivateMinigame();
        }

        if (GetFuseboxCompleted)
        {
            GetInstability -= 5;
            isCountingFuse = false;
            GetFuseboxCompleted = false;
            MovimentoPlayer playerScript = player.GetComponent<MovimentoPlayer>();
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
            QTEMenu.gameObject.SetActive(false);
            playerScript.menuopen = false;
            playerScript.isInputDisabled = false;
        }
        if (GetFishingCompleted)
        {
            GetInstability -= 5;
            isCountingFishing = false;
            GetFishingCompleted = false;
            MovimentoPlayer playerScript = player.GetComponent<MovimentoPlayer>();
            FishingMenu.gameObject.SetActive(false);
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
                    Debug.Log("WAH");
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
                    Debug.Log("HAW");
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
                    Debug.Log("QTE");
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
                    Debug.Log("PEixe");
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
            case 4:
                GetFishing = false;
                GetFishingCompleted = true;
                GetInstability = 100;
                break;
        }
    }
}
