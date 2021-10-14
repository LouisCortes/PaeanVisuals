using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;

sealed class PlayByInputAction : MonoBehaviour
{
    public Composition_Manager Compo;
    public Cam_Manager Cam;
    public Scene_Manager Scene;


    public int TranslationIntensity;
    public int LandscapeIntensity;
    public int FragmentationIntensity;

    public GameObject GO;
    //   [SerializeField] PlayableDirector _playable = null;
    [SerializeField] InputAction _ScreenA = null;
    [SerializeField] InputAction _FragmentationA = null;
    [SerializeField] InputAction _FragmentationB = null;
    [SerializeField] InputAction _ScreenB = null;

    [SerializeField] InputAction _FullLandscape = null;
    [SerializeField] InputAction _Landscape = null;

    [SerializeField] InputAction _SlicedA = null;
    [SerializeField] InputAction _SlicedB = null;

    [SerializeField] InputAction _FullFragmentation = null;
    [SerializeField] InputAction _Clean = null;

    [SerializeField] InputAction _AssignScene = null;
    [SerializeField] InputAction _AssignBlink = null;

    [SerializeField] InputAction _Typo = null;
    [SerializeField] InputAction _UI = null;

    [SerializeField] InputAction _Rock01 = null;
    [SerializeField] InputAction _Rock02 = null;
    [SerializeField] InputAction _Rock03 = null;
    [SerializeField] InputAction _Rock04 = null;

    [SerializeField] InputAction _Water01 = null;
    [SerializeField] InputAction _Water02 = null;
    [SerializeField] InputAction _Water03 = null;
    [SerializeField] InputAction _Water04 = null;

    [SerializeField] InputAction _Restart = null;


    void Start()
    {
        FragmentationIntensity = 0;
    }

    void OnEnable()
    {
        _ScreenA.performed += ScreenA;
        _ScreenA.Enable();

        _FragmentationA.performed += FragmentationA;
        _FragmentationA.Enable();

        _FragmentationB.performed += FragmentationB;
        _FragmentationB.Enable();

        _ScreenB.performed += ScreenB;
        _ScreenB.Enable();

        _SlicedA.performed += SlicedA;
        _SlicedA.Enable();

        _FullLandscape.performed += FullLandscape;
        _FullLandscape.Enable();

        _Landscape.performed += Landscape;
        _Landscape.Enable();

        _SlicedB.performed += SlicedB;
        _SlicedB.Enable();

        _FullFragmentation.performed += FullFragmentation;
        _FullFragmentation.Enable();

        _AssignBlink.performed += Blink;
        _AssignBlink.Enable();

        _Clean.performed += Clean;
        _Clean.Enable();

        _AssignScene.performed += AssignScene;
        _AssignScene.Enable();

        _Typo.performed += Typo;
        _Typo.Enable();

        _UI.performed += UI;
        _UI.Enable();

        _Rock01.performed += CallRock01;
        _Rock01.Enable();
        _Rock02.performed += CallRock02;
        _Rock02.Enable();
        _Rock03.performed += CallRock03;
        _Rock03.Enable();
        _Rock04.performed += CallRock04;
        _Rock04.Enable();

        _Water01.performed += CallWater01;
        _Water01.Enable();
        _Water02.performed += CallWater02;
        _Water02.Enable();
        _Water03.performed += CallWater03;
        _Water03.Enable();
        _Water04.performed += CallWater04;
        _Water04.Enable();

        _Restart.performed += Level;
        _Restart.Enable();
    }

    void OnDisable()
    {
        _ScreenA.performed -= ScreenA;
        _ScreenA.Disable();

        _FragmentationA.performed -= FragmentationA;
        _FragmentationA.Disable();

        _FragmentationB.performed -= FragmentationB;
        _FragmentationB.Disable();

        _ScreenB.performed -= ScreenB;
        _ScreenB.Disable();

        _SlicedA.performed -= SlicedA;
        _SlicedA.Disable();

        _FullLandscape.performed -= FullLandscape;
        _FullLandscape.Disable();

        _Landscape.performed -= Landscape;
        _Landscape.Disable();

        _SlicedB.performed -= SlicedB;
        _SlicedB.Disable();

        _FullFragmentation.performed -= FullFragmentation;
        _FullFragmentation.Disable();

        _AssignBlink.performed -= Blink;
        _AssignBlink.Disable();

        _Clean.performed -= Clean;
        _Clean.Disable();

        _AssignScene.performed -= AssignScene;
        _AssignScene.Disable();

        _Typo.performed -= Typo;
        _Typo.Disable();

        _UI.performed -= UI;
        _UI.Disable();

        _Rock01.performed -= CallRock01;
        _Rock01.Disable();
        _Rock02.performed -= CallRock02;
        _Rock02.Disable();
        _Rock03.performed -= CallRock03;
        _Rock03.Disable();
        _Rock04.performed -= CallRock04;
        _Rock04.Disable();

        _Water01.performed -= CallWater01;
        _Water01.Disable();
        _Water02.performed -= CallWater02;
        _Water02.Disable();
        _Water03.performed -= CallWater03;
        _Water03.Disable();
        _Water04.performed -= CallWater04;
        _Water04.Disable();

        _Restart.performed -= Level;
        _Restart.Disable();

    }

