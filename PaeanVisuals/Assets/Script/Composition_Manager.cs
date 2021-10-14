using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Composition_Manager : MonoBehaviour
{
    public Cam_Manager CM;
    public string LayerNameToAssign;
    public bool AssignScene;
    public bool AssignBlink;
    private bool Blink;
    private float ValueBlink;
    private LayerMask LY;

    public GameObject[] PullUniversPhase01;
    public GameObject[] PullUniversPhase02;

    public GameObject ABLandscape;
    public GameObject A;
    public GameObject[] A0;
    public GameObject[] A10;
    public GameObject[] A1_0;
    public GameObject[] A2_0;

    public GameObject B;
    public GameObject[] B0;
    public GameObject[] B10;
    public GameObject[] B1_0;
    public GameObject[] B2_0;

    public GameObject Fluide;

    public int NumberOfUnivers;
    private int FragmentationIntensity;
    private int i;

    void Start()
    {       
        CleanAllUnivers();
        Blink = false;
        AssignBlink = false;
        AssignScene = false;
        i = 0;
        FragmentationIntensity = 0;
        Clean();
        LY = LayerMask.GetMask(LayerNameToAssign);
    }

    void Update()
    {

        if (Blink){
            CM.A0[Random.Range(0, 2)].backgroundColor = new Color(0, 0, ValueBlink);
            CM.B0[Random.Range(0, 2)].backgroundColor = new Color(ValueBlink, ValueBlink, ValueBlink);
            CM.A10[Random.Range(0, 2)].backgroundColor = new Color(0, 0, ValueBlink);
            CM.B10[Random.Range(0, 2)].backgroundColor = new Color(ValueBlink, ValueBlink, ValueBlink);
            ValueBlink = Random.Range(-1f, 2f);
        }else{
            ValueBlink = 0;
            CM.A0[Random.Range(0, 2)].backgroundColor = new Color(0, 0, ValueBlink);
            CM.B0[Random.Range(0, 2)].backgroundColor = new Color(ValueBlink, ValueBlink, ValueBlink);
            CM.A10[Random.Range(0, 2)].backgroundColor = new Color(0, 0, ValueBlink);
            CM.B10[Random.Range(0, 2)].backgroundColor = new Color(ValueBlink, ValueBlink, ValueBlink);
        }
    }

    /////////////////////////////////////////LAYER SCENE UNIVERS
    public void AddUnivers()
    {
        NumberOfUnivers++;
        if (NumberOfUnivers == 1){           
            LayerNameToAssign = "Rock01";
            LY = LayerMask.GetMask(LayerNameToAssign);
            PullUniversPhase01[0].SetActive(true);
        }else if (NumberOfUnivers == 2){
            LayerNameToAssign = "Rock02";
            LY = LayerMask.GetMask(LayerNameToAssign);
            PullUniversPhase01[1].SetActive(true);
        }else if (NumberOfUnivers == 3){
            LayerNameToAssign = "Rock03";
            LY = LayerMask.GetMask(LayerNameToAssign);
            PullUniversPhase01[2].SetActive(true);
        }
    }

    public void Reset()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
    /////////////////////////////////////////SLICED
    public void SlicedScreenA()
        {
            int R; R = Random.Range(0, 4);
            if (AssignBlink == true) {
                Blink = true;
            }
            if (R == 0) {
                if (AssignScene == true) {
                    CM.A10[0].cullingMask = LY;
                }
                A10[0].SetActive(true);
            } else if (R == 1) {
                if (AssignScene == true) {
                    CM.A10[1].cullingMask = LY;
                }
                A10[1].SetActive(true);
            }
            else if (R == 2) {
                if (AssignScene == true) {
                    CM.A10[1].cullingMask = LY;
                }
                A10[2].SetActive(true);
            }
            else if (R == 3) {
                if (AssignScene == true) {
                    CM.A10[0].cullingMask = LY;
                }
                A10[3].SetActive(true);
            }
            AssignScene = false;
            AssignBlink = false;
        }

    public void SlicedScreenB()
        {
            int R; R = Random.Range(0, 4);
            if (AssignBlink == true) {
                Blink = true;
            }
            if (R == 0) {
                if (AssignScene == true) {
                    CM.B10[0].cullingMask = LY;
                }
                B10[0].SetActive(true);
            } else if (R == 1) {
                if (AssignScene == true) {
                    CM.B10[1].cullingMask = LY;
                }
                B10[1].SetActive(true);
            } else if (R == 2) {
                if (AssignScene == true) {
                    CM.B10[0].cullingMask = LY;
                }
                B10[2].SetActive(true);
            } else if (R == 3) {
                if (AssignScene == true) {
                    CM.B10[1].cullingMask = LY;
                }
                B10[3].SetActive(true);
            }
            AssignScene = false;
            AssignBlink = false;
        }

    /////////////////////////////////////////FRAGMENTATION
    public void Subdivision()
    {
        FragmentationIntensity++;
        if (FragmentationIntensity == 1)
        {
            SetupFragmentation();                    // Simple Fragmentation 
        }
        else if (FragmentationIntensity == 2)
        {
            SetupFragmentation();
        }
        else if (FragmentationIntensity == 3)
        {
            Clean();
            SetupTotalFragmentation();              // TotalFragmentation
        }
    } // Called by sequence When Subdivision is true

        public void SetupTotalFragmentation()
        {
            int R; R = Random.Range(0, 3);
            if (R == 0) {
                if (AssignScene == true) {
                    CM.A1_0[2].cullingMask = LY; CM.B1_0[1].cullingMask = LY;
                    CM.A2_0[1].cullingMask = LY; CM.B2_0[0].cullingMask = LY; CM.B2_0[2].cullingMask = LY;
                }
                A1_0[0].SetActive(true); A1_0[2].SetActive(true); B1_0[1].SetActive(true);
                A2_0[1].SetActive(true); B2_0[0].SetActive(true); B2_0[2].SetActive(true);
            } else if (R == 1) {
                if (AssignScene == true) {
                    CM.A2_0[0].cullingMask = LY; CM.A2_0[2].cullingMask = LY; CM.B2_0[1].cullingMask = LY;
                    CM.A1_0[1].cullingMask = LY; CM.B1_0[0].cullingMask = LY; CM.B1_0[2].cullingMask = LY;
                }
                A2_0[0].SetActive(true); A2_0[2].SetActive(true); B2_0[1].SetActive(true);
                A1_0[1].SetActive(true); B1_0[0].SetActive(true); B1_0[2].SetActive(true);
            } else {
                if (AssignScene == true) {
                    CM.A1_0[1].cullingMask = LY; CM.B1_0[1].cullingMask = LY;
                    CM.A2_0[2].cullingMask = LY; CM.B2_0[0].cullingMask = LY;
                }
                A1_0[1].SetActive(true); B1_0[1].SetActive(true);
                A2_0[2].SetActive(true); B2_0[0].SetActive(true);
            }
            AssignScene = false;
        }

        public void SetupFragmentation()
        {
            int R; R = Random.Range(0, 4);
            if (R == 0) {
                if (AssignScene == true) {
                    CM.A1_0[R].cullingMask = LY; CM.B1_0[R].cullingMask = LY;
                    CM.A2_0[R].cullingMask = LY; CM.B2_0[R].cullingMask = LY;
                }
                A1_0[R].SetActive(true); B1_0[R].SetActive(true);
                A2_0[R].SetActive(true); B2_0[R].SetActive(true);
            } else if (R == 1) {
                if (AssignScene == true) {
                    CM.A1_0[R].cullingMask = LY; CM.B1_0[R].cullingMask = LY;
                    CM.A2_0[R].cullingMask = LY; CM.B2_0[R].cullingMask = LY;
                }
                A1_0[R].SetActive(true); B1_0[R].SetActive(true);
                A2_0[R].SetActive(true); B2_0[R].SetActive(true);
            } else if (R == 2) {
                if (AssignScene == true) {
                    CM.A2_0[2].cullingMask = LY;
                }
                A2_0[2].SetActive(true);
            } else {
                if (AssignScene == true) {
                    CM.A2_0[0].cullingMask = LY; CM.A2_0[2].cullingMask = LY; CM.B1_0[2].cullingMask = LY;
                }
                A2_0[0].SetActive(true); A2_0[2].SetActive(true); B1_0[2].SetActive(true);
            }
            AssignScene = false;
        }

    public void SetupVerticalFragmentationA()
        {
            int R; R = Random.Range(0, 3);
            if (R == 0) {
                if (AssignScene == true) {
                    CM.A1_0[1].cullingMask = LY;
                    CM.A2_0[1].cullingMask = LY;
                }
                A1_0[1].SetActive(true);
                A2_0[1].SetActive(true);
            } else if (R == 1) {
                if (AssignScene == true) {
                    CM.A1_0[0].cullingMask = LY; CM.A1_0[2].cullingMask = LY;
                    CM.A2_0[0].cullingMask = LY; CM.A2_0[2].cullingMask = LY;
                }
                A1_0[0].SetActive(true); A1_0[2].SetActive(true);
                A2_0[0].SetActive(true); A2_0[2].SetActive(true);
            } else {
                if (AssignScene == true) {
                    CM.A1_0[2].cullingMask = LY;
                    CM.A2_0[2].cullingMask = LY;
                }
                A1_0[2].SetActive(true);
                A2_0[2].SetActive(true);
            }
            AssignScene = false;
    } // Called by sequence When Subdivision && A is true

    public void SetupVerticalFragmentationB()
        {
            int R; R = Random.Range(0, 3);
            if (R == 0) {
                if (AssignScene == true) {
                    CM.B1_0[1].cullingMask = LY;
                    CM.B2_0[1].cullingMask = LY;
                }
                B1_0[1].SetActive(true);
                B2_0[1].SetActive(true);
            } else if (R == 1) {
                if (AssignScene == true) {
                    CM.B1_0[0].cullingMask = LY; CM.B1_0[2].cullingMask = LY;
                    CM.B2_0[0].cullingMask = LY; CM.B2_0[2].cullingMask = LY;
                }
                B1_0[0].SetActive(true); B1_0[2].SetActive(true);
                B2_0[0].SetActive(true); B2_0[2].SetActive(true);
            } else {
                if (AssignScene == true) {
                    CM.B1_0[0].cullingMask = LY;
                    CM.B2_0[0].cullingMask = LY;
                }
                B1_0[0].SetActive(true);
                B2_0[0].SetActive(true);
            }
            AssignScene = false;
    } // Called by sequence When Subdivision && B is true

    /////////////////////////////////////////Screen total A or B
    public void ScreenA()
        {
            if (AssignScene == true) {
                CM.A.cullingMask = LY;
            }
            A.SetActive(true);
            AssignScene = false;
        }
    public void ScreenB()
        {
            if (AssignScene == true) {
                CM.B.cullingMask = LY;
            }
            B.SetActive(true);
            AssignScene = false;
        }

    public void SetupFullLandscape()
    {
        int R; R = Random.Range(0, 3);
        if (AssignScene == true)
        {
            CM.AB.cullingMask = LY;
        }
        if (R == 0)
        {
            ABLandscape.transform.position = new Vector3(ABLandscape.transform.position.x, 0.27f, ABLandscape.transform.position.z);
            ABLandscape.SetActive(true);
        }
        else if (R == 1)
        {
            ABLandscape.transform.position = new Vector3(ABLandscape.transform.position.x, -0.27f, ABLandscape.transform.position.z);
            ABLandscape.SetActive(true);
        }
        else if (R == 2)
        {
            ABLandscape.transform.position = new Vector3(ABLandscape.transform.position.x, 0, ABLandscape.transform.position.z);
            ABLandscape.SetActive(true);
        }
        AssignScene = false;
    }

    /////////////////////////////////////////LANDSCAPE
    public void SetupLandscape()
        {
            int R; R = Random.Range(0, 5);
            if (AssignBlink == true)
            {
                Blink = true;
            }
            if (R == 0) {
                if (AssignScene == true) {
                    CM.A0[0].cullingMask = LY;
                }
                A0[0].SetActive(true);
            } else if (R == 1) {
                if (AssignScene == true) {
                    CM.A0[1].cullingMask = LY;
                }
                A0[1].SetActive(true);
            } else if (R == 2) {
                if (AssignScene == true) {
                    CM.B0[0].cullingMask = LY;
                }
                B0[0].SetActive(true);
            } else if (R == 3) {
                if (AssignScene == true) {
                    CM.B0[1].cullingMask = LY;
                }
                B0[1].SetActive(true);
            } else if (R == 4) {
                if (AssignScene == true) {
                    CM.A0[0].cullingMask = LY;
                    CM.B0[0].cullingMask = LY;
                }
                A0[0].SetActive(true);
                B0[0].SetActive(true);
            } else {
                if (AssignScene == true) {
                    CM.A0[1].cullingMask = LY;
                    CM.B0[1].cullingMask = LY;
                }
                A0[1].SetActive(true);
                B0[1].SetActive(true);
            }
            AssignScene = false;
            AssignBlink = false;
        } 
    public void SetupCrossLandscape()
    {
        i++;
        if (i == 1){
            if (AssignScene == true){
                CM.A0[0].cullingMask = LY;
            }
            A0[0].SetActive(true);
            B0[1].SetActive(true);
        }else if(i == 2){
            if (AssignScene == true){
                CM.A0[1].cullingMask = LY;
                CM.B0[0].cullingMask = LY;
            }
            A0[1].SetActive(true);
            B0[0].SetActive(true);
            i = 0;
        }
        AssignScene = false;
    }



  /*  public void R02()
    {
                if (Rock02) Rock02 = false;
                else Rock02 = true;
                if (Rock02){
                    LayerNameToAssign = "Rock02";
                    LY = LayerMask.GetMask(LayerNameToAssign);
                    UniversRock02.SetActive(true);
                }else{
                    UniversRock02.SetActive(false);
                }
    }

    public void R03()
    {
            if (Rock03) Rock03 = false;
            else Rock03 = true;
            if (Rock03){
                LayerNameToAssign = "Rock03";
                LY = LayerMask.GetMask(LayerNameToAssign);
                UniversRock03.SetActive(true);
            }else{
                UniversRock03.SetActive(false);
            }     
    }

    public void R04()
    {
        if (Rock04) Rock04 = false;
        else Rock04 = true;
        if (Rock04){
            LayerNameToAssign = "Rock04";
            LY = LayerMask.GetMask(LayerNameToAssign);
            UniversRock04.SetActive(true);
        }else{
            UniversRock04.SetActive(false);
        }
    }

    public void W01()
    {
        if (Water01) Water01 = false;
        else Water01 = true;
        if (Water01)
        {
            LayerNameToAssign = "Water01";
            LY = LayerMask.GetMask(LayerNameToAssign);
            UniversWater01.SetActive(true);
        }else
        {
            UniversWater01.SetActive(false);
        }
    }

    public void W02()
    {
        if (Water02) Water02 = false;
        else Water02 = true;
        if (Water02)
        {
            LayerNameToAssign = "Water02";
            LY = LayerMask.GetMask(LayerNameToAssign);
            UniversWater02.SetActive(true);
        }else
        {
            UniversWater02.SetActive(false);
        }
    }

    public void W03()
    {
        if (Water03) Water03 = false;
        else Water03 = true;
        if (Water03){
            LayerNameToAssign = "Water03";
            LY = LayerMask.GetMask(LayerNameToAssign);
            UniversWater03.SetActive(true);
        }else{
            UniversWater03.SetActive(false);
        }
    }

    public void W04()
    {
        if (Water04) Water04 = false;
        else Water04 = true;
        if (Water04)
        {
            LayerNameToAssign = "Water04";
            LY = LayerMask.GetMask(LayerNameToAssign);
            UniversWater04.SetActive(true);
        }else
        {
            UniversWater03.SetActive(false);
        }
    }

    */
    /////////////////////////////////////////Clean
    public void Clean()
    {
        ABLandscape.SetActive(false); 
        A.SetActive(false);         B.SetActive(false);

        A0[0].SetActive(false);     B0[0].SetActive(false);
        A0[1].SetActive(false);     B0[1].SetActive(false);

        A10[0].SetActive(false);    B10[0].SetActive(false);
        A10[1].SetActive(false);    B10[1].SetActive(false);
        A10[2].SetActive(false);    B10[2].SetActive(false);
        A10[3].SetActive(false);    B10[3].SetActive(false);

        A1_0[0].SetActive(false);   B1_0[0].SetActive(false);
        A1_0[1].SetActive(false);   B1_0[1].SetActive(false);
        A1_0[2].SetActive(false);   B1_0[2].SetActive(false);

        A2_0[0].SetActive(false);   B2_0[0].SetActive(false);
        A2_0[1].SetActive(false);   B2_0[1].SetActive(false);
        A2_0[2].SetActive(false);   B2_0[2].SetActive(false);
        Blink = false;
    }

    public void CleanAllUnivers()
    {
        NumberOfUnivers = 0;
        PullUniversPhase01[0].SetActive(false); PullUniversPhase01[1].SetActive(false); PullUniversPhase01[2].SetActive(false);
        PullUniversPhase02[0].SetActive(false); PullUniversPhase02[1].SetActive(false); PullUniversPhase02[2].SetActive(false);
        //PullUniversPhase03[0].SetActive(false);
    }
}

