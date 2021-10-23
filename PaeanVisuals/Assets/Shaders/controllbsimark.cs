using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controllbsimark : MonoBehaviour
{
    public GettingStartedReceiving osc;
    public PointAnimation obj1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        obj1._audio1 = osc.audio1 * osc.low;
        obj1._audio4 =  osc.audio1 * osc.mid;
        obj1._audio2 = osc.low2 * osc.address01 * osc.audio2 * osc.fac2;
        obj1._audio3 = osc.mid2 * osc.address02 * osc.audio2 * osc.fac2;
    }
}
