#pragma strict

public var objectToHide:GameObject;
public var destroyMeAfterwards:boolean =false;

function Start(){
	
}

function OnMouseUpEvent(){
	
	objectToHide.SetActive(false);
	
	if (destroyMeAfterwards == true){
		Destroy(gameObject);
	}
}