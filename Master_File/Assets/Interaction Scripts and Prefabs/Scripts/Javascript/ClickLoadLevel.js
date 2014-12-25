#pragma strict

public var sceneFileName:String ="Level2";
public var destroyMeAfterwards:boolean;

function Start(){


	
}
function OnMouseUpEvent(){
	
	Application.LoadLevel(sceneFileName);
	
	if (destroyMeAfterwards == true){
		Destroy(gameObject);
	}
}