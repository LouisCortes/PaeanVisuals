using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Composition_Manager : MonoBehaviour
{
    public Cam_Manager CM;
    public string LayerNameToAssign;
    public Sequence_Manager Sequence;

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

    public GameObject SphereLiquide;
    public GameObject Fluide;

    public int NumberOfUnivers;
    public int TranslationIntensity;
    public int LandscapeIntensity;
    private int FragmentationIntensity;
    private int i;

    void Start()
    {
        CleanAllUnivers();
        Blink = false;
        AssignBlink = false;
        AddUnivers();
        i = 0;
        FragmentationIntensity = 0;
        Clean();
        LY = LayerMask.GetMask(LayerNameToAssign);
    }

    void Update()
    {
       
        if (Blink) {
            CM.A0[Random.Range(0, 2)].backgroundColor = new Color(0, 0, ValueBlink);
            CM.B0[Random.Range(0, 2)].backgroundColor = new Color(ValueBlink, ValueBlink, ValueBlink);
            CM.A10[Random.Range(0, 2)].backgroundColor = new Color(0, 0, ValueBlink);
            CM.B10[Random.Range(0, 2)].backgroundColor = new Color(ValueBlink, ValueBlink, ValueBlink);
            ValueBlink = Random.Range(-1f, 2f);
        } else {
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
          if (Sequence.NouvelUnivers){
              NumberOfUnivers++;
          }
          if (NumberOfUnivers == 1) {
              LayerNameToAssign = "Rock01";
              LY = LayerMask.GetMask(LayerNameToAssign);
              PullUniversPhase01[0].SetActive(true);
          } else if (NumberOfUnivers == 2) {
              LayerNameToAssign = "Rock02";
              LY = LayerMask.GetMask(LayerNameToAssign);
              PullUniversPhase01[1].SetActive(true);
          } else if (NumberOfUnivers == 3) {
              LayerNameToAssign = "Rock03";
              LY = LayerMask.GetMask(LayerNameToAssign);
              PullUniversPhase01[2].SetActive(true);
              NumberOfUnivers = 0;
          }
    }
    public void AddUnivers2()
    {
        if (Sequence.NouvelUnivers){
            NumberOfUnivers++;
        }
        if (NumberOfUnivers == 1){
            LayerNameToAssign = "Rock04";
            LY = LayerMask.GetMask(LayerNameToAssign);
            PullUniversPhase02[0].SetActive(true);
        }else if (NumberOfUnivers == 2){
            LayerNameToAssign = "Cave";
            LY = LayerMask.GetMask(LayerNameToAssign);
            PullUniversPhase02[1].SetActive(true);
        }else if (NumberOfUnivers == 3){
            LayerNameToAssign = "Water01";
            LY = LayerMask.GetMask(LayerNameToAssign);
            PullUniversPhase02[2].SetActive(true);
            NumberOfUnivers = 0;
        }
    }


    public void AnimCam()
    {
        TranslationIntensity++;
        if (TranslationIntensity == 1) {
            CM.CamTranslation();                     // Simple Translation
        } else if (TranslationIntensity == 2) {
            CM.CamTranslationCrossed();             // Crossed Translation
        } else if (TranslationIntensity == 3) {
            CM.CamTranslationMelt();               // Melted Translation
        } else {
            CM.CamStopAnim();
            TranslationIntensity = 0;
        }
    }
    

    /////////////////////////////////////////SLICED
    public void SlicedScreenA()
        {
            int R; R = Random.Range(0, 4);
            if (AssignBlink == true) {
                Blink = true;
            }if (R == 0) {
                if (Sequence.AssignCurrentUnivers == true) {
                    CM.A10[0].cullingMask = LY;
                }
                A10[0].SetActive(true);
            } else if (R == 1) {
                if (Sequence.AssignCurrentUnivers == true) {
                    CM.A10[1].cullingMask = LY;
                }
                A10[1].SetActive(true);
            }
            else if (R == 2) {
                if (Sequence.AssignCurrentUnivers == true) {
                    CM.A10[1].cullingMask = LY;
                }
                A10[2].SetActive(true);
            }
            else if (R == 3) {
                if (Sequence.AssignCurrentUnivers == true) {
                    CM.A10[0].cullingMask = LY;
                }
                A10[3].SetActive(true);
            }
           // Sequence.NouvelUnivers = false;
            AssignBlink = false;
        }
    public void SlicedScreenB()
        {
            int R; R = Random.Range(0, 4);
            if (AssignBlink == true) {
                Blink = true;
            }
            if (R == 0) {
                if (Sequence.AssignCurrentUnivers == true) {
                    CM.B10[0].cullingMask = LY;
                }
                B10[0].SetActive(true);
            } else if (R == 1) {
                if (Sequence.AssignCurrentUnivers == true) {
                    CM.B10[1].cullingMask = LY;
                }
                B10[1].SetActive(true);
            } else if (R == 2) {
                if (Sequence.AssignCurrentUnivers == true) {
                    CM.B10[0].cullingMask = LY;
                }
                B10[2].SetActive(true);
            } else if (R == 3) {
                if (Sequence.AssignCurrentUnivers == true) {
                    CM.B10[1].cullingMask = LY;
                }
                B10[3].SetActive(true);
            }
          //  Sequence.NouvelUnivers = false;
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
            SetupTotalFragmentation();
            FragmentationIntensity = 0;// TotalFragmentation
        }
    } // Called by sequence When Subdivision LEVEL2 is true

        public void SetupTotalFragmentation()
        {
            int R; R = Random.Range(0, 3);
            if (R == 0) {
                if (Sequence.AssignCurrentUnivers == true) {
                    CM.A1_0[2].cullingMask = LY; CM.B1_0[1].cullingMask = LY;
                    CM.A2_0[1].cullingMask = LY; CM.B2_0[0].cullingMask = LY; CM.B2_0[2].cullingMask = LY;
                }
                A1_0[0].SetActive(true); A1_0[2].SetActive(true); B1_0[1].SetActive(true);
                A2_0[1].SetActive(true); B2_0[0].SetActive(true); B2_0[2].SetActive(true);
            } else if (R == 1) {
                if (Sequence.AssignCurrentUnivers == true) {
                    CM.A2_0[0].cullingMask = LY; CM.A2_0[2].cullingMask = LY; CM.B2_0[1].cullingMask = LY;
                    CM.A1_0[1].cullingMask = LY; CM.B1_0[0].cullingMask = LY; CM.B1_0[2].cullingMask = LY;
                }
                A2_0[0].SetActive(true); A2_0[2].SetActive(true); B2_0[1].SetActive(true);
                A1_0[1].SetActive(true); B1_0[0].SetActive(true); B1_0[2].SetActive(true);
            } else {
                if (Sequence.AssignCurrentUnivers == true) {
                    CM.A1_0[1].cullingMask = LY; CM.B1_0[1].cullingMask = LY;
                    CM.A2_0[2].cullingMask = LY; CM.B2_0[0].cullingMask = LY;
                }
                A1_0[1].SetActive(true); B1_0[1].SetActive(true);
                A2_0[2].SetActive(true); B2_0[0].SetActive(true);
            }
           // Sequence.NouvelUnivers = false;
        }
        public void SetupFragmentation()
        {
            int R; R = Random.Range(0, 4);
            if (R == 0) {
                if (Sequence.AssignCurrentUnivers == true) {
                    CM.A1_0[R].cullingMask = LY; CM.B1_0[R].cullingMask = LY;
                    CM.A2_0[R].cullingMask = LY; CM.B2_0[R].cullingMask = LY;
                }
                A1_0[R].SetActive(true); B1_0[R].SetActive(true);
                A2_0[R].SetActive(true); B2_0[R].SetActive(true);
            } else if (R == 1) {
                if (Sequence.AssignCurrentUnivers == true) {
                    CM.A1_0[R].cullingMask = LY; CM.B1_0[R].cullingMask = LY;
                    CM.A2_0[R].cullingMask = LY; CM.B2_0[R].cullingMask = LY;
                }
                A1_0[R].SetActive(true); B1_0[R].SetActive(true);
                A2_0[R].SetActive(true); B2_0[R].SetActive(true);
            } else if (R == 2) {
                if (Sequence.AssignCurrentUnivers == true) {
                    CM.A2_0[2].cullingMask = LY;
                }
                A2_0[2].SetActive(true);
            } else {
                if (Sequence.AssignCurrentUnivers == true) {
                    CM.A2_0[0].cullingMask = LY; CM.A2_0[2].cullingMask = LY; CM.B1_0[2].cullingMask = LY;
                }
                A2_0[0].SetActive(true); A2_0[2].SetActive(true); B1_0[2].SetActive(true);
            }
          //  Sequence.NouvelUnivers = false;
        }

    public void SetupVerticalFragmentationA()
        {
            int R; R = Random.Range(0, 3);
            if (R == 0) {
                if (Sequence.AssignCurrentUnivers == true) {
                    CM.A1_0[1].cullingMask = LY;
                    CM.A2_0[1].cullingMask = LY;
                }
                A1_0[1].SetActive(true);
                A2_0[1].SetActive(true);
            } else if (R == 1) {
                if (Sequence.AssignCurrentUnivers == true) {
                    CM.A1_0[0].cullingMask = LY; CM.A1_0[2].cullingMask = LY;
                    CM.A2_0[0].cullingMask = LY; CM.A2_0[2].cullingMask = LY;
                }
                A1_0[0].SetActive(true); A1_0[2].SetActive(true);
                A2_0[0].SetActive(true); A2_0[2].SetActive(true);
            } else {
                if (Sequence.AssignCurrentUnivers == true) {
                    CM.A1_0[2].cullingMask = LY;
                    CM.A2_0[2].cullingMask = LY;
                }
                A1_0[2].SetActive(true);
                A2_0[2].SetActive(true);
            }
           // Sequence.NouvelUnivers = false;
    } // Called by sequence When Subdivision && A is true
    public void SetupVerticalFragmentationB()
        {
            int R; R = Random.Range(0, 3);
            if (R == 0) {
                if (Sequence.AssignCurrentUnivers == true) {
                    CM.B1_0[1].cullingMask = LY;
                    CM.B2_0[1].cullingMask = LY;
                }
                B1_0[1].SetActive(true);
                B2_0[1].SetActive(true);
            } else if (R == 1) {
                if (Sequence.AssignCurrentUnivers == true) {
                    CM.B1_0[0].cullingMask = LY; CM.B1_0[2].cullingMask = LY;
                    CM.B2_0[0].cullingMask = LY; CM.B2_0[2].cullingMask = LY;
                }
                B1_0[0].SetActive(true); B1_0[2].SetActive(true);
                B2_0[0].SetActive(true); B2_0[2].SetActive(true);
            } else {
                if (Sequence.AssignCurrentUnivers == true) {
                    CM.B1_0[0].cullingMask = LY;
                    CM.B2_0[0].cullingMask = LY;
                }
                B1_0[0].SetActive(true);
                B2_0[0].SetActive(true);
            }
            //Sequence.NouvelUnivers = false;
    } // Called by sequence When Subdivision && B is true

    /////////////////////////////////////////Screen total A or B
    public void ScreenA()
        {
            if (Sequence.AssignCurrentUnivers == true) {
                CM.A.cullingMask = LY;
            }
            A.SetActive(true);
          //  Sequence.NouvelUnivers = false;
        }
    public void ScreenB()
        {
            if (Sequence.AssignCurrentUnivers == true) {
                CM.B.cullingMask = LY;
            }
            B.SetActive(true);
          //  Sequence.NouvelUnivers = false;
        }

    public void SetupFullLandscape()
    {
        int R; R = Random.Range(0, 3);
        if (Sequence.AssignCurrentUnivers == true)
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
      //  Sequence.NouvelUnivers = false;
    }

    /////////////////////////////////////////LANDSCAPE

    public void Landscape()
    {
        LandscapeIntensity++;
        if (LandscapeIntensity == 1)
        {
            SetupLandscape();
        }
        else if (LandscapeIntensity == 2)
        {
            SetupLandscape();
        }
        else if (LandscapeIntensity == 3)
        {          
            SetupCrossLandscape();
            LandscapeIntensity = 0;// Cross Landscape
        }
    } // Called by sequence When Subdivision is true

        public void SetupLandscape()
        {
            int R; R = Random.Range(0, 5);
            if (AssignBlink == true)
            {
                Blink = true;
            }
            if (R == 0) {
                if (Sequence.AssignCurrentUnivers == true) {
                    CM.A0[0].cullingMask = LY;
                }
                A0[0].SetActive(true);
            } else if (R == 1) {
                if (Sequence.AssignCurrentUnivers == true) {
                    CM.A0[1].cullingMask = LY;
                }
                A0[1].SetActive(true);
            } else if (R == 2) {
                if (Sequence.AssignCurrentUnivers == true) {
                    CM.B0[0].cullingMask = LY;
                }
                B0[0].SetActive(true);
            } else if (R == 3) {
                if (Sequence.AssignCurrentUnivers == true) {
                    CM.B0[1].cullingMask = LY;
                }
                B0[1].SetActive(true);
            } else if (R == 4) {
                if (Sequence.AssignCurrentUnivers == true) {
                    CM.A0[0].cullingMask = LY;
                    CM.B0[0].cullingMask = LY;
                }
                A0[0].SetActive(true);
                B0[0].SetActive(true);
            } else {
                if (Sequence.AssignCurrentUnivers == true) {
                    CM.A0[1].cullingMask = LY;
                    CM.B0[1].cullingMask = LY;
                }
                A0[1].SetActive(true);
                B0[1].SetActive(true);
            }
            //Sequence.NouvelUnivers = false;
            AssignBlink = false;
        } 
        public void SetupCrossLandscape()
        {
        i++;
        if (i == 1){
            if (Sequence.AssignCurrentUnivers == true){
                CM.A0[0].cullingMask = LY;
                CM.B0[1].cullingMask = LY;
            }
            A0[0].SetActive(true);
            B0[1].SetActive(true);
        }else if(i == 2){
            if (Sequence.AssignCurrentUnivers == true){
                CM.A0[1].cullingMask = LY;
                CM.B0[0].cullingMask = LY;
            }
            A0[1].SetActive(true);
            B0[0].SetActive(true);
            i = 0;
        }
      //  Sequence.NouvelUnivers = false;
    }

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
        NumberOfUnivers = 1;
        PullUniversPhase01[0].SetActive(false); PullUniversPhase01[1].SetActive(false); PullUniversPhase01[2].SetActive(false);
        PullUniversPhase02[0].SetActive(false); PullUniversPhase02[1].SetActive(false); PullUniversPhase02[2].SetActive(false);
        //PullUniversPhase03[0].SetActive(false);
    }

    /////////////////////////////////////////DEBUG Reset
    public void Reset()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}

