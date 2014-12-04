using UnityEngine;
using System.Collections;

public class HideOnClick : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	

	}
	void OnMouseDown() {
		//this.guiTexture.texture = click;
		//Application.LoadLevel ("openingCutScene");
		gameObject.SetActive(false);
	}
}
