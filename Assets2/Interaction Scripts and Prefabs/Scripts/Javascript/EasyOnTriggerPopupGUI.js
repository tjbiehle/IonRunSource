#pragma strict
@script RequireComponent(BoxCollider);
@script RequireComponent(AudioSource);
public var playSound:boolean;
public var soundToPlay:AudioClip;
private var theAudio:AudioSource ;
public var GUITitle:String = "Title here";
public var height:int = 100;
public var width:int = 100;
public var positionX:int = 100;
public var positionY:int = 100;

public var textToShow:String = "Text to show here" ;
public var imageToShow:Texture2D;
public var destroyMeAfterwards:boolean;
private var inRange:boolean;
private var manualClose:boolean = false;
private var textLength:int;
private var textOffsetHeight = 0.00;

function Start(){
	GetComponent(BoxCollider).isTrigger = true;
	theAudio = GetComponent(AudioSource);
	theAudio.playOnAwake = false;
	theAudio.clip = soundToPlay;
}

function OnTriggerEnter(){
	if (playSound == true){
		theAudio.Play();
	}
}



function OnTriggerStay(){
	inRange = true;
	
}

function OnTriggerExit(){
	inRange = false;
	manualClose = false;
	GetComponent(BoxCollider).isTrigger = true;
}

function OnGUI(){
	if(manualClose == false){
		if(inRange == true){
			if(textToShow.Length > (width/10)){
				textOffsetHeight = (Mathf.RoundToInt(textToShow.Length / (width/10))) * 10;
			}
			
			GUI.Box (Rect (positionX,positionY,width,height + 10 + textOffsetHeight), GUITitle);
			GUI.Label(Rect (positionX + 10,positionY + 20, width - 10 ,height - 50), imageToShow);
			GUI.Label(Rect (positionX + 10,positionY + 20 + (height - 50), width - 10 ,height - 50 + textOffsetHeight), textToShow);
			
			
			if (GUI.Button (Rect (positionX + 10,positionY +(height - 15)+ textOffsetHeight,80,20), "Okay")) {
				manualClose = true;
				if (destroyMeAfterwards == true){
					Destroy(gameObject);
				}
			}
		}
	}

}
