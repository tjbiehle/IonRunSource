using UnityEngine;
using System.Collections;

public class ChangeSkinOnClick : MonoBehaviour {
	bool onState;
	public Material onSkin;
	public Material offSkin;
	// Use this for initialization
	void Start () {
		onState = false;
	}
	
	// Update is called once per frame
	void OnMouseDown () {
		if(onState)
			renderer.material = offSkin;
		else 
			renderer.material = onSkin;
		onState = !onState;
	}
}
