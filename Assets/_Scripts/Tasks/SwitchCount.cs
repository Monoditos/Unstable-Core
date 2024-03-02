using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchCount : Singleton
{
    public static SwitchCount instance;
    private static int counter = 0;

    public static int GetSwitches
    {
        get { return counter; }
        set { counter = value; }
    }

    public static void AddSwitch(int count)
    {
        counter += count;
        Debug.Log("Switches = " + SwitchCount.GetSwitches);
        if (counter == 8)
        {
            Debug.Log("WOW");
        }
    }

}
