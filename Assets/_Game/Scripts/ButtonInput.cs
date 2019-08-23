using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInput : MonoBehaviour
{
    public bool left;

    public delegate void ButtonPressed();
    public static event ButtonPressed OnLeft;
    public static event ButtonPressed OnRight;


    // public FiremanController fireman;

    private void OnMouseDown()
    {
        if (OnLeft != null && left) // kolla att vi har åtminstonde en prenumerant på vårt event
        {
            OnLeft();
          //  fireman.OnLeftPressed();
        }
        else if (OnRight != null)
        {
            OnRight();
           // fireman.OnRightPressed();      
        }
    }
}
