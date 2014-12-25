using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(BoxCollider))]

public class ProximityPopupGUICS : MonoBehaviour {
	
	public bool playSound;
	public AudioClip soundToPlay;
	private AudioSource theAudio;
	public string GUITitle= "Title here";
	public int height = 100;
	public int width = 100;
	public int positionX= 100;
	public int positionY= 100;
	
	public string textToShow= "Text to show here" ;
	public Texture2D imageToShow;
	public bool destroyMeAfterwards;
	private bool inRange;
	private bool manualClose = false;
	private int textLength;
	private int textOffsetHeight = 0;
	
	void Start(){
		(GetComponent("BoxCollider") as BoxCollider).isTrigger = true;
		theAudio = (GetComponent("AudioSource") as AudioSource);
		theAudio.playOnAwake = false;
		theAudio.clip = soundToPlay;
	}
	
	void OnTriggerEnter(){
		if (playSound == true){
			theAudio.Play();
		}
	}
	
	
	
	IEnumerator OnTriggerStay(){
		inRange = true;
		if (destroyMeAfterwards == true){
			yield return new WaitForSeconds (2);
			Destroy(gameObject);
		}
	}
	
	void OnTriggerExit(){
		inRange = false;
		manualClose = false;
		(GetComponent("BoxCollider") as BoxCollider).isTrigger = true;
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
