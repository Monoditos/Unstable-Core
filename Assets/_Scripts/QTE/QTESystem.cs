using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QTESystem : MonoBehaviour
{
    public TMP_Text keyTxt;
    private int qteGen;
    private int waiting;
    private int correct;
    private bool canProcessInput = true; // Flag to control input processing

    public float qteTimerDuration = 1f; // Adjust the timer duration as needed

    private void Update()
    {
        if (waiting == 0 && canProcessInput)
        {
            GenerateQTE();
        }

        HandleInput();
    }

    private void GenerateQTE()
    {
        qteGen = Random.Range(1, 5);
        waiting = 1;

        switch (qteGen)
        {
            case 1:
                keyTxt.text = "[E]";
                break;
            case 2:
                keyTxt.text = "[R]";
                break;
            case 3:
                keyTxt.text = "[T]";
                break;
            case 4:
                keyTxt.text = "[Y]";
                break;
        }

        StartCoroutine(StartQTETimer());
    }

    private IEnumerator StartQTETimer()
    {
        float timer = qteTimerDuration;

        while (timer > 0f)
        {
            yield return null; // Wait for the next frame
            timer -= Time.deltaTime;
        }

        EndQTE(0);
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            CheckInput(1);
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            CheckInput(2);
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            CheckInput(3);
        }
        else if (Input.GetKeyDown(KeyCode.Y))
        {
            CheckInput(4);
        }
    }

    private void CheckInput(int expectedKey)
    {
        StopAllCoroutines(); // Stop the timer when a key is pressed

        if (qteGen == expectedKey)
        {
            correct = 1;
        }
        else
        {
            correct = 2;
        }

        StartCoroutine(KeyPressing());
    }

    IEnumerator KeyPressing()
    {
        canProcessInput = false; // Disable input processing during coroutine execution

        qteGen = 4;

        if (correct == 1)
        {
            EventController.GetStreak++;
            if (EventController.GetStreak == 6)
            {
                EndQTE(1);
            }
        }
        else
        {
            Debug.LogError("Incorrect key pressed");
            EndQTE(2);
        }

        yield return new WaitForSeconds(0.5f);

        correct = 0;
        keyTxt.text = "";
        yield return new WaitForSeconds(0.5f);

        waiting = 0;
        canProcessInput = true; // Enable input processing after coroutine execution
    }

    private void EndQTE(int reason)
    {
        EventController.GetStreak = 0;
        if (reason == 0)
        {
            waiting = 0;
            canProcessInput = true;
            EventController.CriticalError(3);
            keyTxt.text = "";
        }
        if (reason == 1)
        {
            waiting = 0;
            canProcessInput = true;
            EventController.GetQTECompleted = true;
            EventController.GetQTE = false;
            keyTxt.text = "";
        }
        if (reason == 2)
        {
            waiting = 0;
            canProcessInput = true;
            EventController.CriticalError(3);
            keyTxt.text = "";
        }
        // Add any additional logic for ending the QTE due to the timer reaching 0
    }
}
