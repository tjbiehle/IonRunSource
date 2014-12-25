#pragma strict

public var objectToHide:GameObject;
public var hideBeforeShow:boolean=true;
public var destroyMeAfterwards:boolean =false;

function Start(){
	if(hideBeforeShow == true){
		objectToHide.SetActive(false);
	}
}

function OnMouseUpEvent(){
	
	objectToHide.SetActive(true);
	
	if (destroyMeAfterwards == true){
		Destroy(gameObject);
	}
}