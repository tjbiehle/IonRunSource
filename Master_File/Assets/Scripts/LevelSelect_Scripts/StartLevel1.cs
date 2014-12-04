using UnityEngine;
using System.Collections;

public class StartLevel1 : MonoBehaviour {

	public Texture hover;
	public Texture no_hover;
	public Texture click;
	public Texture locked;

	bool isLocked;
	
	void Start() {
		this.guiTexture.texture = no_hover;
		isLocked = false;
	}
	
	void OnMouseDown() {
		this.guiTexture.texture = click;
		Application.LoadLevel ("Canyon_Level");
	}
	
	void OnMouseEnter() {
		this.guiTexture.texture = hover;
	}
	
	void OnMouseExit() {
		this.guiTexture.texture = no_hover;
	}
}
