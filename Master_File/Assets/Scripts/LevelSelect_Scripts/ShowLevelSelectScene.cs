using UnityEngine;
using System.Collections;

public class ShowLevelSelectScene : MonoBehaviour {

	public Texture hover;
	public Texture no_hover;
	public Texture click;

	void Start() {
		this.guiTexture.texture = no_hover;
	}

	void OnMouseDown() {
		this.guiTexture.texture = click;
		Application.LoadLevel ("Levels");
}

	void OnMouseEnter() {
		this.guiTexture.texture = hover;
	}

	void OnMouseExit() {
		this.guiTexture.texture = no_hover;
	}

}
