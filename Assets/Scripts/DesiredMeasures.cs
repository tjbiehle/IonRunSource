using UnityEngine;
using System.Collections;

public class DesiredMeasures : MonoBehaviour {
	public GUIText Description;
	public float min;
	public float max;
	public float A_V;
	// Use this for initialization
	void Start () 
	{
		string myresult = "";
		if(A_V == 0)
			myresult = "Maximum Current Flow: " + max + "A\nMinimum Current Flow: " + min + "A";
		else {
			myresult = "Maximum Voltage: " + max + "V\nMinimum Voltage: " + min + "V";
		}
		Description.pixelOffset = new Vector2 (transform.position.x , transform.position.z - 3) * 10;
		Description.text = myresult;
	}
	
	// Update is called once per frame

}
