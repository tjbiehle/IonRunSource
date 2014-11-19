#pragma strict
var nextLevel:String;
var left:int= 780;
var top:int = 440;
var skipable:boolean = true;

function start() {
yield WaitForSeconds(15);
Application.LoadLevel(nextLevel);
}
function OnGUI () {
if(skipable){
if (GUI.Button (Rect(left,top,80,20), "Skip")){
	Application.LoadLevel(nextLevel);
}
}
}