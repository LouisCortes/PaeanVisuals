using UnityEngine;
using System.Collections;
public class Shader1 : MonoBehaviour
{
    public ComputeShader compute_shader;
    RenderTexture A;
    public GameObject img1;
    public int resx;
    public int resy;
    int handle_main;
    public fluid_dynamics fluid;
    public Texture texture0;
    public Texture texture1;
    public Texture noise;
    public GameObject probe;
    public GettingStartedReceiving osc;
    [Range(0, 1)]
    public float liquide;
    [Range(0, 1)]
    public float audio;
    void Start()
    { 
  
        A = new RenderTexture(resx, resy, 0);
        A.enableRandomWrite = true;
        A.Create();
        handle_main = compute_shader.FindKernel("CSMain");
    }
   
    void Update()
    {
       

        compute_shader.SetTexture(handle_main, "reader", A);
        compute_shader.SetTexture(handle_main, "texture0", texture0);
        compute_shader.SetTexture(handle_main, "texture1", texture1);
        compute_shader.SetTexture(handle_main, "texf", fluid.texture1);
        compute_shader.SetTexture(handle_main, "noise", noise);
        compute_shader.SetTexture(handle_main, "ref",probe.GetComponent<ReflectionProbe>().texture );
       compute_shader.SetFloat("_time", Time.time);
       // compute_shader.SetFloat("liquide", liquide);
        compute_shader.SetInt("_rx", resx);
        compute_shader.SetInt("_ry", resy);
        compute_shader.SetFloat("liquide", osc.liquide);
        compute_shader.SetFloat("audio1", osc.low2*osc.audio2 * osc.address01 * osc.fac2);
        compute_shader.SetFloat("audio2", osc.high2 * osc.audio2 * osc.address03 * osc.fac2);
        //compute_shader.SetFloat("audio2", osc.high2  * osc.address03 * osc.fac2);
        compute_shader.SetFloat("regaudio2", osc.mouv);
        compute_shader.SetFloat("audio3", osc.audio1 * osc.low);
        compute_shader.SetFloat("audio4", osc.audio1 * osc.high);
        compute_shader.SetFloat("zoom", osc.zoom);
        //compute_shader.SetTexture(handle_main, "writer", B);
        //compute_shader.Dispatch(handle_main, B.width / 8, B.height / 8, 1);
        //compute_shader.SetTexture(handle_main, "reader", B);
        //compute_shader.SetTexture(handle_main, "writer", A);
        compute_shader.Dispatch(handle_main, A.width / 8, A.height / 8, 1);
        img1.GetComponent<Renderer>().material.mainTexture = A;

    }
  
}
