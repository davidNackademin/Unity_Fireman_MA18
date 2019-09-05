using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
	public AudioClip beep;

	AudioSource audioSource;

    private void OnEnable()
    {
        ButtonInput.OnLeft += ButtonInput_OnLeft;
        ButtonInput.OnRight += ButtonInput_OnRight;
    }

    private void OnDisable()
    {
        ButtonInput.OnLeft -= ButtonInput_OnLeft;
        ButtonInput.OnRight -= ButtonInput_OnRight;
    }

    void Start()
	{
		audioSource = GetComponent<AudioSource>();
		audioSource.clip = beep;
	}


    private void ButtonInput_OnRight()
    {
		audioSource.Play();
    }

    private void ButtonInput_OnLeft()
    {
		audioSource.Play();
	}
}
