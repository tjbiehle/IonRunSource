using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour {
	public GUIText Keys;
	// Use this for initialization
	void Start () {
		Keys.text = "\tKEY\nGreen = right-to-left diode\nOrange = left-to-right diode\nRed = 300 Ohm Resistor\nBlue = 700 Ohm Resistor";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
