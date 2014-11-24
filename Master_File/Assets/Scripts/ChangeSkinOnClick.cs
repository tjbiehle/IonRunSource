using UnityEngine;
using System.Collections;

public class ChangeSkinOnClick : MonoBehaviour {
	bool onState;

	public GameObject menu;
	// Use this for initialization
	void Start () {
		onState = false;
	}
	
	// Update is called once per frame
	void OnMouseDown () {
		if (onState) {
			menu.SetActive(false);
		}
		else {
			menu.SetActive(true);
		}
		onState = !onState;
	}
}
