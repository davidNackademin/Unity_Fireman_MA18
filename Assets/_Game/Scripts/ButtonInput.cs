using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInput : MonoBehaviour
{
    public bool left;

    public FiremanController fireman;

    private void OnMouseDown()
    {
        if (left)
        {
            fireman.OnLeftPressed();
        }
        else
        {
            fireman.OnRightPressed();      
        }
    }
}
