using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour {

	public Text ScoreText;
	public Text FailedText;
	public Text MoneyText;
	public GameObject RestartButton;
	public GameObject ExitButton;
	public Text GameOver;
	public static bool isGameOver;
	public int score;
	public int failed;
	public int maxFail;

	// Use this for initialization
	void Start () {
		score = 0;
		failed = 0;
		isGameOver = false;
		//
		RestartButton.SetActive(false);
		ExitButton.SetActive(false);
		//
		UpdateScore();
		UpdateFailed();
		UpdateMoney();
		UpdateGameOver();
	}
	
	// Update is called once per frame
	void Update () {
		if(failed >= maxFail || WaveSpawner.Win){
			isGameOver = true;
			RestartButton.SetActive(true);
			ExitButton.SetActive(true);
		}
		UpdateMoney();
		UpdateGameOver();
	}

	public void UpdateScore(){
		ScoreText.text = "Score: " + score;
	}
	 
	public void UpdateFailed(){
		FailedText.text = "Failed: " + failed;
	}

	public void UpdateMoney(){
		MoneyText.text = "Money: " + PlayerStats.Currency;
	}

	public void UpdateGameOver(){
		if(!isGameOver){
			GameOver.text = "";
		}
		else if(isGameOver && !WaveSpawner.Win){
			GameOver.text = "Game Over\nYou Failed";
		}
		else if(isGameOver && WaveSpawner.Win){
			GameOver.text = "Game Over\nYou Passed";
		}
	}
	public void addScore(){
		score++;
		UpdateScore();
	}
	public void addFailed(){
		failed++;
		UpdateFailed();
	}
}
