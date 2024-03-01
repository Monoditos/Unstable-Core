using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SwitchBar : MonoBehaviour
{
    public float fillGreen;
    public int total = 8;
    public GameObject greenBar;


    // Update is called once per frame
    void Update()
    {
        fillGreen = (float)SwitchCount.GetSwitches;
        fillGreen = fillGreen / total;
        maxHeartContainer.GetComponent<Image>().fillAmount = fillMax;
    }
}
