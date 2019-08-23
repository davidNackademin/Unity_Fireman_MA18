using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInput : MonoBehaviour
{
    public bool left;


    // deklarera 2st event 
    public delegate void ButtonPressed();
    public static event ButtonPressed OnLeft;
    public static event ButtonPressed OnRight;

    private void OnMouseDown()
    {
        if (OnLeft != null && left) // kolla att vi har åtminstonde en prenumerant på vårt event
        {
            OnLeft(); // trigga event Left
        }
        else if (OnRight != null)
        {
            OnRight(); // trigga event Right
        }
    }
}
