using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Render_Manager : MonoBehaviour
{

    public Composition_Manager Compo;
    public Cam_Manager Cam;
    public Scene_Manager Scene;

    public bool AssignScene;

    public int TranslationIntensity;
    public int LandscapeIntensity;
    public int FragmentationIntensity;

    void Start()
    {
        AssignScene = false;
        FragmentationIntensity = 0;
    }


    void Update()
    {

        if (Input.GetKeyDown("a")) /////// Screen A full
        {
            Compo.CleanA();
            Compo.ScreenA();
        }

        if (Input.GetKeyDown("p"))  /////// Screen B full
        {
            Compo.CleanA();
            Compo.ScreenB();
        }
       
        if (Input.GetKeyDown("z")) /////// Vertical fragmentation A
        {
            Compo.SetupVerticalFragmentationA();
        }
        if (Input.GetKeyDown("o")) /////// Vertical fragmentation B
        {
            Compo.SetupVerticalFragmentationB();
        }
        if (Input.GetKeyDown("m")) /////// fragmentation AB
        {
              FragmentationIntensity++;
              if (FragmentationIntensity == 1){
                  Compo.SetupFragmentation();                    // Simple Fragmentation 
              }else if (FragmentationIntensity == 2){
                  Compo.SetupFragmentation();            
              }else if (FragmentationIntensity == 3){
                  Clean();
                  Compo.SetupTotalFragmentation();              // TotalFragmentation
              }

        }

        if (Input.GetKeyDown("q")) /////// Full Landscape
        {
            Compo.SetupFullLandscape();
        }

        if (Input.GetKeyDown("s"))  /////// Landscape
        {
            LandscapeIntensity++;
            if (LandscapeIntensity == 1){
                Compo.SetupLandscape();
            }else if (LandscapeIntensity == 2){
                Compo.SetupLandscape();
            }else if (LandscapeIntensity == 3){
                Clean();
                Compo.SetupCrossLandscape();    // Cross Landscape
            }
        }

        if (Input.GetKeyDown("y")) /////// Cam Ortho A
        {
            Cam.SetCamOrthoA();
        }
        if (Input.GetKeyDown("u")) /////// Cam Ortho B
        {
            Cam.SetCamOrthoB();
        }
        if (Input.GetKeyDown("w")) /////// Cam random set translation
        {
            TranslationIntensity++;
            if (TranslationIntensity == 1){
               Cam.CamTranslation();                     // Simple Translation
            }else if (TranslationIntensity == 2){
                Cam.CamTranslationCrossed();             // Crossed Translation
            }else if (TranslationIntensity == 3){
                Cam.CamTranslationMelt();               // Melted Translation
            }else{
                Clean();
            }
        }

        if (Input.GetKeyDown("t")) /////// TEXT PAEAN
        {
            Scene.TextPaeanApparition();
        }


        if (Input.GetKeyDown("space"))  /////// Just Clean
        {
            Clean();
        }

    }

    void Clean()
    {
        TranslationIntensity = 0;
        Compo.CleanA();
        Cam.ResetAll();
        LandscapeIntensity = 0;
        FragmentationIntensity = 0;
    }

}
