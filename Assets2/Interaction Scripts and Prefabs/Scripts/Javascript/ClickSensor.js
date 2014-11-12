#pragma strict

public var detectMouseDown:boolean;
public var detectMouseUp:boolean;
public var detectMouseDrag:boolean;
public var detectMouseEnter:boolean;
public var detectMouseExit:boolean;

function Start () {
	transform.parent.gameObject.AddComponent("ClickSensorTransmit");
}

function OnMouseDownEvent(){
	//Debug.Log("MouseDown");
}

function OnMouseUpEvent() {
    //Debug.Log("MouseUp"); 
}

function OnMouseDragEvent(){
	//Debug.Log("MouseDrag");
}

function OnMouseEnterEvent() {
   // Debug.Log("MouseEnter");
}

function OnMouseExitEvent() {
    //Debug.Log("MouseExit");
}