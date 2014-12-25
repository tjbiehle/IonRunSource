using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]

public class ClickPlaySoundCS : MonoBehaviour {

	public AudioClip soundToPlay;
	private AudioSource theAudio;
	public bool destroyMeAfterwards;

	void Awake(){
		theAudio = GetComponent("AudioSource") as AudioSource;
		theAudio.Stop();
		theAudio.playOnAwake = false;
		theAudio.clip = soundToPlay;
	}

	IEnumerator OnMouseUpEvent(){
		
		theAudio.Play();
		
		if (destroyMeAfterwards == true){
			yield return new WaitForSeconds(soundToPlay.length);
			Destroy(gameObject);
		}
	}
}
