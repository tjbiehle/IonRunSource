#pragma strict
public var animationToPlay:Animation;
public var destroyMeAfterwards:boolean;

function Start(){

	animationToPlay.playAutomatically = false;
	
}

function OnMouseUpEvent(){
	
	animationToPlay.Play();
	
	if (destroyMeAfterwards == true){
		yield WaitForSeconds (animationToPlay.clip.length);
		Destroy(gameObject);
	}
}