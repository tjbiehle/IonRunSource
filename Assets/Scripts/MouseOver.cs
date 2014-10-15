using UnityEngine;
using System.Collections;

public class MouseOver : MonoBehaviour {
	private Color start, next = new Color(0.0f, 1.0f, 0.0f);
	// Update is called once per frame
	void Start() {
		start = renderer.material.color;
	}
	void OnMouseEnter () {
		renderer.material.color = next;
	}
	void OnMouseExit(){
		renderer.material.color = start;
	}
}
