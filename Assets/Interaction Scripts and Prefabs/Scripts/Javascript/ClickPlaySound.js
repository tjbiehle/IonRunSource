#pragma strict
@script RequireComponent(AudioSource);
public var soundToPlay:AudioClip;
private var theAudio:AudioSource ;
public var destroyMeAfterwards:boolean;

function Start(){
	theAudio = GetComponent(AudioSource);
	theAudio.playOnAwake = false;
	theAudio.clip = soundToPlay;
}
function OnMouseUpEvent(){
	
	theAudio.Play();
	
	if (destroyMeAfterwards == true){
		yield WaitForSeconds (soundToPlay.length);
		Destroy(gameObject);
	}
}