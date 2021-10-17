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

    [SerializeField] InputAction _AssignCurrentUnivers = null;
    [SerializeField] InputAction _NouvelUnivers = null;

    [SerializeField] InputAction _ChangeSpeed = null;
    [SerializeField] InputAction _NextSequence = null;

    [SerializeField] InputAction _Fade = null;
    [SerializeField] InputAction _Addition = null;

    [SerializeField] InputAction _SphereLiquide = null;

    [SerializeField] InputAction _AssignBlink = null;

    [SerializeField] InputAction _DebugFunction = null;
    [SerializeField] InputAction _DebugClean = null;

    [SerializeField] InputAction _SwitchCam = null;
    [SerializeField] InputAction _SwitchPP = null;

    [SerializeField] InputAction _AnimCam = null;

    [SerializeField] InputAction _Typo = null;
    [SerializeField] InputAction _UI = null;

    [SerializeField] InputAction _Restart = null;

    public int i;

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

        _AssignCurrentUnivers.performed += AssignCurrentUnivers;
        _AssignCurrentUnivers.Enable();

        _NouvelUnivers.performed += NouvelUnivers;
        _NouvelUnivers.Enable();

        _ChangeSpeed.performed += ChangeSpeed;
        _ChangeSpeed.Enable();

        _NextSequence.performed += NextSequence;
        _NextSequence.Enable();

        _Addition.performed += Addition;
        _Addition.Enable();

        _Fade.performed += Fade;
        _Fade.Enable();

        _SphereLiquide.performed += SphereLiquide;
        _SphereLiquide.Enable();

        _AssignBlink.performed += Blink;
        _AssignBlink.Enable();

        _SwitchPP.performed += SwitchPP;
        _SwitchPP.Enable();

        _SwitchCam.performed += SwitchCam;
        _SwitchCam.Enable();

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

        _AssignCurrentUnivers.performed += AssignCurrentUnivers;
        _AssignCurrentUnivers.Disable();

        _NouvelUnivers.performed -= NouvelUnivers;
        _NouvelUnivers.Disable();

        _SphereLiquide.performed += SphereLiquide;
        _SphereLiquide.Disable();

        _NextSequence.performed -= NextSequence;
        _NextSequence.Disable();

        _ChangeSpeed.performed -= ChangeSpeed;
        _ChangeSpeed.Disable();

        _Addition.performed -= Addition;
        _Addition.Disable();

        _Fade.performed += Fade;
        _Fade.Disable();

        _AssignBlink.performed -= Blink;
        _AssignBlink.Disable();

        _SwitchPP.performed += SwitchPP;
        _SwitchPP.Disable();

        _SwitchCam.performed += SwitchCam;
        _SwitchCam.Disable();

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

    void AssignCurrentUnivers(InputAction.CallbackContext ctx)
    {
        if (!Sequence.AssignCurrentUnivers)
        {
            Sequence.AssignCurrentUnivers = true;
        }else
        {
            Sequence.AssignCurrentUnivers = false;
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

    void SphereLiquide(InputAction.CallbackContext ctx)
    {
        if (!Sequence.SphereLiquide)
        {
            Compo.SphereLiquide.SetActive(true);
            Sequence.SphereLiquide = true;
        }else
        {
            Compo.SphereLiquide.SetActive(false);
            Sequence.SphereLiquide = false;
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

    void Fade(InputAction.CallbackContext ctx)
    {
        if (!Sequence.Fade){
            Sequence.Fade = true;
        }else{
            Sequence.Fade = false;
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
        Compo.Landscape();
    }

    void DebugClean(InputAction.CallbackContext ctx)
    {
        Compo.Clean();
    }

    void Blink(InputAction.CallbackContext ctx)
    {
        Compo.AssignBlink = true;
    }

    void SwitchPP(InputAction.CallbackContext ctx)
    {
        if (!Sequence.PP)
        {
            Sequence.PP = true;
        }else{
            Sequence.PP = false;
        }

    }

    void SwitchCam(InputAction.CallbackContext ctx)
    {      
        Cam.SwitchCamOrtho();         
    }

    void AnimCam(InputAction.CallbackContext ctx)
    {
        Compo.AnimCam();
    }

    void Typo(InputAction.CallbackContext ctx)
    {
        if (!Sequence.Paean){
            Sequence.Paean = true;
        }else{
            Sequence.Paean = false;
        }
    }

    void UI(InputAction.CallbackContext ctx)
    {
        if (!Sequence.UI){
            Sequence.UI = true;
        } else {
            Sequence.UI = false;
        }
    }

    void ResetLevel(InputAction.CallbackContext ctx)
    {
        Application.LoadLevel(Application.loadedLevel);
    }



}
