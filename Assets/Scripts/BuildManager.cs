﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

	public static BuildManager instance;

	void Awake(){
		if(instance != null){
			Debug.LogError("More than one instance of BuildManager");
		}else{
			instance = this;
		}
	}

	public GameObject standardTurret;
	private GameObject turretToBuild;
	public void Start(){
		turretToBuild = standardTurret;
	}

	public GameObject GetTurretToBuild(){
		return turretToBuild;
	}
}