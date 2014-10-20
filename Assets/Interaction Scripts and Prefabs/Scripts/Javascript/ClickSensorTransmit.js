#pragma strict

private var cs:ClickSensor;

function Start(){
	cs = gameObject.GetComponentInChildren(ClickSensor);
	gameObject.collider.isTrigger = true;
}

function OnMouseDown(){
	if(cs.detectMouseDown == true){
		gameObject.BroadcastMessage("OnMouseDownEvent", SendMessageOptions.DontRequireReceiver);
	}
}

function OnMouseUp () {
	if(cs.detectMouseUp == true){
		gameObject.BroadcastMessage("OnMouseUpEvent", SendMessageOptions.DontRequireReceiver);
	}
}

function OnMouseDrag(){
	if(cs.detectMouseDrag == true){
		gameObject.BroadcastMessage("OnMouseDragEvent", SendMessageOptions.DontRequireReceiver);
	}
	
}

function OnMouseEnter () {
	if(cs.detectMouseEnter == true){
		gameObject.BroadcastMessage("OnMouseEnterEvent", SendMessageOptions.DontRequireReceiver);
	}
    
}

function OnMouseExit () {
	if(cs.detectMouseExit == true){
		gameObject.BroadcastMessage("OnMouseExitEvent", SendMessageOptions.DontRequireReceiver);
	}
    
}
