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

    [SerializeField] InputAction _ScreenA = null;
    [SerializeField] InputAction _ScreenB = null;

    [SerializeField] InputAction _Subdivision1 = null;
    [SerializeField] InputAction _Subdivision2 = null;

    [SerializeField] InputAction _NouvelUnivers = null;

    [SerializeField] InputAction _ChangeSpeed = null;
    [SerializeField] InputAction _NextSequence = null;

    [SerializeField] InputAction _Addition = null;

    [SerializeField] InputAction _AssignBlink = null;

    [SerializeField] InputAction _DebugFunction = null;
    [SerializeField] InputAction _DebugClean = null;

    [SerializeField] InputAction _AnimCam = null;

    [SerializeField] InputAction _Typo = null;
    [SerializeField] InputAction _UI = null;

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

        _Subdivision1.performed += Subdivision1;
        _Subdivision1.Enable();

        _Subdivision2.performed += Subdivision2;
        _Subdivision2.Enable();

        _NouvelUnivers.performed += NouvelUnivers;
        _NouvelUnivers.Enable();

        _ChangeSpeed.performed += ChangeSpeed;
        _ChangeSpeed.Enable();

        _NextSequence.performed += NextSequence;
        _NextSequence.Enable();

        _Addition.performed += Addition;
        _Addition.Enable();


        _AssignBlink.performed += Blink;
        _AssignBlink.Enable();

        _AnimCam.performed += AnimCam;
        _AnimCam.Enable();

        _Typo.performed += Typo;
        _Typo.Enable();

        _UI.performed += UI;
        _UI.Enable();

        ///// DEBUG STUFF
        _DebugClean.performed += DebugClean;
        _DebugClean.Enable();
        _DebugFunction.performed += DebugFunction;
        _DebugFunction.Enable();

        _Restart.performed += ResetLevel;
        _Restart.Enable();
    }

    void OnDisable()
    {
        _ScreenA.performed -= ScreenA;
        _ScreenA.Disable();

        _ScreenB.performed -= ScreenB;
        _ScreenB.Disable();

        _Subdivision1.performed -= Subdivision1;
        _Subdivision1.Disable();

        _Subdivision2.performed -= Subdivision2;
        _Subdivision2.Disable();

        _NouvelUnivers.performed -= NouvelUnivers;
        _NouvelUnivers.Disable();

        _NextSequence.performed -= NextSequence;
        _NextSequence.Disable();

        _ChangeSpeed.performed -= ChangeSpeed;
        _ChangeSpeed.Disable();

        _Addition.performed -= Addition;
        _Addition.Disable();

        _AssignBlink.performed -= Blink;
        _AssignBlink.Disable();

        _AnimCam.performed -= AnimCam;
        _AnimCam.Disable();

        _Typo.performed -= Typo;
        _Typo.Disable();

        _UI.performed -= UI;
        _UI.Disable();

        ////// DEBUG STUFF
        _DebugClean.performed -= DebugClean;
        _DebugClean.Disable();
        _DebugFunction.performed -= DebugFunction;
        _DebugFunction.Disable();
        _Restart.performed -= ResetLevel;
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

    void Subdivision1(InputAction.CallbackContext ctx)
    {
        if (!Sequence.Subdivision1){
            Sequence.Subdivision1 = true;
        }else{
            Sequence.Subdivision1 = false;
        }       
    }

    void Subdivision2(InputAction.CallbackContext ctx)
    {
        if (!Sequence.Subdivision2){
            Sequence.Subdivision2 = true;
        } else{
            Sequence.Subdivision2 = false;
        }
    }

    void NouvelUnivers(InputAction.CallbackContext ctx)
    {
        if (!Sequence.NouvelUnivers)
        {
            Sequence.NouvelUnivers = true;
        }else{
            Sequence.NouvelUnivers = false;
        }
    }

    void Addition(InputAction.CallbackContext ctx)
    {
        if (!Sequence.Add)
        {
            Sequence.Add = true;
        }else{
            Sequence.Add = false;
        }
    }

    void NextSequence(InputAction.CallbackContext ctx)
    {
        Sequence.Next = true;
    }

    void ChangeSpeed(InputAction.CallbackContext ctx)
    {
        Sequence.ChangeSpeed();
    }

    void DebugFunction(InputAction.CallbackContext ctx)
    {
        Debug.Log("DebugFunctionok");
        Compo.Landscape();
    }

    void DebugClean(InputAction.CallbackContext ctx)
    {
        Debug.Log("DebugClean");
        Compo.Clean();
    }

    void Blink(InputAction.CallbackContext ctx)
    {
        Compo.AssignBlink = true;
    }

    void AnimCam(InputAction.CallbackContext ctx)
    {
        Compo.AnimCam();
    }

    void Typo(InputAction.CallbackContext ctx)
    {
        Scene.TextPaeanApparition();
    }

    void UI(InputAction.CallbackContext ctx)
    {
        Scene.UIGPSApparition();
    }

    void ResetLevel(InputAction.CallbackContext ctx)
    {
        Application.LoadLevel(Application.loadedLevel);
    }



}
