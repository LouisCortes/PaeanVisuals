using UnityEngine;
using System.Collections;
public class shader3 : MonoBehaviour
{
    public ComputeShader compute_shader;
    RenderTexture A;
    RenderTexture B;
    RenderTexture C;
    RenderTexture D;
    //public Texture texture1;
    public GameObject img1;
    public spectrum audioCapture;
    public fluid_dynamics fluid;
    public GettingStartedReceiving osc;

    public int resx;
    public int resy;
    int handle_main;

    void Start()
    { 
  
        A = new RenderTexture(resx, resy, 0);
        A.enableRandomWrite = true;
        A.Create();
       
        B = new RenderTexture(resx, resy, 0);
        B.enableRandomWrite = true;
        B.Create();

        handle_main = compute_shader.FindKernel("CSMain");
        
        compute_shader.SetInt("_rx", resx);
        compute_shader.SetInt("_ry", resy);
    }
   
    void Update()
    {
        compute_shader.SetTexture(handle_main, "texture1", fluid.texture1);
        compute_shader.SetFloat("audio1", osc.low * osc.fac2 * osc.address01);
        compute_shader.SetFloat("audio2", osc.audio2);
        compute_shader.SetFloat("high", osc.high * osc.fac2 * osc.address03);
        compute_shader.SetFloat("rotationv", osc.rotationv);
        compute_shader.SetFloat("zoom", osc.zoom);
        float SpectrumAccumulation1 = audioCapture.SpectrumAccumulation1;
        compute_shader.SetFloat("spectrum2", audioCapture.Spectrum2);
        compute_shader.SetFloat("SpectrumAccumulation1", SpectrumAccumulation1);
        compute_shader.SetFloat("time", Time.time);
        compute_shader.SetTexture(handle_main, "reader", A);
        compute_shader.SetTexture(handle_main, "writer", B);
        compute_shader.Dispatch(handle_main, B.width / 8, B.height / 8, 1);
        compute_shader.SetTexture(handle_main, "reader", B);
        compute_shader.SetTexture(handle_main, "writer", A);
        compute_shader.Dispatch(handle_main, B.width / 8, B.height / 8, 1);


        img1.GetComponent<Renderer>().material.mainTexture = B;

    }
  
}
