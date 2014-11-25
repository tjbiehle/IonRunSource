using UnityEngine;
using System.Collections;

public class objectNotes : MonoBehaviour {

	void OnMouseOver()
	{
		GUIText guiTXT = GameObject.Find ("outText").guiText;
		guiTXT.text = "NOTES";		// Notes about object to show up in GUI reference section goes here
	}

	// Clears the GUIText object when mouse is no longer hovering over the object
	void OnMouseExit()
	{
		GUIText guiTXT = GameObject.Find ("outText").guiText;
		guiTXT.text = "";
	}
}
