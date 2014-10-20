#pragma strict
public var websiteURL:String = "http://www.google.com";
public var destroyMeAfterwards:boolean;

function OnMouseUpEvent(){
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