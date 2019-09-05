using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	string sceneName = "Main";
    public int startLives = 3;
    private int points = 0;

	public TextMeshPro scoreText;
	public LivesController livesController;
	JumperSpawner jumperSpawner;
	public GameObject gameOverSign;
	public GameObject input;

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

    public int Points()
	{
		return points;
	}

	public void JumperCrashed()
	{
		if (!livesController.RemoveLife() )
		{
			GameOver();
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

    private void GameOver()
	{
		gameOverSign.SetActive(true);
		jumperSpawner.Stop();
		input.SetActive(false);
	}

    public void RestartGame()
	{
		SceneManager.LoadScene(sceneName);
	}

}
