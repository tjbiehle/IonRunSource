using UnityEngine;
using System.Collections;

public class UnlockLevel3 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt ("Level3", 0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
		PlayerPrefs.SetInt ("Level3", 1);
		Application.LoadLevel("LevelSelect");
	}
}
