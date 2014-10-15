using UnityEngine;
using System.Collections;

public class DetermineResistor : MonoBehaviour {
	bool setval = false;

	public GUIText Currval;

	string result = "";
	
	void OnMouseDown()
	{
		setval = true;
		
	}
	
	// Use this for initialization
	void Start () 
	{
		Currval.text = gameObject.name + " Ohms";
		Currval.pixelOffset = new Vector2 (gameObject.transform.position.x + 2, gameObject.transform.position.z ) *10;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		if(setval)
		{
			if(Input.GetKeyDown ("1"))
				result += "1";
			if(Input.GetKeyDown ("2"))
				result += "2";
			if(Input.GetKeyDown ("3"))
				result += "3";
			if(Input.GetKeyDown ("4"))
				result += "4";
			if(Input.GetKeyDown ("5"))
				result += "5";
			if(Input.GetKeyDown ("6"))
				result += "6";
			if(Input.GetKeyDown ("7"))
				result += "7";
			if(Input.GetKeyDown  ("8"))
				result += "8";
			if(Input.GetKeyDown ("9"))
				result += "9";
			if(Input.GetKeyDown ("0"))
				result += "0";
			if (Input.GetKeyDown ("c"))
				result = "";
			if (Input.GetKeyDown ("."))
			{
				gameObject.name = result;
				setval = false;
			}
			Currval.text = result + " Ohms";
		}
	}
}
