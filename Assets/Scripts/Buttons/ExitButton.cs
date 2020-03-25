using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using E = main.Loader;

public class ExitButton : MonoBehaviour
{
    public static bool clicked = false;


    void LateUpdate()
    {
        clicked = false;
        gameObject.SetActive(E.Get().CurrTrial.trialData.ExitButton);
    }

    public void ExitExperiment()
    {
        clicked = true;
    }

}

