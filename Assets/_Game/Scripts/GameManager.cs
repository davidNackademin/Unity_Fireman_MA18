using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int lives = 3;
    int points = 0;

	public TextMeshPro scoreText;

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
	}


	public void JumperCrashed()
	{
		lives--;
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
