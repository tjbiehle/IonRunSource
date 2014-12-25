using UnityEngine;
using System.Collections;

public class ClickPlayAnimationCS : MonoBehaviour {
	
	public Animation animationToPlay;
	public bool destroyMeAfterwards;
	
	// Use this for initialization
	void Start () {
		animationToPlay.Stop();
		animationToPlay.playAutomatically = false;
	}
	
	IEnumerator OnMouseUpEvent(){
	
		animationToPlay.Play();
		
		if (destroyMeAfterwards == true){
			yield return new WaitForSeconds(animationToPlay.clip.length);
			Destroy(gameObject);
		}
	}
}
