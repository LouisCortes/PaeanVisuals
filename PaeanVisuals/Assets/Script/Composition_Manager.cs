using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Composition_Manager : MonoBehaviour
{
    public Cam_Manager CM;
    public string LayerNameToAssign;
    public GameObject ABLandscape;
    private LayerMask LY;
    public GameObject A;
    public GameObject[] A0;
    public GameObject[] A1_0;
    public GameObject[] A2_0;

    public GameObject B;
    public GameObject[] B0;
    public GameObject[] B1_0;
    public GameObject[] B2_0;

    public bool AssignScene;
    private int i;

    void Start()
    {
        AssignScene = false;
        i = 0;
        CleanA();
        LY = LayerMask.GetMask(LayerNameToAssign);
    }

    void Update()
    {
        if (Input.GetKeyDown("return"))
        {
            AssignScene = true;
        }
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            LayerNameToAssign = "Rock01";
            LY = LayerMask.GetMask(LayerNameToAssign);
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            LayerNameToAssign = "Rock02";
            LY = LayerMask.GetMask(LayerNameToAssign);
        }
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            LayerNameToAssign = "Water01";
            LY = LayerMask.GetMask(LayerNameToAssign);
        }
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
            }else if (R == 1)
            {
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
        }
        else{
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
    public void CleanA()
    {
        ABLandscape.SetActive(false); 
        A.SetActive(false);         B.SetActive(false);

        A0[0].SetActive(false);     B0[0].SetActive(false);
        A0[1].SetActive(false);     B0[1].SetActive(false);

        A1_0[0].SetActive(false);   B1_0[0].SetActive(false);
        A1_0[1].SetActive(false);   B1_0[1].SetActive(false);
        A1_0[2].SetActive(false);   B1_0[2].SetActive(false);

        A2_0[0].SetActive(false);   B2_0[0].SetActive(false);
        A2_0[1].SetActive(false);   B2_0[1].SetActive(false);
        A2_0[2].SetActive(false);   B2_0[2].SetActive(false);
    }
}
