using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Switches : MonoBehaviour
{
    public SpriteRenderer on, off;
    public int counter;
    public bool isOn;
    public float randomValue;

    void Start()
    {
        randomValue = Random.value;
        Debug.Log("Random Value: " + randomValue);
        if (randomValue < 0.40)
        {
            isOn = true;
        }
        else
        {
            isOn = false;
        }
        counter = SwitchCount.GetSwitches;
        on.enabled = isOn;
        off.enabled = !isOn;
        if (isOn)
        {
            SwitchCount.AddSwitch(1);
        }
    }

    private void Update()
    {
        counter = SwitchCount.GetSwitches;
    }
    private void OnMouseUp()
    {
        isOn = !isOn;
        on.enabled = isOn;
        off.enabled = !isOn;
        if (isOn)
        {
            SwitchCount.AddSwitch(1);
        }
        else
        {
            SwitchCount.AddSwitch(-1);
        }
    }
}