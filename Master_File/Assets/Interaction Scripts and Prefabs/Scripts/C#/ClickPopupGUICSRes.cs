using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]

public class ClickPopupGUICSRes : MonoBehaviour {
	public bool playSound;
	public AudioClip soundToPlay;
	private AudioSource theAudio;
	public string GUITitle = "";
	public int height = 100;
	public int width = 100;
	public int positionX = 100;
	public int positionY = 100;

	public float lowRes;
	public float medRes;
	public float hiRes;
	public float sliderVal;
	
	public string textToShow = "Select a resistance" ;
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
		sliderVal = medRes;
	}
	
	void OnMouseUpEvent(){
		manualClose = false;
		if (playSound == true){
			theAudio.Play();
		}
		inRange=true;
	}

	float roundSlider(float s)
	{
		if (s < lowRes + ((medRes - lowRes) / 2))
			return lowRes;
		else if (s > medRes + ((hiRes - medRes) / 2))
			return hiRes;
		else
			return medRes;
	}

	void OnGUI(){
		if(manualClose == false){
			if(inRange == true){
				if(textToShow.Length > (width/10)){
					textOffsetHeight = (Mathf.RoundToInt(textToShow.Length / (width/10))) * 10;
				}
				
				GUI.Box (new Rect (positionX,positionY,width,height + 10 + textOffsetHeight), GUITitle);
	//			GUI.Label(new Rect (positionX + 10,positionY + 20, width - 10 ,height - 50), imageToShow);
				GUI.Label(new Rect (positionX + 10,positionY + 20 + (height - 25), width - 10 ,height - 50 + textOffsetHeight), textToShow);
				
				//sliderVal = roundSlider(GUI.HorizontalSlider(new Rect(positionX+(width*0.1f), positionY+(height*0.1f), width*0.8f, height*0.1f), sliderVal, lowRes, hiRes));			
				if (GUI.Button (new Rect (positionX + 10,positionY +(height - 100)+ textOffsetHeight,80,20), "50 Ohms")) {
					manualClose = true;
					var point = GameObject.Find("five");
					point.tag = "50Ohms";
					if (destroyMeAfterwards == true){
						DestroyMe();
					}
				}
				else if (GUI.Button (new Rect (positionX + 10,positionY +(height - 75)+ textOffsetHeight,80,20), "100 Ohms")) {
					manualClose = true;
					var point = GameObject.Find("five");
					point.tag = "100Ohms";
					if (destroyMeAfterwards == true){
						DestroyMe();
					}
				}
				else if (GUI.Button (new Rect (positionX + 10,positionY +(height - 50)+ textOffsetHeight,80,20), "200 Ohms")) {
					manualClose = true;
					var point = GameObject.Find("five");
					point.tag = "200Ohms";
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
