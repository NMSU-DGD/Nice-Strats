using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {

	public Transform enemy;
	public Transform spawnPoint;

	public float timeBetweenWaves = 5.0f;
	public int MaxWaves=5;
	private float countdown = 2.0f;
	private int waveIndex = 0;
	
	// Update is called once per frame
	public void Update () {
		
		if(countdown <= 0 && waveIndex <= MaxWaves ){
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
