#pragma strict

var pathPoints : Transform[];
var pathSpeeds : float[];

private var nextWaypoint : Transform;
private var nextWPind : int;
private var currSpeed : float;
private var currSind : int;

var t : float;

function Start () {
	currSind = 0;
	currSpeed = pathSpeeds[0];
	nextWPind = 1;
	nextWaypoint = pathPoints[1];
}

function Update () {	
	// Curved follow over 20 seconds w/ constant speed over each distance
/*	transform.position = Spline.InterpConstantSpeed( pathPoints, t, EasingType.Sine, true, true );
	t += Time.deltaTime/20;*/
	
	if( Vector3.Distance( nextWaypoint.transform.position, transform.position ) < 0.1 )
	{
		nextWPind++;
		if( nextWPind < pathPoints.Length )
		{
			nextWaypoint = pathPoints[nextWPind];
			currSind++;
			currSpeed = pathSpeeds[currSind] * 1.0;
		}
	}
	
	transform.position = Spline.MoveOnPath( pathPoints, transform.position, t, currSpeed, 100, EasingType.Cubic, true, true );
}