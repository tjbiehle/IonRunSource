using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]

public class ProximityOpenWebsiteCS : MonoBehaviour {
	public string websiteURL = "http://www.google.com";
	public bool destroyMeAfterwards;
	
	void Start(){
	(GetComponent("BoxCollider") as BoxCollider).isTrigger = true;
	}
	
	void OnTriggerEnter(){
		// If there was no "http://" add it to avoid error
		if(websiteURL.IndexOf("http://") == -1){
			websiteURL = "http://" + websiteURL;
			Debug.Log(websiteURL);
		}
		
		Application.OpenURL(websiteURL);
		
		if (destroyMeAfterwards == true){
			Destroy(gameObject);
		}
	}
}
