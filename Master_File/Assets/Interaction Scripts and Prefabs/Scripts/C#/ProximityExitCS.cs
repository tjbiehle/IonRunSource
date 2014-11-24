using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]

public class ProximityExitCS : MonoBehaviour {

	// Use this for initialization
	void Start () {
		(GetComponent("BoxCollider") as BoxCollider).isTrigger = true;
	}
	
	void OnTriggerEnter(){
		Application.Quit();
	}
}
