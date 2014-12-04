using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	private bool moved = false;
	public Texture2D inact;
	public Texture2D act;
	public GUITexture toMove;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (guiTexture.HitTest (Input.mousePosition)) 
		{
			guiTexture.texture = act;
			
		} 
		else
		{
			guiTexture.texture = inact;
		}
		if (guiTexture.HitTest (Input.mousePosition) && Input.GetMouseButtonDown (0)) 
		{
			//print ("Clicked");
			if (!moved) 
			{
				//guiTexture.texture = act;
				Vector3 newY = toMove.transform.position;
				newY.y += 0.41f;//Time.deltaTime * 100;
				toMove.transform.position = newY;
				moved = !moved;
			} 
			else 
			{
				//guiTexture.texture = inact;
				Vector3 newY = toMove.transform.position;
				newY.y -= 0.41f;//Time.deltaTime * 100;
				toMove.transform.position = newY;
				moved = !moved;
			}
		}
	}


}
