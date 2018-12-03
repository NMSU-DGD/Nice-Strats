using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

	public static BuildManager instance;


	[Header("Turret List")]
	public TurretBlueprint[] Buildable;

	void Awake(){
		if(instance != null){
			Debug.LogError("More than one instance of BuildManager");
		}else{
			instance = this;
		}
	}

	//public GameObject standardTurret;
	//public GameObject anotherTurret;
	private TurretBlueprint turretToBuild;

	public void BuildTurretOn( Node node){
		if(PlayerStats.Currency < turretToBuild.cost){
			Debug.Log("Not enough money to build");
		}else{
			PlayerStats.Currency -= turretToBuild.cost;
			GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
			node.Turret = turret;
			Debug.Log("Turret build! Money left: " + PlayerStats.Currency);
		}
	}

	public void DestroyTurretOn(Node node){
		PlayerStats.Currency += (int)(turretToBuild.cost * 0.75f);
		Destroy(node.Turret);
		node.Turret = null;
	}

	public bool CanBuild{get{return turretToBuild != null;}}
	public void SelectTurretToBuild(int select){
		//Debug.Log("setting turretToBuild\nIndex value: " + select);
		turretToBuild = Buildable[select];
	}
}
