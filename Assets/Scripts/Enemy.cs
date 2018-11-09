using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public float speed;

	private Transform target;
	private int waypointIndex;
	private Transform trans;
	public void Start(){
		target = Waypoints.points[0];
		trans = GetComponent<Transform>();
	}

	public void Update(){
		Vector3 dir = target.position - trans.position;
		trans.Translate(dir.normalized * speed * Time.deltaTime,Space.World);
	
		//Debug.Log("Distance from next Waypoint: "+ Vector3.Distance(trans.position, target.position));
		if(Vector3.Distance(trans.position, target.position) <= 0.5f ){
			GetNextWaypoint();
		}
	}

	private void GetNextWaypoint(){

		if(waypointIndex >= Waypoints.points.Length-1){
			Destroy(gameObject);
		}else{
			waypointIndex++;
			target = Waypoints.points[waypointIndex];
		}
	}
}
