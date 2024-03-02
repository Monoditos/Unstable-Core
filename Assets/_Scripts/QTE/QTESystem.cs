using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class QTESystem : MonoBehaviour
{
    public TMP_Text keyTxt;
    public int qteGen;
    public int waiting;
    public int correct;
    private void Update()
    {
        if (waiting == 0)
        {
            qteGen = Random.Range(1, 4);
            switch (qteGen)
            {
                case 1:
                    waiting = 1;
                    keyTxt.text = "[E]";
                    break;
                case 2:
                    waiting = 1;
                    keyTxt.text = "[R]";
                    break;
                case 3:
                    waiting = 1;
                    keyTxt.text = "[T]";
                    break;
            }
        }

        if (qteGen == 1)
        {
            if (Input.anyKeyDown)
            {
                if (Input.GetButtonDown("EKey"))
                {
                    correct = 1;
                    StartCoroutine(KeyPressing());
                }
                else
                {
                    correct = 2;
                    StartCoroutine(KeyPressing());
                }
            }
        }
        if (qteGen == 2)
        {
            if (Input.anyKeyDown)
            {
                if (Input.GetButtonDown("RKey"))
                {
                    correct = 1;
                    StartCoroutine(KeyPressing());
                }
                else
                {
                    correct = 2;
                    StartCoroutine(KeyPressing());
                }
            }
        }
        if (qteGen == 3)
        {
            if (Input.anyKeyDown)
            {
                if (Input.GetButtonDown("TKey"))
                {
                    correct = 1;
                    StartCoroutine(KeyPressing());
                }
                else
                {
                    correct = 2;
                    StartCoroutine(KeyPressing());
                }
            }
        }

    }

    IEnumerator KeyPressing()
    {
        qteGen = 4;
        if (correct == 1)
        {
            Debug.Log("Correct");
            yield return new WaitForSeconds(1.5f);
            correct = 0;
            keyTxt.text = "";
            yield return new WaitForSeconds(0.5f);
            waiting = 0;
        }
        else
        {
            Debug.Log("Failed");
            yield return new WaitForSeconds(1.5f);
            correct = 0;
            keyTxt.text = "";
            yield return new WaitForSeconds(0.5f);
            waiting = 0;
        }
    }
}
