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
    public Camera[] A10;
    public Camera[] A1_0;
    public Camera[] A2_0;
    public Camera B;
    public Camera[] B0;
    public Camera[] B10;
    public Camera[] B1_0;
    public Camera[] B2_0;

    public int i;

    void Start()
    {
        i = 1;
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
    public void CamStopAnim()
    {
        AC_Cam.SetBool("Animate", false);
        AC_Cam.SetBool("Crossed", false);
        AC_Cam.SetBool("Melt", true);
    }


    public void SwitchCamOrtho()
    {
        i++;
        if (i ==1)
        {
            A10[0].orthographic = true; A10[1].orthographic = true;
            A.orthographic = true;
            A0[0].orthographic = true; A0[1].orthographic = true;
            A1_0[0].orthographic = true; A1_0[1].orthographic = true; A1_0[2].orthographic = true; A2_0[0].orthographic = true; A1_0[1].orthographic = true; A1_0[2].orthographic = true;

            B.orthographic = true;
            B10[0].orthographic = true; B10[1].orthographic = true;
            B0[0].orthographic = true; B0[1].orthographic = true;
            B1_0[0].orthographic = true; B1_0[1].orthographic = true; B1_0[2].orthographic = true; B2_0[0].orthographic = true; B2_0[1].orthographic = true; B2_0[2].orthographic = true;
            Debug.Log("FullOrtho");

        }
        else if (i == 2)
        {
            A10[0].orthographic = false; A10[1].orthographic = false;
            A.orthographic = false;
            A0[0].orthographic = false; A0[1].orthographic = false;
            A1_0[0].orthographic = false; A1_0[1].orthographic = false; A1_0[2].orthographic = false; A2_0[0].orthographic = false; A2_0[1].orthographic = false; A2_0[2].orthographic = false;
            Debug.Log("A Perspective");
        }
        else if (i == 3)
        {
            B.orthographic = false;
            B10[0].orthographic = false; B10[1].orthographic = false;
            B0[0].orthographic = false; B0[1].orthographic = false;
            B1_0[0].orthographic = false; B1_0[1].orthographic = false; B1_0[2].orthographic = false; B2_0[0].orthographic = false; B2_0[1].orthographic = false; B2_0[2].orthographic = false;
            Debug.Log("Full Perspective");
            i = 0;
        }
    }




/*
    public void SetCamOrthoA()
    {
        if (!A.orthographic){
            //AB.orthographic = true;
            A10[0].orthographic = true; A10[1].orthographic = true;
            A.orthographic = true;
            A0[0].orthographic = true;      A0[1].orthographic = true;
            A1_0[0].orthographic = true;    A1_0[1].orthographic = true;    A1_0[2].orthographic = true;    A2_0[0].orthographic = true;    A1_0[1].orthographic = true;    A1_0[2].orthographic = true;
        }else{
            //  AB.orthographic = true;
            A10[0].orthographic = false; A10[1].orthographic = false;
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

            B10[0].orthographic = true;     B10[1].orthographic = true;

            B0[0].orthographic = true;      B0[1].orthographic = true;
            B1_0[0].orthographic = true;    B1_0[1].orthographic = true;    B1_0[2].orthographic = true;    B2_0[0].orthographic = true;    B2_0[1].orthographic = true;    B2_0[2].orthographic = true;
        }else{

            B.orthographic = false;
            B10[0].orthographic =false; B10[1].orthographic = false;

            B0[0].orthographic = false;     B0[1].orthographic = false;
            B1_0[0].orthographic = false;   B1_0[1].orthographic = false;   B1_0[2].orthographic = false;   B2_0[0].orthographic = false;   B2_0[1].orthographic = false;   B2_0[2].orthographic = false;
            //B.orthographicSize = 5.0f;
        }
    }
    */

    public void ResetAll()
    {
        AC_Cam.SetBool("Animate", false);
        AC_Cam.SetBool("Melt", false);
        AC_Cam.SetBool("Crossed", false);
    }

    public void FadeCamActive()
    {       
            AB.GetComponent<Animator>().enabled = true;

            A10[0].GetComponent<Animator>().enabled = true; A10[1].GetComponent<Animator>().enabled = true;
            A.GetComponent<Animator>().enabled = true;
            A0[0].GetComponent<Animator>().enabled = true; A0[1].GetComponent<Animator>().enabled = true;
            A1_0[0].GetComponent<Animator>().enabled = true; A1_0[1].GetComponent<Animator>().enabled = true; A1_0[2].GetComponent<Animator>().enabled = true; A2_0[0].GetComponent<Animator>().enabled = true; A2_0[1].GetComponent<Animator>().enabled = true; A2_0[2].GetComponent<Animator>().enabled = true;

            B10[0].GetComponent<Animator>().enabled = true; B10[1].GetComponent<Animator>().enabled = true;
            B.GetComponent<Animator>().enabled = true;
            B0[0].GetComponent<Animator>().enabled = true; B0[1].GetComponent<Animator>().enabled = true;
            B1_0[0].GetComponent<Animator>().enabled = true; B1_0[1].GetComponent<Animator>().enabled = true; B1_0[2].GetComponent<Animator>().enabled = true; B2_0[0].GetComponent<Animator>().enabled = true; B2_0[1].GetComponent<Animator>().enabled = true; B2_0[2].GetComponent<Animator>().enabled = true;            
    }
    public void FadeCamDisable()
    {
            AB.GetComponent<Animator>().enabled = false;

            A10[0].GetComponent<Animator>().enabled = false; A10[1].GetComponent<Animator>().enabled = false;
            A.GetComponent<Animator>().enabled = false;
            A0[0].GetComponent<Animator>().enabled = false; A0[1].GetComponent<Animator>().enabled = false;
            A1_0[0].GetComponent<Animator>().enabled = false; A1_0[1].GetComponent<Animator>().enabled = false; A1_0[2].GetComponent<Animator>().enabled = false; A2_0[0].GetComponent<Animator>().enabled = false; A2_0[1].GetComponent<Animator>().enabled = false; A2_0[2].GetComponent<Animator>().enabled = false;

            B10[0].GetComponent<Animator>().enabled = false; B10[1].GetComponent<Animator>().enabled = false;
            B.GetComponent<Animator>().enabled = false;
            B0[0].GetComponent<Animator>().enabled = false; B0[1].GetComponent<Animator>().enabled = false;
            B1_0[0].GetComponent<Animator>().enabled = false; B1_0[1].GetComponent<Animator>().enabled = false; B1_0[2].GetComponent<Animator>().enabled = false; B2_0[0].GetComponent<Animator>().enabled = false; B2_0[1].GetComponent<Animator>().enabled = false; B2_0[2].GetComponent<Animator>().enabled = false;
    }
    

}
