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
    public bool Water01;
    public bool Water02;
    public bool Water03;
    public bool Water04;
    public bool Rock01;
    public bool Rock02;
    public bool Rock03;
    public bool Rock04;
    public GameObject UniversWater01;
    public GameObject UniversWater02;
    public GameObject UniversWater03;
    public GameObject UniversWater04;

    public GameObject UniversRock01;
    public GameObject UniversRock02;
    public GameObject UniversRock03;
    public GameObject UniversRock04;

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
    
    private int i;

    void Start()
    {
        Rock01 = false;
        Rock02 = false;
        Rock03 = false;
        Rock04 = false;
        Water01 = false;
        Water02 = false;
        Water03 = false;
        Water04 = false;
        CleanAllUnivers();
        Blink = false;
        AssignBlink = false;
        AssignScene = false;
        i = 0;
        Clean();
        LY = LayerMask.GetMask(LayerNameToAssign);
    }

    void Update()
    {               
       if(Rock04 || Water01)
        {
            Fluide.SetActive(true);
        }else{
            Fluide.SetActive(false);
        }
        
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

        ///////////////////////////////////////// Rock
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            if (Rock01) Rock01 = false;
            else Rock01 = true;
            if (Rock01){
                LayerNameToAssign = "Rock01";
                LY = LayerMask.GetMask(LayerNameToAssign);
                UniversRock01.SetActive(true);
            }else{
                UniversRock01.SetActive(false);
            }
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
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

         if (Input.GetKeyDown(KeyCode.Keypad3))
         {
            if (Rock03) Rock03 = false; else Rock03 = true;
            if (Rock03){
                LayerNameToAssign = "Rock03";
                LY = LayerMask.GetMask(LayerNameToAssign);
                UniversRock03.SetActive(true);
            }else{
                UniversRock03.SetActive(false);
            }
         }

        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            if (Rock04) Rock04 = false; else Rock04 = true;
            if (Rock04){
                LayerNameToAssign = "Rock04";
                LY = LayerMask.GetMask(LayerNameToAssign);
                UniversRock04.SetActive(true);
            }else
            {
                UniversRock04.SetActive(false);
            }
        }
        ///////////////////////////////////////// WATER UNIVERS
        if (Input.GetKeyDown(KeyCode.Keypad7))
         {
            if (Water01) Water01 = false; else Water01 = true;
            if (Water01){
                LayerNameToAssign = "Water01";
                LY = LayerMask.GetMask(LayerNameToAssign);
                UniversWater01.SetActive(true);
            }else{
                UniversWater01.SetActive(false);
            }
        }

         if (Input.GetKeyDown(KeyCode.Keypad8))
         {
             if (Water02) Water02 = false; else Water02 = true;
             if (Water02){
                    LayerNameToAssign = "Water02";
                    LY = LayerMask.GetMask(LayerNameToAssign);
                    UniversWater02.SetActive(true);
             }else{
                    UniversWater02.SetActive(false);
             }
         }        
    }

    /////////////////////////////////////////SLICED
    public void SlicedScreenA()
    {
        int R; R = Random.Range(0, 4);
        if (AssignBlink == true){
            Blink = true;
        }
        if (R == 0){
            if (AssignScene == true){
                CM.A10[0].cullingMask = LY;
            }
                A10[0].SetActive(true);
        }else if (R == 1){
            if (AssignScene == true){
                CM.A10[1].cullingMask = LY;
            }
            A10[1].SetActive(true);
        }
        else if (R == 2){
            if (AssignScene == true){
                CM.A10[1].cullingMask = LY;
            }
            A10[2].SetActive(true);
        }
        else if (R == 3){
            if (AssignScene == true){
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
        if (AssignBlink == true){
            Blink = true;
        }
        if (R == 0){
            if (AssignScene == true){
                CM.B10[0].cullingMask = LY;
            }
            B10[0].SetActive(true);
        }else if (R == 1){
            if (AssignScene == true){
                CM.B10[1].cullingMask = LY;
            }
            B10[1].SetActive(true);
        }else if (R == 2){
            if (AssignScene == true){
                CM.B10[0].cullingMask = LY;
            }
            B10[2].SetActive(true);
        }else if (R == 3){
            if (AssignScene == true){
                CM.B10[1].cullingMask = LY;
            }
            B10[3].SetActive(true);
        }
        AssignScene = false;
        AssignBlink = false;
    }

    /////////////////////////////////////////FRAGMENTATION
    public void SetupTotalFragmentation()
    {
        int R; R = Random.Range(0, 3);
            if (R == 0){
            if (AssignScene == true){
                CM.A1_0[2].cullingMask = LY; CM.B1_0[1].cullingMask = LY;
                CM.A2_0[1].cullingMask = LY; CM.B2_0[0].cullingMask = LY; CM.B2_0[2].cullingMask = LY;
            }
                A1_0[0].SetActive(true); A1_0[2].SetActive(true); B1_0[1].SetActive(true);
                A2_0[1].SetActive(true); B2_0[0].SetActive(true); B2_0[2].SetActive(true);
            }else if (R == 1){
            if (AssignScene == true){
                CM.A2_0[0].cullingMask = LY; CM.A2_0[2].cullingMask = LY; CM.B2_0[1].cullingMask = LY;
                CM.A1_0[1].cullingMask = LY; CM.B1_0[0].cullingMask = LY; CM.B1_0[2].cullingMask = LY;
            }
                A2_0[0].SetActive(true); A2_0[2].SetActive(true); B2_0[1].SetActive(true);
                A1_0[1].SetActive(true); B1_0[0].SetActive(true); B1_0[2].SetActive(true);
            }else{
            if (AssignScene == true){
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
            if ( R == 0){
                if (AssignScene == true){
                CM.A1_0[R].cullingMask = LY; CM.B1_0[R].cullingMask = LY;
                CM.A2_0[R].cullingMask = LY; CM.B2_0[R].cullingMask = LY;          
                }
                A1_0[R].SetActive(true); B1_0[R].SetActive(true);
                A2_0[R].SetActive(true); B2_0[R].SetActive(true);
            }else if (R == 1){
                if(AssignScene == true){
                CM.A1_0[R].cullingMask = LY; CM.B1_0[R].cullingMask = LY;
                CM.A2_0[R].cullingMask = LY; CM.B2_0[R].cullingMask = LY;
                }
                A1_0[R].SetActive(true); B1_0[R].SetActive(true);
                A2_0[R].SetActive(true); B2_0[R].SetActive(true);
            }else if (R == 2){
                if (AssignScene == true){
                CM.A2_0[2].cullingMask = LY;
                }
                A2_0[2].SetActive(true);
            }else{
                if (AssignScene == true){
                CM.A2_0[0].cullingMask = LY; CM.A2_0[2].cullingMask = LY; CM.B1_0[2].cullingMask = LY;
                }   
                A2_0[0].SetActive(true); A2_0[2].SetActive(true); B1_0[2].SetActive(true);
            }
        AssignScene = false;
     }   

    public void SetupVerticalFragmentationA()
    {
        int R;R = Random.Range(0, 3);
        if (R == 0){
            if (AssignScene == true){
                CM.A1_0[1].cullingMask = LY;
                CM.A2_0[1].cullingMask = LY;
            }
            A1_0[1].SetActive(true);
            A2_0[1].SetActive(true);
        }else if (R == 1){
            if (AssignScene == true){
                CM.A1_0[0].cullingMask = LY; CM.A1_0[2].cullingMask = LY;
                CM.A2_0[0].cullingMask = LY; CM.A2_0[2].cullingMask = LY;
            }
            A1_0[0].SetActive(true);    A1_0[2].SetActive(true);
            A2_0[0].SetActive(true);    A2_0[2].SetActive(true);
        }else{
            if (AssignScene == true){
                CM.A1_0[2].cullingMask = LY;
                CM.A2_0[2].cullingMask = LY;
            }
            A1_0[2].SetActive(true);
            A2_0[2].SetActive(true);
        }
        AssignScene = false;
    }

    public void SetupVerticalFragmentationB()
    {
        int R; R = Random.Range(0, 3);
        if (R == 0){
            if (AssignScene == true){
                CM.B1_0[1].cullingMask = LY;
                CM.B2_0[1].cullingMask = LY;
            }
            B1_0[1].SetActive(true);
            B2_0[1].SetActive(true);
        }else if (R == 1){
            if (AssignScene == true){
                CM.B1_0[0].cullingMask = LY;    CM.B1_0[2].cullingMask = LY;
                CM.B2_0[0].cullingMask = LY;    CM.B2_0[2].cullingMask = LY;
            }
            B1_0[0].SetActive(true);    B1_0[2].SetActive(true);
            B2_0[0].SetActive(true);    B2_0[2].SetActive(true);
        }else{
            if (AssignScene == true){
                CM.B1_0[0].cullingMask = LY;
                CM.B2_0[0].cullingMask = LY;
            }
            B1_0[0].SetActive(true);
            B2_0[0].SetActive(true);
        }
        AssignScene = false;
    }

    /////////////////////////////////////////Screen total A or B
    public void ScreenA()
    {
        if (AssignScene == true){
            CM.A.cullingMask = LY;
        }
        A.SetActive(true);
        AssignScene = false;
    }
    public void ScreenB()
    {
        if (AssignScene == true){
            CM.B.cullingMask = LY;
        }
        B.SetActive(true);
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
        if (R == 0){
            if (AssignScene == true){
                CM.A0[0].cullingMask = LY;
            }
                A0[0].SetActive(true);
        }else if (R == 1){
            if (AssignScene == true){
                CM.A0[1].cullingMask = LY;
            }
            A0[1].SetActive(true);
        }else if (R == 2){
            if (AssignScene == true){
                CM.B0[0].cullingMask = LY;
            }
            B0[0].SetActive(true);
        }else if (R == 3){
            if (AssignScene == true){
                CM.B0[1].cullingMask = LY;
            }
            B0[1].SetActive(true);
        }else if (R == 4){
            if (AssignScene == true){
                CM.A0[0].cullingMask = LY;
                CM.B0[0].cullingMask = LY;
            }
            A0[0].SetActive(true);
            B0[0].SetActive(true);
        }else{
            if (AssignScene == true){
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

    public void SetupFullLandscape()
    {
        int R; R = Random.Range(0, 3);
        if (AssignScene == true){
            CM.AB.cullingMask = LY;
        }
        if (R == 0){
            ABLandscape.transform.position = new Vector3(ABLandscape.transform.position.x, 0.27f, ABLandscape.transform.position.z);
            ABLandscape.SetActive(true);
        }else if (R == 1){
            ABLandscape.transform.position = new Vector3(ABLandscape.transform.position.x, -0.27f, ABLandscape.transform.position.z);
            ABLandscape.SetActive(true);
        }else if (R == 2){
            ABLandscape.transform.position = new Vector3(ABLandscape.transform.position.x, 0, ABLandscape.transform.position.z);
            ABLandscape.SetActive(true);
        }
        AssignScene = false;
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

        UniversRock01.SetActive(false);
        UniversRock02.SetActive(false);
        UniversRock03.SetActive(false);
        UniversRock04.SetActive(false);
        UniversWater01.SetActive(false);
        UniversWater02.SetActive(false);
        UniversWater03.SetActive(false);
        UniversWater04.SetActive(false);
    }
}
