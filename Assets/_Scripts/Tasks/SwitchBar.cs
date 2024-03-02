using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SwitchBar : MonoBehaviour
{

    public float fillGreen;
    private int total = 8;
    public GameObject greenBar;

    void Update()
    {
        fillGreen = (float)EventController.GetSwitches;
        fillGreen = fillGreen / total;
        greenBar.GetComponent<Image>().fillAmount = fillGreen;
    }
}
