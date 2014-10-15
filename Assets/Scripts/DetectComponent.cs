using UnityEngine;
using System.Collections;

public class DetectComponent : MonoBehaviour {
	bool occupied = false;
	private Vector3 offset = new Vector3 (0, 3, 0);
	public GameObject PostPlayButton;
	public GameObject Level;
	public GameObject LoseScreen;
	public GUIText Result;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	void OnTriggerEnter(Collider other)
	{
		if(PostPlayButton.gameObject.activeSelf == false)
		{
			if(!occupied)
			{
						//If there is a component on it
				if( (other.gameObject.tag == "Capacitor") || (other.gameObject.tag == "Resistor") || (other.gameObject.tag == "Inductor") || (other.gameObject.tag == "Resistor1") || (other.gameObject.tag == "Resistor2"))
				{
					Result.text = other.gameObject.tag;
					other.gameObject.rigidbody.AddForce (0, 200, 0);
					occupied = true;
					other.gameObject.transform.position = transform.position + offset;
				}
				if( other.gameObject.tag == "Player")
				{
					other.gameObject.SetActive (false);
					LoseScreen.gameObject.SetActive (true);
					Level.gameObject.SetActive (false);
				}
			}

		}

	}
}
