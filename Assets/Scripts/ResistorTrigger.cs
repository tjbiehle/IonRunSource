using UnityEngine;
using System.Collections;

public class ResistorTrigger : MonoBehaviour {
	public GameObject Parent;
	public float ID;
	private Vector3 offset = new Vector3 (0,0,0);
	// Use this for initialization
	void Start () 
	{
			//Resistor

		if (ID == 1)
			offset = new Vector3 (4, 0, 0);
		if (ID == 2)
			offset = new Vector3 (-4, 0, 0);
		if (ID == 3)
			offset = new Vector3 (0, 0, 4);
		if (ID == 4)
			offset = new Vector3 (0, 0, -4);

			//Capacitor 

		if (ID == 5)
			offset = new Vector3 (2, 0, 0);
		if (ID == 6)
			offset = new Vector3 (-2, 0, 0);
		if (ID == 7)
			offset = new Vector3 (0, 0, 2);
		if (ID == 8)
			offset = new Vector3 (0, 0, -2);

			//Inductor

		if (ID == 9)
			offset = new Vector3 (4, 0, 0);
		if (ID == 10)
			offset = new Vector3 (-4, 0, 0);
		if (ID == 11)
			offset = new Vector3 (0, 0, 4);
		if (ID == 12)
			offset = new Vector3 (0, 0, -4);
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position = Parent.gameObject.transform.position + offset;
		Vector3 temp = new Vector3 (transform.position.x, 0f, transform.position.z);
		transform.position = temp;
	}
}
