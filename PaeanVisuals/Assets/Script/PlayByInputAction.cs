using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;


public class PlayByInputAction : MonoBehaviour
{
    public Composition_Manager Compo;
    public Cam_Manager Cam;
    public Scene_Manager Scene;
    public Sequence_Manager Sequence;

    public int TranslationIntensity;
    public int LandscapeIntensity;

    [SerializeField] InputAction _ScreenA = null;
    [SerializeField] InputAction _ScreenB = null;

    [SerializeField] InputAction _Subdivision = null;
    [SerializeField] InputAction _NouvelUnivers = null;

    [SerializeField] InputAction _Addition = null;

    [SerializeField] InputAction _AssignBlink = null;

    [SerializeField] InputAction _Typo = null;
    [SerializeField] InputAction _UI = null;
/*
    [SerializeField] InputAction _Rock01 = null;
    [SerializeField] InputAction _Rock02 = null;
    [SerializeField] InputAction _Rock03 = null;
    [SerializeField] InputAction _Rock04 = null;

    [SerializeField] InputAction _Water01 = null;
    [SerializeField] InputAction _Water02 = null;
    [SerializeField] InputAction _Water03 = null;
    [SerializeField] InputAction _Water04 = null;
    */
    [SerializeField] InputAction _Restart = null;


    void Start()
    {

    }

    void OnEnable()
    {
        _ScreenA.performed += ScreenA;
        _ScreenA.Enable();

        _ScreenB.performed += ScreenB;
        _ScreenB.Enable();

        _Subdivision.performed += Subdivision;
        _Subdivision.Enable();

        _NouvelUnivers.performed += NouvelUnivers;
        _NouvelUnivers.Enable();

        _Addition.performed += Addition;
        _Addition.Enable();


        _AssignBlink.performed += Blink;
        _AssignBlink.Enable();


        _Typo.performed += Typo;
        _Typo.Enable();

        _UI.performed += UI;
        _UI.Enable();

   /*     _Rock01.performed += CallRock01;
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
        _Water04.Enable();*/

        _Restart.performed += Level;
        _Restart.Enable();
    }

    void OnDisable()
    {
        _ScreenA.performed -= ScreenA;
        _ScreenA.Disable();

        _ScreenB.performed -= ScreenB;
        _ScreenB.Disable();

        _Subdivision.performed -= Subdivision;
        _Subdivision.Disable();

        _NouvelUnivers.performed -= NouvelUnivers;
        _NouvelUnivers.Disable();

        _AssignBlink.performed -= Blink;
        _AssignBlink.Disable();

        _Addition.performed -= Addition;
        _Addition.Disable();

        _Typo.performed -= Typo;
        _Typo.Disable();

        _UI.performed -= UI;
        _UI.Disable();
/*
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
        */
        _Restart.performed -= Level;
        _Restart.Disable();

    }

    void ScreenA(InputAction.CallbackContext ctx)
    {
        if (!Sequence.A){
            Sequence.A = true;
        }else{
            Sequence.A = false ;
        }
    }

    void ScreenB(InputAction.CallbackContext ctx)
    {
        if (!Sequence.B){
            Sequence.B = true;
        }else{
            Sequence.B = false;
        }        
    }

    void Subdivision(InputAction.CallbackContext ctx)
    {
        if (!Sequence.Subdivision){
            Sequence.Subdivision = true;
        }else{
            Sequence.Subdivision = false;
        }       
    }

    void NouvelUnivers(InputAction.CallbackContext ctx)
    {
        if (!Sequence.NouvelUnivers)
        {
            Sequence.NouvelUnivers = true;
            Compo.AssignScene = true;
        }else{
            Sequence.NouvelUnivers = false;
            Compo.AssignScene = false;
        }
    }

    /*  void Landscape(InputAction.CallbackContext ctx)
      {
          LandscapeIntensity++;
          if (LandscapeIntensity == 1){
              Compo.SetupLandscape();
          }else if (LandscapeIntensity == 2)
          {
              Compo.SetupLandscape();
          }else if (LandscapeIntensity == 3)
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
    }*/

    void Blink(InputAction.CallbackContext ctx)
    {
        Compo.AssignBlink = true;
    }

    void Addition(InputAction.CallbackContext ctx)
    {
        if (!Sequence.Add){
            Sequence.Add = true;
        }else{
            Sequence.Add = false;
        }
        Sequence.SetAllCommandOff();
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
