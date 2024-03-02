// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using TMPro;
// public class QTESystem : MonoBehaviour
// {
//     public TMP_Text keyTxt;
//     public int qteGen;
//     public int waiting;
//     public int correct;

//     private void Update()
//     {
//         if (waiting == 0)
//         {
//             qteGen = Random.Range(1, 4);
//             switch (qteGen)
//             {
//                 case 1:
//                     waiting = 1;
//                     keyTxt.text = "[E]";
//                     break;
//                 case 2:
//                     waiting = 1;
//                     keyTxt.text = "[R]";
//                     break;
//                 case 3:
//                     waiting = 1;
//                     keyTxt.text = "[T]";
//                     break;
//             }
//         }

//         if (qteGen == 1)
//         {
//             if (Input.anyKeyDown)
//             {
//                 if (Input.GetButtonDown("EKey"))
//                 {
//                     correct = 1;
//                     StartCoroutine(KeyPressing());
//                 }
//                 else
//                 {
//                     correct = 2;
//                     StartCoroutine(KeyPressing());
//                 }
//             }
//         }
//         if (qteGen == 2)
//         {
//             if (Input.anyKeyDown)
//             {
//                 if (Input.GetButtonDown("RKey"))
//                 {
//                     correct = 1;
//                     StartCoroutine(KeyPressing());
//                 }
//                 else
//                 {
//                     correct = 2;
//                     StartCoroutine(KeyPressing());
//                 }
//             }
//         }
//         if (qteGen == 3)
//         {
//             if (Input.anyKeyDown)
//             {
//                 if (Input.GetButtonDown("TKey"))
//                 {
//                     correct = 1;
//                     StartCoroutine(KeyPressing());
//                 }
//                 else
//                 {
//                     correct = 2;
//                     StartCoroutine(KeyPressing());
//                 }
//             }
//         }

//     }

//     IEnumerator KeyPressing()
//     {
//         qteGen = 4;
//         if (correct == 1)
//         {
//             Debug.Log("Correct");
//             yield return new WaitForSeconds(1.5f);
//             correct = 0;
//             keyTxt.text = "";
//             yield return new WaitForSeconds(0.5f);
//             waiting = 0;
//         }
//         else
//         {
//             Debug.Log("Failed");
//             yield return new WaitForSeconds(1.5f);
//             correct = 0;
//             keyTxt.text = "";
//             yield return new WaitForSeconds(0.5f);
//             waiting = 0;
//         }
//     }
//     private void EndQTE()
//     {
//         // Add any additional logic for ending the QTE due to the timer reaching 0
//         Debug.Log("QTE Ended - Time Expired");
//         keyTxt.text = "";
//         waiting = 0;
//     }
// }
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
        qteGen = Random.Range(1, 4);
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
            Debug.Log("Correct");
            if (EventController.GetStreak == 6)
            {
                EndQTE(1);
            }
        }
        else
        {
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
            Debug.Log("Time Expired on the Security Door");
            keyTxt.text = "";
        }
        if (reason == 1)
        {
            Debug.Log("Door secured successfully");
            keyTxt.text = "";
        }
        if (reason == 2)
        {
            Debug.Log("Wrong key pressed, door security compromised");
            keyTxt.text = "";
        }
        // Add any additional logic for ending the QTE due to the timer reaching 0
    }
}
