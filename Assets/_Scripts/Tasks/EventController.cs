using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController : Singleton
{
    public static EventController instance;

    // Constants for minigame probabilities and durations
    private const float minigameActivationProbability = 0.0007f; // Adjust this value as needed
    private const float minigameDuration = 10f; // Duration of minigames in seconds

    private static float fuseboxDuration = 15f;
    private static float hexcodeDuration = 20f;

    // Minigame states
    public static int switchCounter = 0;
    public static int streak = 0;
    private static bool fusebox = false;
    private static bool fuseboxCompleted = false;
    private static bool hexcode = false;
    private static bool hexcodeCompleted = false;

    // Countdown timer for active minigames
    private static float minigameTimer = 0f;

    public static int stability = 100;

    public GameObject fuseboxMenu;
    public GameObject hexMenu;
    public GameObject QTEMenu;



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

    // REACTOR LOGIC

    private void IncreaseInstability()
    {
        // Increase reactor instability when a minigame is failed
        Debug.Log("Instability increased!");
        stability += 10;
    }

    private void DecreaseInstability()
    {
        // Increase reactor instability when a minigame is failed
        Debug.Log("Instability decreased!");
        stability -= 10;
    }

    // MINIGAME EVENT CONTROLLER

    private void ActivateMinigame()
    {
        // Determine which minigame to activate (for example, randomly)
        if (Random.value > 0.0001f)
        {
            GetFusebox = true;
            // Debug.Log(GetFusebox);
            GetSwitches = 0;
            StartCoroutine(ActivateFusebox());
            Debug.Log("Fuse anomaly. " + fuseboxDuration + "s until critical failure.");
        }
        else
        {
            GetHexcode = true;
            StartCoroutine(ActivateHexcode());
            Debug.Log("Cooling binaries anomaly. " + hexcodeDuration + "s until critical failure.");
            // Debug.Log("Hexcode minigame activated!");
        }
    }

    private void DeactivateMinigames()
    {
        GetFusebox = false;
        GetHexcode = false;
        // Reset the timer for the next activation
        minigameTimer = minigameDuration;
    }

    private void Start()
    {

    }

    private void Update()
    {
        // Check for minigame activation
        if (!GetFusebox && !GetHexcode && (Random.value < minigameActivationProbability))
        {
            ActivateMinigame();
        }
    }

    // SWITCH GAME

    private IEnumerator ActivateFusebox()
    {
        while (true)
        {
            yield return new WaitForSeconds(fuseboxDuration);
            if (GetFuseboxCompleted)
            {
                // Minigame time is up, increase instability or decrease it if completed
                GetFusebox = false;
                // Debug.Log("Fusebox minigame time up!");
                DecreaseInstability();
            }
            else
            {
                GetFusebox = false;
                GetFuseboxCompleted = false;
                IncreaseInstability();
                Debug.Log("Fusebox minigame time up!");
                break;
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

    private IEnumerator ActivateHexcode()
    {
        while (true)
        {
            yield return new WaitForSeconds(hexcodeDuration);
            if (GetHexcodeCompleted)
            {
                // Minigame time is up, increase instability or decrease it if completed
                GetHexcode = false;
                // Debug.Log("Hexcode minigame time up!");
                DecreaseInstability();
            }
            else
            {
                GetHexcode = false;
                GetHexcodeCompleted = false;
                Debug.Log("Hexcode minigame time up!");
                IncreaseInstability();
            }
        }
    }
}
