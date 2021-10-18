using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence_Manager : MonoBehaviour
{
    public string PHASE;
    public float Tempo;
    public int SpeedValue;
    public PlayByInputAction Input;
    public Composition_Manager Compo;
    public Cam_Manager Cam;
    public bool Next;
    public bool Started;
    public bool A;
    public bool B;
    public bool Fade;
    public bool Add;
    public bool UI;
    public bool Typo;
    public bool PP;
    public bool Subdivision1;
    public bool Subdivision2;
    public bool AssignCurrentUnivers;
    public bool NouvelUnivers;
    public bool Speed;

    public Animator AC_Timer;

    void Start()
    {
        Fade = true;
        Started = true;
        PHASE = "PHASE01";
        SetAllCommandOff();
        StartCoroutine(SequenceLauncher());
    }


    void Update()
    {
    }
    
    public void ChangeSpeed()
    {
        SpeedValue++;
        if (SpeedValue> 4){
            SpeedValue = 1;
        }


    }

    public void NextSequence()
    {
        Compo.CleanAllUnivers();
        if (PHASE == "PHASE01"){ //// Passage Set 02
            Compo.LayerNameToAssign = "Univ01";
            Compo.AssignLayerAllCam();
            PHASE = "PHASE02";
            Compo.AddUnivers2();
        }else if(PHASE == "PHASE02"){ //// Passage Set 03
            Compo.LayerNameToAssign = "Univ01";
            Compo.AssignLayerAllCam();
            PHASE = "PHASE03";
            //PHASE = "PHASE03";
           // Compo.AddUnivers();
            Compo.AddUnivers3();
        }
    }

    public void Sequence()
    {
        if (Next){
            NextSequence();
            AssignCurrentUnivers = true;
        }

        if (Speed)
        {
            ChangeSpeed();
            AC_Timer.speed =  SpeedValue;
        }

        if (PP)
        {
            Cam.ActivePP01();
        }


        if (AssignCurrentUnivers)
        {
            if (PHASE == "PHASE01"){
                Compo.AddUnivers();
            }else if (PHASE == "PHASE02"){
                Compo.AddUnivers2();
            }else if (PHASE == "PHASE03"){
                Compo.AddUnivers3();
            }
        }

        if (Typo){
            Compo.TextPaeanApparition();
        }else{
            Compo.TextPaeanDisable();
        }

        if (UI){
            Compo.UIGPSApparition();
        }else{
            Compo.UIGPSDisable();
        }

        if (Fade){
            Cam.FadeCamActive();
        }else{
            Cam.FadeCamDisable();
        }

        if (!Add){
            Compo.Clean();
        }

        if (Subdivision1){
        int R; R = Random.Range(0, 5);
            if (A == true && B==false){
                if (R == 0){
                    Compo.SlicedScreenA();
                }else{
                    Compo.SlicedScreenA();
                    Compo.SlicedScreenA();
                }
            }else if (B==true && A==false){
                if (R == 0){
                    Compo.SlicedScreenB();
                }else{
                    Compo.SlicedScreenB();
                    Compo.SlicedScreenB();
                }
            }else if (A&&B){
                Debug.Log("A&B");
                Compo.SlicedScreenA();
                Compo.SlicedScreenB();
                Compo.SlicedScreenA();
                Compo.SlicedScreenB();
            }else{
                Compo.Landscape();
            }

        }else if (Subdivision2){
            if (A){
                Compo.SetupVerticalFragmentationA();
            }else if (B){
                Compo.SetupVerticalFragmentationB();
            }else {
                Compo.Subdivision();
            }
        }else{
            if (A){
                Compo.ScreenA();
            }else if (B){
                Compo.ScreenB();
            }else{
                int R; R = Random.Range(0, 6);
                if (R == 0){
                    Compo.ScreenB();
                }else if (R == 1){
                    Compo.ScreenA();
                }else{
                    Compo.SetupFullLandscape();
                }
            }
        }
        Input.CleanUI();
        SetAllCommandOff();
    }

    public void SetAllCommandOff()
    {
        Next = false;
        A = false;
        B = false;
        Subdivision1 = false;
        Subdivision2 = false;
        NouvelUnivers = false;
        AssignCurrentUnivers = false;
        Add = false;
        PP = false;
        Typo = false;
        UI = false;
        Speed = false;
    }

    IEnumerator SequenceLauncher()
    {
        for (; ; )
        {
            Sequence();
            yield return new WaitForSeconds(Tempo/SpeedValue);
        }
    }
}

