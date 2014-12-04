using UnityEngine;
using System.Collections;

public class goClick : MonoBehaviour {
	public Texture2D inact;
	public Texture2D act;
	public Texture2D hover;
	public GameObject gamerun;
	private bool moved = false;
	private bool running = false;

	void Update()
	{
		if(running == false)
		{
			if (guiTexture.HitTest (Input.mousePosition)) 
			{
				guiTexture.texture = hover;
				
			} 
			else
			{
				guiTexture.texture = inact;
			}
		}
		if (guiTexture.HitTest (Input.mousePosition) && Input.GetMouseButtonDown (0)) 
		{
			//START RUNNING CARS!
			gamerun.SetActive (!gamerun.activeSelf);
			running = !running;
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
