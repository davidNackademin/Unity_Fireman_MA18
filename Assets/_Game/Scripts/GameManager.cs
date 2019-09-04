using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int startLives = 3;
    int points = 0;

	public TextMeshPro scoreText;
	public LivesController livesController;
	JumperSpawner jumperSpawner;
	public GameObject gameOverSign;

    void OnEnable()
	{
		JumperController.OnJumperCrash += JumperCrashed;
		JumperController.OnJumperSave += JumperSaved;
	}

	void OnDisable()
	{
		JumperController.OnJumperCrash -= JumperCrashed;
		JumperController.OnJumperSave -= JumperSaved;
	}

    void Start()
	{
		UpdateScoreLabel();
		livesController.InitLives(startLives);
		jumperSpawner = GetComponent<JumperSpawner>();
		gameOverSign.SetActive(false);
	}


	public void JumperCrashed()
	{
		if (!livesController.RemoveLife() )
		{
			gameOverSign.SetActive(true);
			jumperSpawner.Stop();
		}
	}

    public void JumperSaved()
	{
		points++;
		UpdateScoreLabel();
	}

    void UpdateScoreLabel()
	{
		scoreText.text = points.ToString();
	}

}
