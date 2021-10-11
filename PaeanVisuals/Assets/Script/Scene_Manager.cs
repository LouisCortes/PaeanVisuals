using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Scene_Manager : MonoBehaviour
{
    public GameObject Paean;
    public GameObject UI_GPS;
    public Text CoordN;
    public Text CoordE;
    private long N = 84814453125;
    private long E = 347232341766357;
    void Start()
    {
        UI_GPS.SetActive(false);
        Paean.SetActive(false);
    }


    void Update()
    {
        if (UI_GPS)
        {
            N++;
            CoordN.text = "" + N;
            E++;
            CoordE.text = "" + E;
        }

    }

    public void UIGPSApparition()
    {
        if (UI_GPS.activeInHierarchy){
            UI_GPS.SetActive(false);
        }else{
            UI_GPS.SetActive(true);
        }
    }

    public void TextPaeanApparition()
    {
        if (Paean.activeInHierarchy){
            Paean.SetActive(false);
        }else{
            Paean.SetActive(true);
        }
    }
}
