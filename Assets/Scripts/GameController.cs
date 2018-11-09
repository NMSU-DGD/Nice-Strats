using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour {

	public Text ScoreText;
	public Text FailedText;
	public int score;
	public int failed;

	// Use this for initialization
	void Start () {
		score = 0;
		failed = 0;
		UpdateScore();
		UpdateFailed();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void UpdateScore(){
		ScoreText.text = "Score: " + score;
	}
	public void UpdateFailed(){
		FailedText.text = "Failed: " + failed;
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
