using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shop : MonoBehaviour {

	BuildManager buildManager;

	public void PurchaseStandardTurret(){
		Debug.Log("Standard Turret Purchased");
		buildManager.SetTurretToBuild(buildManager.standardTurret);
	}

	public void PurchaseRailgunTurret(){
		Debug.Log("Standard Turret Purchased");
	}
}
