#pragma strict




function Start () 
{ 
var pointB : Vector3;

var pointA = transform.position; 
pointB.x = pointA.x+0.015;
pointB.y = pointA.y+0.01;
pointB.z = pointA.z;

while (true) { 
	yield MoveObject(transform, pointA, pointB, 0.5); 
	yield MoveObject(transform, pointB, pointA, 0.5); 
} 
}

function MoveObject (thisTransform : Transform, startPos : Vector3, endPos : Vector3, time : float) 
{
	 var i = 0.0; 
	 var rate = 1.0/time; 
	 while (i < 1.0) 
	 { 
		 i += Time.deltaTime * rate; 
		 thisTransform.position = Vector3.Lerp(startPos, endPos, i); 
		 yield; 
	 } 
 }
