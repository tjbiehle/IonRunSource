using UnityEngine;
using System.Collections;

public class StartLevel3 : MonoBehaviour {
	
	public Texture hover;
	public Texture no_hover;
	public Texture click;
	public Texture locked;

	bool isLocked;

	void Start() {
		this.guiTexture.texture = locked;
		isLocked = true;
	}
	
	void OnMouseDown() {
		if (!isLocked) {
			this.guiTexture.texture = click;
			Application.LoadLevel ("test city scene2");
		}
	}
	
	void OnMouseEnter() {
		if (!isLocked) {
			this.guiTexture.texture = hover;
		}
	}
	
	void OnMouseExit() {
		if (!isLocked) {
			this.guiTexture.texture = no_hover;
		}
	}
}
