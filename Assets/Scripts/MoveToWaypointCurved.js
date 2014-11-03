#pragma strict



class Array2D {
	var subArray : Transform[];
	} 
var myarray: Array2D[];	

//var testarray : Transform[];

private var pathPoints : Transform[];
//var pathSpeeds : float[];

var PlayButton : Transform;
var ComponentList : Transform[];


private var nextWaypoint : Transform;
var nextWPind : int;
private var currSpeed : float;
private var currSind : int;
private var myspeed : float;
var voltage : float;
var current : int;
//private var branchcount : int;
var nextpointcheck = true;
var indiode = false;
var t : float;
var startpos : Vector3;
var rotoffset : Vector3;
var counter : GUIText;



function Start () 
{
	nextpointcheck = true;
	pathPoints = myarray[0].subArray;
	myspeed = 10;
	currSind = 0;
//	currSpeed = pathSpeeds[0];
	nextWPind = 1;
	nextWaypoint = pathPoints[1];
	current = 1;
	voltage = 10;
	startpos = transform.position;
	
//	branchcount = 0;
}

	/*When object collides with object, stuff DOESNT happens*/
	/*
function OnTriggerEnter( other : Collider )
{
	if(other.tag == "Meter")
		other.gameObject.SetActive(false);
}*/



function Update () {	
	// Curved follow over 20 seconds w/ constant speed over each distance
/*	transform.position = Spline.InterpConstantSpeed( pathPoints, t, EasingType.Sine, true, true );
	t += Time.deltaTime/20;*/
		/* Use this Section to check for Meters resistors switches etc */
		//nextWPind = Mathf.RoundToInt( pathPoints[nextWPind-1].transform.rotation.x);
		
	if(nextpointcheck)
	{
		nextpointcheck = false;
		if(pathPoints[nextWPind-1].tag == "Resistor")
		{
			//pathPoints[nextWPind-1].tag = "Meter";		Useful for click codes to alternate between diode/switch start and stop, Either that or somehow have 2 waypoints and check tag for diode / switch
			//Maybe turn pathpoint name into its resistor value, then travel through all resistors evaluating?
			myspeed -= 4;
//			pathSpeeds[2] = 1000;
		}
		else if(pathPoints[nextWPind-1].tag == "END")
		{
			Destroy (gameObject);
		}
		else if(pathPoints[nextWPind-1].tag	 == "Meter")
		{
			//Display Meter in appropriate spot
		}
		else if(pathPoints[nextWPind-1].tag == "DStart")
		{
			indiode = true;
			myspeed -= .7;
			voltage -= .7;
			//Read next point and move on?
		}
		else if(pathPoints[nextWPind-1].tag == "DStop")
		{
			if(indiode)
				indiode = false;
			else
				Destroy (gameObject);	
		}
		else if(pathPoints[nextWPind-1].tag == "SwitchOn")
		{
				
		}
		else if(pathPoints[nextWPind-1].tag == "SwitchOff")
		{
			Destroy (gameObject);
		}
		else if(pathPoints[nextWPind-1].tag == "Branch")
		{
		/*
			//ALSO HAVE TO CHANGE CURRENT, NEED A GLOBAL TO KEEP TRACK OF WHICH ONES SHIFT
			var temp = new Transform[pathPoints.Length - 3];
			for(var i = 0; i < pathPoints.Length - 3; i++)
			{
				temp[i] = pathPoints[i];
			}
			pathPoints = temp;
			*/

		}
		else if(pathPoints[nextWPind-1].tag == "Clone")
		{
		
			Instantiate (gameObject, startpos, Quaternion.identity);
			
			if(counter.text == "a")
			{
				pathPoints = myarray[1].subArray;
				counter.text = "b";
			}
			else
			{
				pathPoints = myarray[0].subArray;
				counter.text = "a";
			}
			nextWaypoint = pathPoints[nextWPind];
			
			
			
		}
		
		
	}
	
	
	
	if( PlayButton.gameObject.activeSelf == false)
	{
		if( Vector3.Distance( nextWaypoint.transform.position, transform.position ) < 0.4 )
		{
			
		//	nextWPind = Mathf.RoundToInt(pathPoints[nextWPind].transform.rotation.x) ;
			nextWPind = nextWPind + 1;
			
			if( nextWPind < pathPoints.Length )
			{
				nextpointcheck = true;
				nextWaypoint = pathPoints[nextWPind];
				/*
				currSind++;
				currSpeed = pathSpeeds[currSind] * 1.0;
				*/
			}
			
				
		}
		var direction : Vector3 = nextWaypoint.transform.position - transform.position;
		transform.position = Spline.MoveOnPath( pathPoints, transform.position, t, myspeed, 100, EasingType.Cubic, true, true );
		transform.rotation = Quaternion.Slerp( transform.rotation, Quaternion.LookRotation( direction ), 4 * Time.deltaTime );
	}	
}


/*function Update ()
{
	MoveTowardWaypoint();
	
	if( Vector3.Distance( currentWaypoint.transform.position, transform.position ) < minDistance )
	{
		currentIndex++;
		if( currentIndex > waypoints.Length - 1 )
			currentIndex = 0;
		currentWaypoint = waypoints[currentIndex];
	}
}

function MoveTowardWaypoint() : void
{
	var direction : Vector3 = currentWaypoint.transform.position - transform.position;
	var moveVector : Vector3 = direction.normalized * moveSpeed * Time.deltaTime;
	transform.position += moveVector;
	transform.rotation = Quaternion.Slerp( transform.rotation, Quaternion.LookRotation( direction ), 4 * Time.deltaTime );
}*/