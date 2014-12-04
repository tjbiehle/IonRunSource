using UnityEngine;
using System.Collections;

public class StartLevel3 : MonoBehaviour {
	
	public Texture hover;
	public Texture no_hover;
	public Texture click;
	public Texture locked;

	private bool isLocked;

	private int level3i;

	void Start() {
		this.guiTexture.texture = locked;
		isLocked = true;
	}

	void Update() {
		level3i = PlayerPrefs.GetInt ("Level3");
		if (level3i == 1) {
			
			if (isLocked) {
				isLocked = false;
				this.guiTexture.texture = no_hover;
			}
			//this.guiTexture.texture = no_hover;
		}
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
