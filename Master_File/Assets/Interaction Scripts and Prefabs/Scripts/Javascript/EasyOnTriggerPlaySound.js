#pragma strict
@script RequireComponent(AudioSource);
@script RequireComponent(BoxCollider);
public var soundToPlay:AudioClip;
private var theAudio:AudioSource ;
public var destroyMeAfterwards:boolean;

function Start(){
	GetComponent(BoxCollider).isTrigger = true;
	theAudio = GetComponent(AudioSource);
	theAudio.playOnAwake = false;
	theAudio.clip = soundToPlay;
}
function OnTriggerEnter(){
	
	theAudio.Play();
	
	if (destroyMeAfterwards == true){
		yield WaitForSeconds (soundToPlay.length);
		Destroy(gameObject);
	}
}