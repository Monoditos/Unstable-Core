using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Switches : MonoBehaviour
{
    public SpriteRenderer on, off;
    public bool isOn;
    void Start()
    {
        on.enabled = isOn;
        off.enabled = !isOn;
        if (isOn)
        {
            SwitchCount.SwitchChange(1);
        }
    }
    private void OnMouseUp()
    {
        isOn = !isOn;
        on.enabled = isOn;
        off.enabled = !isOn;
        if (isOn)
        {
            SwitchCount.Instance.SwitchChange(1);
        }
        else
        {
            SwitchCount.Instance.SwitchChange(-1);
        }
    }
}
