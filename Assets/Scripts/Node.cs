using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

	public Color ActiveColor;
	private Color InActiveColor;
	[Header("Optional")]
	public GameObject Turret;

	public Vector3 TurretOffset;
	private Renderer rend;
	private Transform trans;

	private BuildManager buildManager;
	void Start(){
		buildManager = BuildManager.instance;
		trans = GetComponent<Transform>();
		rend = GetComponent<Renderer>();
		InActiveColor = rend.material.color;
	}

	public Vector3 GetBuildPosition(){
		return trans.position + TurretOffset;
	}

	public void OnMouseDown(){
		if(EventSystem.current.IsPointerOverGameObject()){
			return;
		}
		if(!buildManager.CanBuild){
			return;
		}
		if(Turret != null){
			if(Input.GetKey(KeyCode.LeftShift)){
				buildManager.DestroyTurretOn(this);
			}
			Debug.Log("Turret already present");
			return;
		}
		
		buildManager.BuildTurretOn(this);
	
	}

	public void OnMouseEnter(){
		if(EventSystem.current.IsPointerOverGameObject()){
			return;
		}
		if(!buildManager.CanBuild){
			return;
		}

		rend.material.color = ActiveColor;

	}

	public void OnMouseExit(){
		rend.material.color = InActiveColor;
	}

}
