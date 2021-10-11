﻿using UnityEngine;

public class fluid_dynamics : MonoBehaviour
{
    public ComputeShader compute_shader;
    RenderTexture A;
    RenderTexture B;
    public Material material;
    public Texture texture1;
    int handle_main;
    public GameObject Shader03;
    void Start()
    {
        A = new RenderTexture(1024, 1024, 0);
        A.enableRandomWrite = true;
        A.Create();
        B = new RenderTexture(1024, 1024, 0);
        B.enableRandomWrite = true;
        B.Create();
        handle_main = compute_shader.FindKernel("CSMain");
    }

    void Update()
    {
        compute_shader.SetFloat("time", Time.time);
        compute_shader.SetTexture(handle_main, "texture1", texture1);
        compute_shader.SetTexture(handle_main, "reader", A);
        compute_shader.SetTexture(handle_main, "writer", B);
        compute_shader.Dispatch(handle_main, A.width / 8, A.height / 8, 1);
        compute_shader.SetTexture(handle_main, "reader", B);
        compute_shader.SetTexture(handle_main, "writer", A);
        compute_shader.Dispatch(handle_main, B.width / 8, B.height / 8, 1);
        material.mainTexture = B;  
       // Shader03.
    }
}