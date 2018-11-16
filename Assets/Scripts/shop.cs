using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shop : MonoBehaviour {

	private BuildManager buildManager;

	public void Start(){
		buildManager = BuildManager.instance;
	}

	public void PurchaseStandardTurret(){
		Debug.Log("Standard Turret Purchased");
		buildManager.SelectTurretToBuild(0);
	}

	public void PurchaseRailgunTurret(){
		Debug.Log("Railgun Turret Purchased");
		buildManager.SelectTurretToBuild(1);
	}
}
