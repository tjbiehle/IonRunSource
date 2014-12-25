using UnityEngine;
using System.Collections;

public class ClickSensorCS: MonoBehaviour {
	
	public bool detectMouseDown;
	public bool detectMouseUp;
	public bool detectMouseDrag;
	public bool detectMouseEnter;
	public bool detectMouseExit;
	 

	// Use this for initialization
	void Start () {
		transform.parent.gameObject.AddComponent("ClickSensorTransmitCS");
	}
	
	void OnMouseDownEvent(){
	//Debug.Log("MouseDown");
	}
	
	void OnMouseUpEvent() {
	    //Debug.Log("MouseUp"); 
	}
	
	void OnMouseDragEvent(){
		//Debug.Log("MouseDrag");
	}
	
	void OnMouseEnterEvent() {
	   // Debug.Log("MouseEnter");
	}
	
	void OnMouseExitEvent() {
	    //Debug.Log("MouseExit");
	}
}
