using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {

	public GameObject PlayMenu;
	public GameObject resistor;
	public GameObject error;
	

	// Use this for initialization
		//When the Play Button is Pressed, deactivate it, this will trigger other things in other code.
	void OnMouseDown()
	{
		if (resistor.tag == "Resistor" || resistor.tag == "50Ohms" || resistor.tag == "100Ohms"  || resistor.tag == "200Ohms") {
			gameObject.SetActive (false);
			PlayMenu.gameObject.SetActive (false);
		}
		else {
			error.SetActive(true);
		}
	}


}
