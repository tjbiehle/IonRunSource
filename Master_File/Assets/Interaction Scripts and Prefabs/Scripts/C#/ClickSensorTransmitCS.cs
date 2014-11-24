using UnityEngine;
using System.Collections;

public class ClickSensorTransmitCS : MonoBehaviour {
	
	ClickSensorCS cs;
	
	// Use this for initialization
	void Start () {
		cs = gameObject.GetComponentInChildren<ClickSensorCS>();
		gameObject.collider.isTrigger = true;
	}
	
	void OnMouseDown(){
		if(cs.detectMouseDown == true){
			gameObject.BroadcastMessage("OnMouseDownEvent", SendMessageOptions.DontRequireReceiver);
		}
	}

	void OnMouseUp () {
		if(cs.detectMouseUp == true){
			gameObject.BroadcastMessage("OnMouseUpEvent", SendMessageOptions.DontRequireReceiver);
		}
	}
	
	void OnMouseDrag(){
		if(cs.detectMouseDrag == true){
			gameObject.BroadcastMessage("OnMouseDragEvent", SendMessageOptions.DontRequireReceiver);
		}
		
	}
	
	void OnMouseEnter () {
		if(cs.detectMouseEnter == true){
			gameObject.BroadcastMessage("OnMouseEnterEvent", SendMessageOptions.DontRequireReceiver);
		}
	    
	}
	
	void OnMouseExit () {
		if(cs.detectMouseExit == true){
			gameObject.BroadcastMessage("OnMouseExitEvent", SendMessageOptions.DontRequireReceiver);
		}
	    
	}
}
