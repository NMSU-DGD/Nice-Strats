using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {

	public Transform enemy;
	public Transform spawnPoint;

	public float timeBetweenWaves = 5.0f;
	public static bool Win;
	public int MaxWaves=5;
	private float countdown = 2.0f;
	private int waveIndex = 0;
	
	// Update is called once per frame
	public void Start(){
		Win = false;
	}
	public void Update () {
		Debug.Log("Wave: " + waveIndex);
		Debug.Log("Max Waves: " + MaxWaves);
		if(waveIndex >= MaxWaves){
			Debug.Log("Win");
			Win = true;
		}

		if(countdown <= 0 && waveIndex < MaxWaves && !GameController.isGameOver){
			StartCoroutine(SpawnWave());
			countdown = timeBetweenWaves;
		}

		countdown -= Time.deltaTime;
	}

	public IEnumerator SpawnWave(){
		Debug.Log("Wave Spawned");
		waveIndex++;
		for(int i = 0; i < waveIndex; i++){
			SpawnEnemy();
			yield return new WaitForSeconds(0.5f);
		}
		
	}

	private void SpawnEnemy(){
		Instantiate(enemy,spawnPoint.position,spawnPoint.rotation);
	}
}
