using UnityEngine;
using System.Collections;

public class ClickOpenWebsiteCS : MonoBehaviour {
	public string websiteURL= "http://www.google.com";
	public bool destroyMeAfterwards;
	
	IEnumerator OnMouseUpEvent(){
		// If there was no "http://" add it to avoid error
		if(websiteURL.IndexOf("http://") == -1){
			websiteURL = "http://" + websiteURL;
			Debug.Log(websiteURL);
		}
		
		Application.OpenURL(websiteURL);
		
		if (destroyMeAfterwards == true){
			yield return new WaitForSeconds(2);
			Destroy(gameObject);
		}
	}
}
