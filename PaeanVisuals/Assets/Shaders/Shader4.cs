using UnityEngine;
using System.Collections;
public class Shader4 : MonoBehaviour
{
    public ComputeShader compute_shader;
    RenderTexture A;
    public GameObject img1;
    public int resx;
    public int resy;
    int handle_main;
    public Texture2D ao;
    public Texture2D height;
    public Texture2D rough;
    public Texture2D albedo;
    public fluid_dynamics fluid;
    public Texture2D noise;
   // public Texture2D lut;
    public GameObject probe;
    [Range(0, 1)]
    public float liquide;
    [Range(-6, 6)]
    public float rotation;
    [Range(0, 1)]
    public float audio1;
    [Range(0, 1)]
    public float neutre;
    [Range(0, 1)]
    public float bleu;
    [Range(0, 1)]
    public float zoom;
    public GettingStartedReceiving osc;
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
        compute_shader.SetTexture(handle_main, "ao", ao);
        compute_shader.SetTexture(handle_main, "height", height);
        compute_shader.SetTexture(handle_main, "rough", rough);
        compute_shader.SetTexture(handle_main, "albedo", albedo);
        compute_shader.SetTexture(handle_main, "noise", noise);
        compute_shader.SetTexture(handle_main, "fluid", fluid.texture1);
        //compute_shader.SetTexture(handle_main, "lut", lut);
        compute_shader.SetTexture(handle_main, "ref",probe.GetComponent<ReflectionProbe>().texture );
       compute_shader.SetFloat("_time", Time.time);
        compute_shader.SetFloat("liquide", osc.liquide+liquide);
        compute_shader.SetFloat("rotation", osc.rotationv+rotation);
        compute_shader.SetFloat("audio1", osc.audio1+audio1);
        compute_shader.SetFloat("audio2", osc.audio2);
        compute_shader.SetFloat("mid", osc.mid *osc.address01);
        compute_shader.SetFloat("low", osc.low * osc.address02);
        compute_shader.SetFloat("high", osc.high *osc.address03);
        compute_shader.SetFloat("neutre",1-( osc.neutre+neutre));
        compute_shader.SetFloat("bleu", osc.bleu+bleu);
        compute_shader.SetFloat("zoom", osc.zoom+zoom);
        compute_shader.SetInt("_rx", resx);
        compute_shader.SetInt("_ry", resy);
        compute_shader.Dispatch(handle_main, A.width / 8, A.height / 8, 1);
        img1.GetComponent<Renderer>().material.mainTexture = A;

    }
  
}
