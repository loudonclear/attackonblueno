using UnityEngine;
using System.Collections;
using LOS.Event;
using UnityEngine.UI;

public class InLightCounter : MonoBehaviour
{
    public Text lightCounter;
    private float lightCount = 0;
    
    private float startInLight;

    void Start()
    {
        LOSEventTrigger trigger = GetComponent<LOSEventTrigger>();
        trigger.OnNotTriggered += OnNotLit;
        trigger.OnTriggered += OnLit;

        OnNotLit();
    }

    private void OnNotLit()
    {
        if (startInLight != -1)
        {
            lightCount += Time.time - startInLight;
            lightCounter.text = lightCount.ToString();
        }
        startInLight = -1;
    }

    private void OnLit()
    {
        if (startInLight == -1)
        {
            startInLight = Time.time;
        } else
        {
            lightCount += Time.time - startInLight;
            lightCounter.text = lightCount.ToString();
            startInLight = Time.time;
        }
    }
}
