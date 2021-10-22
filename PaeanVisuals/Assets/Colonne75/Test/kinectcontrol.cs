using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kinectcontrol : MonoBehaviour
{
    public GettingStartedReceiving osc;
    public Material nuage;
    public float audio2;
    public GameObject center;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        nuage.SetFloat("_liquide", osc.liquide2);
        nuage.SetFloat("_audio1", osc.audio1);
        //nuage.SetFloat("_audio2", osc.mid * osc.address02 * osc.audio2 * osc.fac2);
        nuage.SetFloat("_audio2", osc.address01 *audio2);
        nuage.SetFloat("_centerx", center.transform.position.x);
        nuage.SetFloat("_centery", center.transform.position.y);
        nuage.SetFloat("_centerz", center.transform.position.z);

    }
}
