using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[System.Serializable]
public class Boundary {
    public float xMin, xMax, yMin, yMax, zMin, zMax;
}

public class CameraController : MonoBehaviour {

	public float panSpeed = 30.0f;
	public float zoomFact = 50.0f;
	public float panBoarderThickness = 10.0f;
	public Text LockText;
	private bool PanLock = true;
	private bool ZoomLock = true;
	public Boundary boundary;
	private Transform trans;
	// Use this for initialization
	void Start () {
		trans = GetComponent<Transform>();
		LockText.text = "Camera Locks\n" + ZoomLock + " :Zoom\n" + PanLock + " :Pan\t";
	}
	
	// Update is called once per frame
	void Update () {
		
		float scroll = Input.GetAxis("Mouse ScrollWheel");
		//Debug.Log("Scroll: " + scroll);
		if(Input.GetKeyDown(KeyCode.Space)){
			PanLock = !PanLock;
		}
		if(Input.GetKeyDown(KeyCode.LeftAlt)){
			ZoomLock = !ZoomLock;
		}
		LockText.text = "Camera Locks\n" + ZoomLock + " :Zoom\n" + PanLock +" :Pan\t";
		if(PanLock == false){
			//Vector3 movement;
			if(Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBoarderThickness){
				trans.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
			}
			else if(Input.GetKey("s") || Input.mousePosition.y <= panBoarderThickness){
				trans.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
			}

			if(Input.GetKey("a") || Input.mousePosition.x <= panBoarderThickness){
				trans.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
			}
			else if(Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBoarderThickness){
				trans.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
			}	
		}
		if(ZoomLock == false){
			if(Input.GetKey(KeyCode.KeypadPlus) || Input.GetKey(KeyCode.Equals)){
				trans.Translate(Vector3.forward * zoomFact * Time.deltaTime);
			}
			else if(Input.GetKey(KeyCode.KeypadMinus) || Input.GetKey(KeyCode.Minus)){
				trans.Translate(Vector3.back * zoomFact * Time.deltaTime);
			}
			else if(scroll > 0){
				trans.Translate(Vector3.forward * Time.deltaTime * zoomFact * scroll * 20);
			}
			else if(scroll < 0){
				scroll = Mathf.Abs(scroll);
				trans.Translate(Vector3.back * Time.deltaTime * zoomFact * scroll * 20);
			}
		}
	}
}
