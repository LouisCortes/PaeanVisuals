using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fluid2d : MonoBehaviour
{
    public fluid_dynamics fluid;
    public Material mat;
    void Start()
    {
        
    }

    
    void Update()
    {
        mat.SetTexture("_MainTex", fluid.texture1);   
    }
}
