using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]

public class ProximityPlayAnimationCS : MonoBehaviour {
	public Animation animationToPlay;
	public bool destroyMeAfterwards;
	
	void Awake(){
		animationToPlay.Stop();
		animationToPlay.playAutomatically = false;
		(GetComponent("BoxCollider") as BoxCollider).isTrigger = true;
	}
	
	IEnumerator OnTriggerEnter(){
		
		animationToPlay.Play();
		
		if (destroyMeAfterwards == true){
			yield return new WaitForSeconds (animationToPlay.clip.length);
			Destroy(gameObject);
		}
	}
}
