using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class ButtonActions : MonoBehaviour {

	public void ButtonClickRestart(){
		SceneManager.LoadScene("Main");
	}
	public void ButtonClickExit(){
		Application.Quit();
	}
}
