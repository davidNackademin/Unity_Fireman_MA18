using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverSignController : MonoBehaviour
{
	public GameManager gameManager;

    public void OnMouseDown()
	{
		gameManager.RestartGame();
	}

}
