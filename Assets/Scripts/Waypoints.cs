using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour {

	public static Transform[] points;
	private Transform trans;
	void Awake(){
		trans = GetComponent<Transform>();
		points = new Transform[trans.childCount];
		Debug.Log(points.Length);
		for(int i = 0; i < points.Length; i++){
			points[i] = trans.GetChild(i);
		}
	}
}
