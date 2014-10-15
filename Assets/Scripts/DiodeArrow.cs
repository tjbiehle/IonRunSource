using UnityEngine;
using System.Collections;

public class DiodeArrow : MonoBehaviour {
	public GameObject Carryover;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position = Carryover.gameObject.transform.position;
	}
}
