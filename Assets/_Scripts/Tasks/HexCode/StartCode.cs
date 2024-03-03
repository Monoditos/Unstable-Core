using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StartCode : MonoBehaviour
{
    public TMP_Text wordTxt;
    public TMP_InputField answerTxt;
    private AudioController audioController;
    Codes codeUsed;
    public List<Codes> codeList = new List<Codes>();

    private void Start()
    {
        audioController = GameObject.Find("AudioManager").GetComponent<AudioController>();
        codeUsed = GetCode();
        Debug.Log("Code used: " + codeUsed.word);
        wordTxt.text = codeUsed.word;
    }
    Codes GetCode()
    {

        int randomNum = Random.Range(1, 101);
        Debug.Log("Random number: " + randomNum);
        List<Codes> possibleCodes = new List<Codes>();
        foreach (Codes code in codeList)
        {
            if (randomNum <= code.spawnChance)
            {
                possibleCodes.Add(code);
            }
        }
        if (possibleCodes.Count > 0)
        {
            int lowestProb = 101;
            Codes codeWithLowestProb = null;
            foreach (Codes code in possibleCodes)
            {
                if (code.spawnChance < lowestProb)
                {
                    lowestProb = code.spawnChance;
                    codeWithLowestProb = code;
                }
            }
            return codeWithLowestProb;
        }
        else
        {
            return null;
        }
    }

    public void CheckAnswer()
    {
        if (answerTxt.text == codeUsed.answer)
        {
            EventController.GetHexcodeCompleted = true;
            EventController.GetHexcode = false;
            Debug.Log("Hex solved.");
        }
        else
        {
            EventController.CriticalError(2);
            audioController.PlaySoundEffect("erro");
            Debug.LogError("Incorrect, damages were suffered!");
        }
    }

}
