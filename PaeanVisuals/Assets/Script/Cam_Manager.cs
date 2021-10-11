using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam_Manager : MonoBehaviour
{
    public float RandomSpeed;
    public bool Cam_Translation;
    public Animator AC_Cam;
    public Camera AB;
    public Camera A;
    public Camera[] A0;
    public Camera[] A1_0;
    public Camera[] A2_0;
    public Camera B;
    public Camera[] B0;
    public Camera[] B1_0;
    public Camera[] B2_0;

    void Start()
    {
    }

    void Update()
    {
        
    }

    public void CamTranslation()
    {
        RandomSpeed = Random.Range(1f, 3f);
        AC_Cam.speed = RandomSpeed;
        AC_Cam.SetBool("Melt", false);
        AC_Cam.SetBool("Crossed", false);
        AC_Cam.SetBool("Animate", true);
    }
    public void CamTranslationCrossed()
    {
        RandomSpeed = Random.Range(2f, 5f);
        AC_Cam.speed = RandomSpeed;
        AC_Cam.SetBool("Animate", false);
        AC_Cam.SetBool("Crossed", true);
    }
    public void CamTranslationMelt()
    {
        RandomSpeed = Random.Range(3f, 7f);
        AC_Cam.SetBool("Crossed", false);
        AC_Cam.SetBool("Melt", true);
    }

    public void SetCamOrthoA()
    {
        if (!A.orthographic){
            A.orthographic = true;
            A0[0].orthographic = true;      A0[1].orthographic = true;
            A1_0[0].orthographic = true;    A1_0[1].orthographic = true;    A1_0[2].orthographic = true;    A2_0[0].orthographic = true;    A1_0[1].orthographic = true;    A1_0[2].orthographic = true;
        }else{
            A.orthographic = false;
            A0[0].orthographic = false;     A0[1].orthographic = false;
            A1_0[0].orthographic = false;   A1_0[1].orthographic = false;   A1_0[2].orthographic = false;   A2_0[0].orthographic = false;   A2_0[1].orthographic = false;   A2_0[2].orthographic = false;
            //A.orthographicSize = 5.0f;
        }
    }
    public void SetCamOrthoB()
    {
        if (!B.orthographic){
            B.orthographic = true;
            B0[0].orthographic = true;      B0[1].orthographic = true;
            B1_0[0].orthographic = true;    B1_0[1].orthographic = true;    B1_0[2].orthographic = true;    B2_0[0].orthographic = true;    B2_0[1].orthographic = true;    B2_0[2].orthographic = true;
        }else{            
            B.orthographic = false;
            B0[0].orthographic = false;     B0[1].orthographic = false;
            B1_0[0].orthographic = false;   B1_0[1].orthographic = false;   B1_0[2].orthographic = false;   B2_0[0].orthographic = false;   B2_0[1].orthographic = false;   B2_0[2].orthographic = false;
            //B.orthographicSize = 5.0f;
        }
    }

   /* public void SwitchLayerMask()
    {
        int layer1 = LayerMask.NameToLayer("MyLayer1");
        int layer2 = LayerMask.NameToLayer("MyLayer2");

        cam.cullingMask = (1 << layer1) | (1 << layer2);
    }*/

    public void ResetAll()
    {
        AC_Cam.SetBool("Animate", false);
        AC_Cam.SetBool("Melt", false);
        AC_Cam.SetBool("Crossed", false);
    }
}
