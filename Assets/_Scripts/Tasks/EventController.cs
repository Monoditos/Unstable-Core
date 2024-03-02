using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController : Singleton
{
    public static EventController instance;

    // Constants for minigame probabilities and durations
    private const float minigameActivationProbability = 0.1f; // Adjust this value as needed
    private const float minigameDuration = 30f; // Duration of minigames in seconds

    private static float fuseboxDuration = 30f;

    private static float hexcodeDuration = 30f;

    // Minigame states
    private static bool fuseboxActive = false;

    public static int switchCounter = 0;
    private static bool fusebox = false;
    private static bool hexcode = false;
    private static bool hexcodeActive = false;

    // Countdown timer for active minigames
    private static float minigameTimer = 0f;

    // REACTOR LOGIC

    private void IncreaseInstability()
    {
        // Increase reactor instability when a minigame is failed
        Debug.Log("Instability increased!");
    }

    private void DecreaseInstability()
    {
        // Increase reactor instability when a minigame is failed
        Debug.Log("Instability decreased!");
    }

    // MINIGAME EVENT CONTROLLER

    private void ActivateMinigame()
    {
        // Determine which minigame to activate (for example, randomly)
        if (Random.value < 0.5f)
        {
            fuseboxActive = true;
            Debug.Log("Fusebox minigame activated!");
        }
        else
        {
            hexcodeActive = true;
            Debug.Log("Hexcode minigame activated!");
        }
    }

    private void DeactivateMinigames()
    {
        fuseboxActive = false;
        hexcodeActive = false;
        // Reset the timer for the next activation
        minigameTimer = minigameDuration;
    }

    private void Start()
    {
        // Start coroutines for each minigame
        StartCoroutine(ActivateFusebox());
        StartCoroutine(ActivateHexcode());
    }

    private void Update()
    {
        // Check for minigame activation
        if (!fuseboxActive && !hexcodeActive && Random.value < minigameActivationProbability)
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
            if (fuseboxActive)
            {
                // Minigame time is up, increase instability or decrease it if completed
                fuseboxActive = false;
                Debug.Log("Fusebox minigame time up!");
                IncreaseInstability();
            } else {
                DecreaseInstability();
            }
        }
    }

    public static int GetSwitches
    {
        get { return switchCounter; }
        set { switchCounter = value; }
    }

    public static bool GetFusebox
    {
        get {return fusebox;}
        set {fusebox = value;}
    }
    
    public static void AddSwitch(int count)
    {
        switchCounter += count;
        if (switchCounter == 8)
        {
            Debug.Log("Fusebox is fixed!");
            fuseboxActive = false;
        }
    }

    private IEnumerator ActivateHexcode()
    {
        while (true)
        {
            yield return new WaitForSeconds(hexcodeDuration);
            if (hexcodeActive)
            {
                // Minigame time is up, increase instability or decrease it if completed
                hexcodeActive = false;
                Debug.Log("Hexcode minigame time up!");
                IncreaseInstability();
            } else {
                DecreaseInstability();
            }
        }
    }
}
