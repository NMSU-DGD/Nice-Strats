using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

	public static BuildManager instance;
	public static GameObject[] BuildableTurrets;

	void Awake(){
		BuildableTurrets = new GameObject[6];
		if(instance != null){
			Debug.LogError("More than one instance of BuildManager");
		}else{
			instance = this;
		}
	}

	public GameObject[] standardTurrets;


	public void Start(){
		//turretToBuild = standardTurret;
		BuildableTurrets = standardTurrets;
	}

	public GameObject GetTurretToBuild(int select){
		return BuildableTurrets[select];
	}
}
