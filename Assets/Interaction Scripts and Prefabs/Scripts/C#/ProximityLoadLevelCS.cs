using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]

public class ProximityLoadLevelCS : MonoBehaviour {
	public string sceneFileName ="Level2";
	public bool destroyMeAfterwards;
	
	void Start(){
		(GetComponent("BoxCollider") as BoxCollider).isTrigger = true;
	}
	
	void OnTriggerEnter(){
		
		Application.LoadLevel(sceneFileName);
		
		if (destroyMeAfterwards == true){
			Destroy(gameObject);
		}
	}
}
