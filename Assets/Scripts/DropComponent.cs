using UnityEngine;
using System.Collections;

public class DropComponent : MonoBehaviour 
{
	bool downward = false;
	private Vector3 screenPoint;
	private Vector3 offset;

	public GameObject PlayButton;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (PlayButton.gameObject.activeSelf == false && downward == false) 
		{
			downward = true;
			gameObject.rigidbody.AddForce (0,-200 , 0);
		}
		if(gameObject.transform.position.y < -3)
		{
			gameObject.SetActive (false);
		}
	}

	void OnMouseDown()
	{
		if(PlayButton.gameObject.activeSelf == true)
		{
			screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
			offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
		}
	}

	void OnMouseDrag() 
	{  
		if(PlayButton.gameObject.activeSelf == true)
		{
			Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
			
			Vector3 curPosition   = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
			transform.position = curPosition;
		}

	}
			/***************************** REMOVE IF OBJCTS DISAPPEARING ********************************/
	void OnTriggerEnter(Collider other)
	{
		if(PlayButton.gameObject.activeSelf == false)
		{

				//If there is a component on it
				if( other.gameObject.tag == "FloorTrigger" )
				{
				gameObject.SetActive (false);
					
				}

			
		}
		
	}

}

