using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kinectcontrol : MonoBehaviour
{
    public GettingStartedReceiving osc;
    public Material rock;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rock.SetFloat("_liquide", osc.liquide);
        rock.SetFloat("_audio1", osc.audio1);
        rock.SetFloat("_audio2", osc.mid * osc.address02 * osc.audio2 * osc.fac2);
    }
}
