using UnityEngine;
using System.Collections;

public class StartLevel2 : MonoBehaviour {
	
	public Texture hover;
	public Texture no_hover;
	public Texture click;
	public Texture locked;

	private bool isLocked;

	private int level2i;
	
	void Start() {
		this.guiTexture.texture = locked;
		isLocked = true;
	}

	void Update() {
		level2i = PlayerPrefs.GetInt ("Level2");
		if (level2i == 1) {

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
		Application.LoadLevel ("taylor_level1");
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
