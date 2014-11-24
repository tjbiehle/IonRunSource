#pragma strict
@script RequireComponent(BoxCollider);
public var animationToPlay:Animation;
public var destroyMeAfterwards:boolean;

function Start(){

	animationToPlay.playAutomatically = false;
	GetComponent(BoxCollider).isTrigger = true;
}
function OnTriggerEnter(){
	
	animationToPlay.Play();
	
	if (destroyMeAfterwards == true){
		yield WaitForSeconds (animationToPlay.clip.length);
		Destroy(gameObject);
	}
}