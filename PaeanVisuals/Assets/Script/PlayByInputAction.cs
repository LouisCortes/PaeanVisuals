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

    [SerializeField] InputAction _Clean = null;


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

        _Clean.performed += Clean;
        _Clean.Enable();

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

        _Clean.performed -= Clean;
        _Clean.Disable();
    }

    void ScreenA(InputAction.CallbackContext ctx)
    {
        Compo.Clean();
        Compo.ScreenA();
    }

    void FragmentationA(InputAction.CallbackContext ctx)
      =>
        GO.SetActive(true);

    void FragmentationB(InputAction.CallbackContext ctx)
     =>
    GO.SetActive(true);

    void ScreenB(InputAction.CallbackContext ctx)
      =>
        GO.SetActive(false);

    void SlicedA(InputAction.CallbackContext ctx)
     =>
       GO.SetActive(false);

    void FullLandscape(InputAction.CallbackContext ctx)
     =>
    GO.SetActive(false);

    void Landscape(InputAction.CallbackContext ctx)
     =>
       GO.SetActive(false);

    void SlicedB(InputAction.CallbackContext ctx)
     =>
       GO.SetActive(false);

    void Clean(InputAction.CallbackContext ctx)
     =>
       Debug.Log("OK");
}
