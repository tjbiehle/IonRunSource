using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {
	public GameObject PlayaBall;
	public GameObject PlayMenu;
	public float speed;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnMouseDown()
	{
//		Vector3 startforce = new Vector3 (0, 0, 100);
//		PlayaBall.gameObject.rigidbody.AddForce (startforce * speed * Time.deltaTime);
		gameObject.SetActive (false);
		PlayMenu.gameObject.SetActive (false);
	}


}
