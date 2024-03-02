using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchCount : Singleton
{
    public static SwitchCount instance;
    private static int counter = 0;
    private static bool fusebox = false;

    public static int GetSwitches
    {
        get { return counter; }
        set { counter = value; }
    }

    public static bool GetSwitchesEvent
    {
        get { return fusebox; }
        set { fusebox = value; }
    }





    public static void AddSwitch(int count)
    {
        counter += count;
        if (counter == 8)
        {
            Debug.Log("Fusebox is fixed!");
        }
    }

}
