using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchCount : MonoBehaviour
{
    public static SwitchCount instance;
    void Awake()
    {
        //Singleton
        if (instance == null)
        {
            instance = this;
        }
    }

    public int total = 8;
    private static int counter = 0;
    public GameObject greenBar;

    public static int GetSwitches
    {
        get { return counter; }
        set { counter = value; }
    }
    public void SwitchChange(int points)
    {
        counter += points;
        greenBar.GetComponent<Image>().fillAmount = points / total;
        if (counter == total)
        {
            Debug.Log("All switches are on!");
        }
        else
        {
            Debug.Log("Switches on: " + counter);
        }
    }
}
