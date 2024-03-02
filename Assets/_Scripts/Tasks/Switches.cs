using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Switches : MonoBehaviour
{
    public GameObject on, off;
    public int counter;
    public bool isOn;
    public float randomValue, randomChange;

    void Start()
    {
        randomValue = Random.value;
        if (randomValue < 0.40)
        {
            isOn = true;
        }
        else
        {
            isOn = false;
        }
        counter = SwitchCount.GetSwitches;
        on.SetActive(isOn);
        off.SetActive(!isOn);
        if (isOn)
        {
            SwitchCount.AddSwitch(1);
        }
    }

    private void Update()
    {
        StartCoroutine(RandomlySelectFalseEachSecond());
        counter = SwitchCount.GetSwitches;
    }
    public void OnMouseUp()
    {
        isOn = !isOn;
        on.SetActive(isOn);
        off.SetActive(!isOn);
        if (isOn)
        {
            SwitchCount.AddSwitch(1);
        }
        else
        {
            SwitchCount.AddSwitch(-1);
        }
    }

    IEnumerator RandomlySelectFalseEachSecond()
    {
        randomChange = Random.value;
        if (randomChange <= 0.00003 && isOn == true)
        {
            isOn = false;
            on.SetActive(isOn);
            off.SetActive(!isOn);
            SwitchCount.AddSwitch(-1);
            yield return new WaitForSeconds(Random.value*2f);
        }
        yield return new WaitForSeconds(2f);
    }
}












/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Switches : MonoBehaviour
{
    public SpriteRenderer on, off;
    public int counter;
    public bool isOn;
    public float randomValue, randomChange;

    void Start()
    {
        randomValue = Random.value;
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
        StartCoroutine(RandomlySelectFalseEachSecond());
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

    IEnumerator RandomlySelectFalseEachSecond()
    {
        randomChange = Random.value;
        Debug.Log(randomChange);
        if (randomChange <= 0.001 && isOn == true)
        {
            isOn = false;
            on.enabled = isOn;
            off.enabled = !isOn;
            SwitchCount.AddSwitch(-1);
            yield return new WaitForSeconds(1.5f);
        }
        yield return new WaitForSeconds(1.5f);
    }
}*/