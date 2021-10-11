using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_Manager : MonoBehaviour
{
    public GameObject Paean;

    void Start()
    {
        Paean.SetActive(false);
    }


    void Update()
    {
        
    }

    public void TextPaeanApparition()
    {
        if (Paean.activeInHierarchy)
        {
            Paean.SetActive(false);
        }else{
            Paean.SetActive(true);
        }

    }
}
