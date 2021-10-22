using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceptionRock : MonoBehaviour
{
    public fluid_dynamics fluid;
    public GettingStartedReceiving osc;
    public Material rock;
    void Start()
    {
        
    }

    
    void Update()
    {
    rock.SetTexture("_fluid", fluid.texture1);
        rock.SetFloat("_liquide", osc.liquide);
        rock.SetFloat("_audio1", osc.audio2*osc.low2 * osc.fac2 * osc.address01);
    }
}
