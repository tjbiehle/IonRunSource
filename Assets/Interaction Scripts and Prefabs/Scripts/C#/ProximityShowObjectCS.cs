using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]

public class ProximityShowObjectCS : MonoBehaviour {
	public GameObject objectToShow;
	public bool hideBeforeShow;
	public bool destroyMeAfterwards;
	
	void Start () {
		(GetComponent("BoxCollider") as BoxCollider).isTrigger = true;
		if(hideBeforeShow == true){
			objectToShow.SetActive(false);
		}
	}
	
	void OnTriggerEnter(){
		objectToShow.SetActive(true);
		if (destroyMeAfterwards == true){
			Destroy(gameObject);
		}
	}
}
