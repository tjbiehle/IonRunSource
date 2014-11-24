using UnityEngine;
using System.Collections;

public class goClick : MonoBehaviour {
	public Texture2D inact;
	public Texture2D act;
	private bool moved = false;

	void Update()
	{
		if (guiTexture.HitTest (Input.mousePosition) && Input.GetMouseButtonDown (0)) 
		{
			//print ("Clicked");
			if (!moved) 
			{
				guiTexture.texture = act;

				moved = !moved;

			} 
			else 
			{
				guiTexture.texture = inact;

				moved = !moved;
			}
		}
	}

}
