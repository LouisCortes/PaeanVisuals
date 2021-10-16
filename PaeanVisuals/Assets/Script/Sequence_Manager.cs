using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence_Manager : MonoBehaviour
{
    public string PHASE;
    public float Tempo;
    public int Speed;
    public PlayByInputAction Input;
    public Composition_Manager Compo;
    public Cam_Manager Cam;
    public Scene_Manager Scene;
    public bool Next;
    public bool Started;
    public bool A;
    public bool B;

    public bool Fade;
    public bool Add;

    public bool UI;
    public bool Paean;
    public bool PP;

    public bool Subdivision1;
    public bool Subdivision2;

    public bool AssignCurrentUnivers;
    public bool NouvelUnivers;
    public bool SphereLiquide;

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
        Speed++;
        if (Speed> 4){
            Speed = 1;
        }
    }

    public void NextSequence()
    {
        Compo.CleanAllUnivers();
        if (PHASE == "PHASE01"){
            Compo.LayerNameToAssign = "Rock01";
            PHASE = "PHASE02";
            Compo.AddUnivers2();
        }else if(PHASE == "PHASE02"){
            Compo.LayerNameToAssign = "Rock04";
            Compo.AssignLayerAllCam();
            PHASE = "PHASE01";
            Compo.AddUnivers();
        }
    }

    public void Sequence()
    {
        if (Next){
            NextSequence();
            AssignCurrentUnivers = true;
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
            }
        }

        if (Paean){
            Scene.TextPaeanApparition();
        }else{
            Scene.TextPaeanDisable();
        }

        if (UI){
            Scene.UIGPSApparition();
        }else{
            Scene.UIGPSDisable();
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
            }else if (A&&B)
            {
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
                }
                else if (R == 1){
                    Compo.ScreenA();
                }else{
                    Compo.SetupFullLandscape();
                }
            }
        }
      

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
        Paean = false;
        UI = false;
    }

    IEnumerator SequenceLauncher()
    {
        for (; ; )
        {
            Debug.Log("Event APPARITION");
            Sequence();
            yield return new WaitForSeconds(Tempo/Speed);
        }
        //  StartCoroutine(PhaseXChoix());
    }
}

