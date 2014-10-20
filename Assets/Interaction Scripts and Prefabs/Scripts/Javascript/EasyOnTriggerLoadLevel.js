#pragma strict
@script RequireComponent(BoxCollider);
public var sceneFileName:String ="Level2";
public var destroyMeAfterwards:boolean;

function Start(){
	GetComponent(BoxCollider).isTrigger = true;
}
function OnTriggerEnter(){
	
	Application.LoadLevel(sceneFileName);
	
	if (destroyMeAfterwards == true){
		Destroy(gameObject);
	}
}