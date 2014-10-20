using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {

	public GameObject PlayMenu;
	// Use this for initialization
		//When the Play Button is Pressed, deactivate it, this will trigger other things in other code.
	void OnMouseDown()
	{

		gameObject.SetActive (false);
		PlayMenu.gameObject.SetActive (false);
	}


}
