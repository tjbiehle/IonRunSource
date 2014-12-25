using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]

public class ClickPopupGUICS : MonoBehaviour {
	public bool playSound;
	public AudioClip soundToPlay;
	private AudioSource theAudio;
	public string GUITitle = "Title here";
	public int height = 100;
	public int width = 100;
	public int positionX = 100;
	public int positionY = 100;
	
	public string textToShow = "Text to show here" ;
	public Texture2D imageToShow;
	public bool destroyMeAfterwards;
	private bool inRange;
	private bool manualClose = false;
	private int textLength;
	private int textOffsetHeight = 0;
	
	// Use this for initialization
	void Start () {
		theAudio = GetComponent("AudioSource") as AudioSource;
		theAudio.Stop();
		theAudio.playOnAwake = false;
		theAudio.clip = soundToPlay;
	}
	
	void OnMouseUpEvent(){
		manualClose = false;
		if (playSound == true){
			theAudio.Play();
		}
		inRange=true;
	}
	
	void OnGUI(){
		if(manualClose == false){
			if(inRange == true){
				if(textToShow.Length > (width/10)){
					textOffsetHeight = (Mathf.RoundToInt(textToShow.Length / (width/10))) * 10;
				}
				
				GUI.Box (new Rect (positionX,positionY,width,height + 10 + textOffsetHeight), GUITitle);
				GUI.Label(new Rect (positionX + 10,positionY + 20, width - 10 ,height - 50), imageToShow);
				GUI.Label(new Rect (positionX + 10,positionY + 20 + (height - 50), width - 10 ,height - 50 + textOffsetHeight), textToShow);
				
				
				if (GUI.Button (new Rect (positionX + 10,positionY +(height - 15)+ textOffsetHeight,80,20), "Okay")) {
					manualClose = true;
					if (destroyMeAfterwards == true){
						DestroyMe();
					}
				}
			}
		}
	
	}
	
	void DestroyMe(){
		Destroy(gameObject);
	}

}
