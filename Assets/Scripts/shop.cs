using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shop : MonoBehaviour {

	//BuildManager buildManager;

	public void Start(){}

	public void PurchaseStandardTurret(){
		Debug.Log("Standard Turret Purchased");
		BuildManager.instance.SetTurretToBuild(0);
	}

	public void PurchaseRailgunTurret(){
		Debug.Log("Standard Turret Purchased");
		BuildManager.instance.SetTurretToBuild(1);
	}
}
