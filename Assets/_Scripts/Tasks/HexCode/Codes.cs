using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class Codes : ScriptableObject
{
    public string word;
    public string answer;
    public int spawnChance;

    public Codes(string word, string answer, int spawnChance)
    {
        this.word = word;
        this.answer = answer;
        this.spawnChance = spawnChance;
    }
}
