using UnityEngine;
using System.Collections;

public class ClickShowObjectCS : MonoBehaviour {
	public GameObject objectToShow;
	public bool hideBeforeShow;
	public bool destroyMeAfterwards=false;
	
	// Use this for initialization
	void Awake () {
		if(hideBeforeShow == true){
			objectToShow.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void OnMouseUpEvent(){
		
		objectToShow.SetActive(true);
		
		if (destroyMeAfterwards == true){
			Destroy(gameObject);
		}
	}
}
