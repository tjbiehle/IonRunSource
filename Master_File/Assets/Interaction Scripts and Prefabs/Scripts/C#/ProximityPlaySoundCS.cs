using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(BoxCollider))]
	
public class ProximityPlaySoundCS : MonoBehaviour {
	
	public AudioClip soundToPlay;
	private AudioSource theAudio;
	public bool destroyMeAfterwards;

	void Start(){
		(GetComponent("BoxCollider") as BoxCollider).isTrigger = true;
		theAudio = GetComponent("AudioSource") as AudioSource;
		theAudio.playOnAwake = false;
		theAudio.clip = soundToPlay;
	}
	
	IEnumerator OnTriggerEnter(){
		
		theAudio.Play();
		
		if (destroyMeAfterwards == true){
			yield return new WaitForSeconds (soundToPlay.length);
			Destroy(gameObject);
		}
	}
}
