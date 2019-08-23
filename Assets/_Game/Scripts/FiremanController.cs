using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiremanController : MonoBehaviour
{

    public List<Transform> positions = new List<Transform>();

    private int currentPosition = 1;

    private void OnEnable()
    {
        ButtonInput.OnLeft += OnLeftPressed;
        ButtonInput.OnRight += OnRightPressed;
    }

    private void OnDisable()
    {
        ButtonInput.OnLeft -= OnLeftPressed;
        ButtonInput.OnRight -= OnRightPressed;
    }

    private void Start()
    {
        UpdatePosition();
    }

    public void OnLeftPressed()
    {

        if (currentPosition > 0)
        {
            currentPosition--;
            UpdatePosition();
        }
    }

    public void OnRightPressed()
    {

        if (currentPosition < positions.Count - 1)
        {
            currentPosition++;
            UpdatePosition();
        }
    }

    private void UpdatePosition()
    {
        transform.position = positions[currentPosition].position;
    }

}
