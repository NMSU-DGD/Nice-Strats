using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

	private GameController gameController;

	// Use this for initialization
	void Start () {
		GameObject gameControllerObject = GameObject.FindWithTag("Game Controller");
        if (gameControllerObject != null) {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameControllerObject == null) {
            Debug.Log("Cannot find 'GameController' Script");
        }
	}

	private void OnTriggerEnter(Collider other){
		if(other.tag == "Bullet"){
			Destroy(other.gameObject);
			Destroy(gameObject);
			gameController.addScore();
			PlayerStats.Currency += 10;
		}
		else if(other.tag == "End Point"){
			Destroy(gameObject);
			gameController.addFailed();
			
		}

	}
}
