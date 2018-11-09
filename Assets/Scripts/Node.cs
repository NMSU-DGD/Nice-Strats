using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {

	public Color ActiveColor;
	private Color InActiveColor;
	private GameObject turret;
	public Vector3 TurretOffset;
	private Renderer rend;
	private Transform trans;

	void Start(){
		trans = GetComponent<Transform>();
		rend = GetComponent<Renderer>();
		InActiveColor = rend.material.color;
	}

	public void OnMouseDown(){
		if(turret != null){
			Debug.Log("Turret already present");
			return;
		}
		GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
		turret = (GameObject) Instantiate(turretToBuild,trans.position + TurretOffset, trans.rotation);
	}

	public void OnMouseEnter(){
		rend.material.color = ActiveColor;

	}

	public void OnMouseExit(){
		rend.material.color = InActiveColor;
	}

}
