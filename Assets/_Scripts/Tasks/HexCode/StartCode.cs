using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCode : MonoBehaviour
{

    public List<Codes> codeList = new List<Codes>();
    Codes GetCode()
    {

        int randomNum = Random.Range(1, 101);
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



}
