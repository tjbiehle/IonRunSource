using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]

public class ProximityHideObjectCS : MonoBehaviour {

	public GameObject objectToHide;
	public bool destroyMeAfterwards;
	
	void Start () {
		(GetComponent("BoxCollider") as BoxCollider).isTrigger = true;
	}
	
	void OnTriggerEnter(){
	
		objectToHide.SetActive(false);
		
		if (destroyMeAfterwards == true){
			Destroy(gameObject);
		}
	}
}
