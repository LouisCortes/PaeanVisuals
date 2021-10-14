using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence_Manager : MonoBehaviour
{
    public string PHASE;
    public float Tempo;
    public PlayByInputAction Input;
    public Composition_Manager Compo;
    public bool Started;
    public bool A;
    public bool B;

    public bool Add;

    public bool Subdivision;

    public bool NouvelUnivers;

    void Start()
    {
        Started = true;
        PHASE = "PHASE01";
        SetAllCommandOff();
        StartCoroutine(SequenceLauncher());
    }


    void Update()
    {
        if (PHASE == "PHASE01")
        {

        }
    }

    public void Sequence()
    {
        if (NouvelUnivers)
        {
            if (PHASE == "PHASE01")
            {
                Compo.AddUnivers();
            }
            Compo.AssignScene = true;
        }else{
            Compo.AssignScene = false;
        }

        if (!Add)
        {
            Compo.Clean();
        }

        if (Subdivision){
            if (A){
                Compo.SetupVerticalFragmentationA();
            }else if (B){
                Compo.SetupVerticalFragmentationB();
            }else{
                Compo.Subdivision();
            }
        }else{
            if (A){
                Compo.ScreenA();
            }else if (B){
                Compo.ScreenB();
            }else{
                int R; R = Random.Range(0, 4);
                if (R == 0){
                    Compo.ScreenB();                    
                }else if (R == 1){
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
        A = false;
        B = false;
        Subdivision = false;
        NouvelUnivers = false;
    }

    IEnumerator SequenceLauncher()
    {
        for (; ; )
        {
            Debug.Log("Event APPARITION");
            Sequence();
            yield return new WaitForSeconds(Tempo);
        }

        //  StartCoroutine(PhaseXChoix());
    }
}

