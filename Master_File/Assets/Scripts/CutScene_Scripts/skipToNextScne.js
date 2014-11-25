#pragma strict
var nextLevel:String;
var left:float = 0.8f;
var top:float = 0.8f;
var width:int = 80;
var height:int = 20;
var skipable:boolean = true;
var buttonName:String = "Next";

function start() {
yield WaitForSeconds(15);
Application.LoadLevel(nextLevel);
}
function OnGUI () {
if(skipable){
if (GUI.Button (Rect(Screen.width*left,Screen.height*top,width,height), buttonName)){
	Application.LoadLevel(nextLevel);
}
}
}