using UnityEngine;
using System.Collections;

public class UnlockLevel2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt ("Level2", 0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
		PlayerPrefs.SetInt ("Level2", 1);
		Application.LoadLevel("LevelSelect");
	}
}
