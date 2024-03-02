using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SwitchBar : MonoBehaviour
{

    public float fillGreen;
    public int total = 8;
    public GameObject greenBar;
    public GameObject miniGame;


    void Update()
    {
        fillGreen = (float)EventController.GetSwitches;
        fillGreen = fillGreen / total;
        greenBar.GetComponent<Image>().fillAmount = fillGreen;
        if (fillGreen == 1)
        {
            miniGame.SetActive(false);
        }
    }
}
