#pragma strict
@script RequireComponent(BoxCollider);

function Start(){


	GetComponent(BoxCollider).isTrigger = true;
}
function OnTriggerEnter(){
	
	Application.Quit();
	
	
}