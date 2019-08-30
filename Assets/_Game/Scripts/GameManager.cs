using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int lives = 3;
    public int points = 0;


    public void JumperCrashed()
	{
		Debug.Log("Crash!!!");

		lives--;
	}

    public void JumperSaved()
	{
		points++;
	}


}