    void ScreenA(InputAction.CallbackContext ctx)
    {
        Compo.Clean();
        Compo.ScreenA();
    }

    void FragmentationA(InputAction.CallbackContext ctx)
    {
        Compo.SetupVerticalFragmentationA();
    }


    void FragmentationB(InputAction.CallbackContext ctx)
    {
        Compo.SetupVerticalFragmentationB();
    }

    void ScreenB(InputAction.CallbackContext ctx)
    {
        Compo.Clean();
        Compo.ScreenB();
    }
    //  =>

    void SlicedA(InputAction.CallbackContext ctx)
    {
        Compo.SlicedScreenA();
    }

    void FullLandscape(InputAction.CallbackContext ctx)
    {
        Compo.SetupFullLandscape();
    }

    void Landscape(InputAction.CallbackContext ctx)
    {
        LandscapeIntensity++;
        if (LandscapeIntensity == 1)
        {
            Compo.SetupLandscape();
        }
        else if (LandscapeIntensity == 2)
        {
            Compo.SetupLandscape();
        }
        else if (LandscapeIntensity == 3)
        {
            if (Compo.AssignScene)
            {

                Compo.CleanAllUnivers();
            }

            TranslationIntensity = 0;
            Compo.Clean();
            Cam.ResetAll();
            LandscapeIntensity = 0;
            FragmentationIntensity = 0;

            Compo.SetupCrossLandscape();    // Cross Landscape
        }
    }

    void SlicedB(InputAction.CallbackContext ctx)
    {
        Compo.SlicedScreenB();
    }

    void FullFragmentation(InputAction.CallbackContext ctx)
    {
        FragmentationIntensity++;
        if (FragmentationIntensity == 1){
            Compo.SetupFragmentation();                    // Simple Fragmentation 
        }
        else if (FragmentationIntensity == 2){
            Compo.SetupFragmentation();
        }
        else if (FragmentationIntensity == 3) {
            Compo.Clean();
            Compo.SetupTotalFragmentation();              // TotalFragmentation
        }
    }

    void Blink(InputAction.CallbackContext ctx)
    {
        Compo.AssignBlink = true;
    }

    void Clean(InputAction.CallbackContext ctx)
    {
        Compo.Clean();
    }

    void AssignScene(InputAction.CallbackContext ctx)
    {
        Compo.AssignScene = true;
    }

    void Typo(InputAction.CallbackContext ctx)
    {
        Scene.TextPaeanApparition();
    }

    void UI(InputAction.CallbackContext ctx)
    {
        Scene.UIGPSApparition();
    }

    void Level(InputAction.CallbackContext ctx)
    {
        Compo.Reset();
    }

    void CallRock01(InputAction.CallbackContext ctx)
    {
        Compo.R01();
    }

  void CallRock02(InputAction.CallbackContext ctx)
    {
        Compo.R02();
    }
    void CallRock03(InputAction.CallbackContext ctx)
    {
        Compo.R03();
    }
    void CallRock04(InputAction.CallbackContext ctx)
    {
        Compo.R04();
    }

    void CallWater01(InputAction.CallbackContext ctx)
    {
          Compo.W01();
    }
    void CallWater02(InputAction.CallbackContext ctx)
    {
         Compo.W02();
    }
    void CallWater03(InputAction.CallbackContext ctx)
    {
         Compo.W03();
    }
    void CallWater04(InputAction.CallbackContext ctx)
    {
         Compo.W04();
    }

  /*  public void CleanLocal(InputAction.CallbackContext ctx)
    {
        if (Compo.AssignScene)
        {

            Compo.CleanAllUnivers();
        }

        TranslationIntensity = 0;
        Compo.Clean();
        Cam.ResetAll();
        LandscapeIntensity = 0;
        FragmentationIntensity = 0;
    }*/


}
