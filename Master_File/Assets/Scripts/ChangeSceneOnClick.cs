using UnityEngine;
using System.Collections;

public class ChangeSceneOnClick : MonoBehaviour {


	public string scene_name;


	void OnMouseDown() {
		Application.LoadLevel (scene_name);
	}
}
