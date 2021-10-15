using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Render_Manager : MonoBehaviour
{

    public Composition_Manager Compo;
    public Cam_Manager Cam;
    public Scene_Manager Scene;

    void Start()
    {
    }

    void Update()
    {



          if (Input.GetKeyDown("b")) ////////// Assign Blink
          {
              Compo.AssignBlink = true;
          }

      }


}

