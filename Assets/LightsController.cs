using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsController : MonoBehaviour
{
    
    public Light[] lights;

    void Start()
    {
        lights = GetComponentsInChildren<Light>();
    }

    // Update is called once per frame
    
    void Update()
    {
        if (EventController.GetInstability >= 60)
        {
            foreach (Light light in lights)
            {
                light.range = 7;
                light.color = Color.red;
                StartCoroutine(BlinkLight(light, 5f));
            }
        }
        else
        {
            foreach (Light light in lights)
            {
                light.range = 5;
                light.color = new Color(211f / 255f, 172f / 255f, 85f / 255f);
                StopAllCoroutines();
            }
        }
    }

    IEnumerator BlinkLight(Light light, float duration)
    {
        float endTime = Time.time + duration;
        while (Time.time < endTime)
        {
            light.intensity = 0;
            yield return new WaitForSeconds(0.5f);
            light.intensity = 13.69f;
            yield return new WaitForSeconds(0.5f);
        }
    }
}
