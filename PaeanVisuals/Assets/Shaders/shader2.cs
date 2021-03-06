using UnityEngine;
using System.Collections;
public class shader2 : MonoBehaviour
{
    public ComputeShader compute_shader;
    RenderTexture A;
    RenderTexture B;

    public GameObject img1;
    //public spectrum audioCapture;
    public Texture texture1;
    public int resx;
    public int resy;
    int handle_main;
    [Range(0, 1)]
    public float audioreaction;
    public Texture noise;
    public GettingStartedReceiving osc;

    void Start()
    { 
  
        A = new RenderTexture(resx, resy, 0);
        A.enableRandomWrite = true;
       // A.filterMode = FilterMode.Point;
        A.Create();
       
        B = new RenderTexture(resx, resy, 0);
        B.enableRandomWrite = true;
       // B.filterMode = FilterMode.Point;
        B.Create();
        handle_main = compute_shader.FindKernel("CSMain");
        
        compute_shader.SetInt("_rx", resx);
        compute_shader.SetInt("_ry", resy);
    }
   
    void Update()
    {
        //  float SpectrumAccumulation1 = audioCapture.SpectrumAccumulation1;
        compute_shader.SetTexture(handle_main, "noise", noise);
        compute_shader.SetFloat("audio1", osc.low2 *osc.fac2 * osc.address01* osc.audio2);
        compute_shader.SetFloat("audio2", osc.audio1 * osc.mid);
        compute_shader.SetFloat("audio2b", osc.audio1*osc.low);
        compute_shader.SetFloat("audio3", osc.mid2 * osc.fac2 * osc.address02 * osc.audio2);
        compute_shader.SetFloat("high",  osc.high2 * osc.fac2 * osc.address03 * osc.audio2);
        compute_shader.SetFloat("rotationv", osc.rotationv);
        compute_shader.SetFloat("zoom", osc.zoom);

        //compute_shader.SetFloat("spectrum1", audioCapture.Spectrum1);
        //compute_shader.SetFloat("spectrum2", audioCapture.Spectrum2);
        //compute_shader.SetFloat("spectrum3", audioCapture.Spectrum3);
        compute_shader.SetFloat("audio", osc.mouv);
        //compute_shader.SetFloat("SpectrumAccumulation1", SpectrumAccumulation1);
        compute_shader.SetTexture(handle_main, "texture1", texture1);
        compute_shader.SetTexture(handle_main, "reader", A);
        compute_shader.SetFloat("time", Time.time);
        compute_shader.SetTexture(handle_main, "writer", B);
        compute_shader.Dispatch(handle_main, B.width / 8, B.height / 8, 1);
        compute_shader.SetTexture(handle_main, "reader", B);
        compute_shader.SetTexture(handle_main, "writer", A);
        compute_shader.Dispatch(handle_main, B.width / 8, B.height / 8, 1);
        img1.GetComponent<Renderer>().material.mainTexture = B;

    }
  
}
