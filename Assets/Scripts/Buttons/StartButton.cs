using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StartButton : MonoBehaviour
{
    public static bool clicked = false;

    void LateUpdate()
    {
        clicked = false;
    }

    public void Click()
    {
        clicked = true;
    }
}
