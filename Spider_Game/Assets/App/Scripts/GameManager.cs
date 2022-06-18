using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	[SerializeField] private string highScoreKey;
	
	[Header("Components")]
	[SerializeField] private Rigidbody2D playerRg2D;
	[SerializeField] GameObject player, gameOverCanvas, gamePlayCanvas;
	[SerializeField] Slider m_Slider;
	[SerializeField] TextMeshProUGUI inGameScore, finalScore, bestScore;
	[SerializeField] Image textTapStart;
	
	private int scoreValue;

	// Start is called before the first frame update
	void Start()
	{
		gameOverCanvas.SetActive(false);
		gamePlayCanvas.SetActive(true);
		textTapStart.gameObject.SetActive(true);
		playerRg2D.bodyType = RigidbodyType2D.Static;
		Time.timeScale = 1;
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		StartGame();
		InGameScore();
	}

	private void StartGame()
	{
		if (Input.GetMouseButtonDown(0) || Input.anyKey)
		{
			playerRg2D.bodyType = RigidbodyType2D.Dynamic;
			textTapStart.gameObject.SetActive(false);
		}
	}

	public void GameOver()
	{
		Time.timeScale = 0;
		gameOverCanvas.SetActive(true);
		gamePlayCanvas.SetActive(false);
		BestScore();
	}

	public void Restart()
	{
		SceneManager.LoadScene(0);
		gameOverCanvas.SetActive(false);
	}

	public void InGameScore()
	{
		scoreValue = (int)player.transform.position.x / 10;

		inGameScore.text = "Score: " + scoreValue;

		m_Slider.value = scoreValue;
	}

	public void BestScore()
	{
		int highScore = PlayerPrefs.GetInt(highScoreKey);

		if (scoreValue > highScore)
		{
			highScore = scoreValue;
			PlayerPrefs.SetInt(highScoreKey, highScore);
			finalScore.text = "Score: " + scoreValue;
			bestScore.text = "Best : " + bestScore;
		}
		else
		{
			finalScore.text = "Score: " + scoreValue;
			bestScore.text = "Best : " + highScore;
		}
	}


}
