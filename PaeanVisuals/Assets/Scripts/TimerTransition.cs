using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class TimerTransition : MonoBehaviour
{
    public bool CounterOn;
    public int Min;
    public Text UIMin;

    void Start()
    {
        CounterOn = true;
        StartCoroutine(Minute());
    }

    // Update is called once per frame
    void Update()
    {
        if (CounterOn)
        {
            UIMin.text = "00 : " + Min;
        }else
        {
            UIMin.text = "Performance Soon";
        }


    }
    public void DecreaseMinute()
    {
        if (Min > 0)
        {
            CounterOn = true;
            Min--;
        }
        else
        {
            CounterOn = false;
        }
    }

    IEnumerator Minute()
    {
        for (; ; )
        {
            DecreaseMinute();
            yield return new WaitForSeconds(60);
        }
    }
}
