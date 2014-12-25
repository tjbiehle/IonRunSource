#pragma strict


class Array3D
{
	var pathsplit : Array2D[];
	var total_current : float;
	var tempvoltage : float;
	var tot_resist : float;
	var mtest : float;
}
class Array2D {
	var subArray : Transform[];
	var current_ratio : float;
	var pathresist : float;
	var diodecount : float;
	} 
var trial : Transform;
var tempspeed : float;
var PathID : float;		
var myarray: Array2D[];	
	//Put components in spots
var testarray: Array3D;
//var testarray : Transform[];

private var pathPoints : Transform[];
//var pathSpeeds : float[];

var PlayButton : Transform;
var ComponentList : Transform[];
var Transport : Transform;

private var nextWaypoint : Transform;
var nextWPind : int;
private var currSpeed : float;
private var currSind : int;
private var myspeed : float;
var voltage : float;
var current : float;
//private var branchcount : int;
var nextpointcheck = true;
var indiode = false;
var t : float;
var startpos : Vector3;
var rotoffset : Vector3;
private var pathsel = false;
private var awesomeness;
private var direction : Vector3;
//var counter : GUIText;

var isWin;
var winGUI : GameObject;
var loseGUI : GameObject;
var lessResGUI : GameObject;
var moreResGUI : GameObject;
var hSliderValue : float = 1.0f;




function Start () 
{
	isWin = true;
	nextpointcheck = true;
	pathPoints = myarray[0].subArray;
	myspeed = 5;
	currSind = 5;
//	currSpeed = pathSpeeds[0];
	nextWPind = 1;
	nextWaypoint = pathPoints[1];
	current = 1;
//	voltage = 50;
	startpos = transform.position;
	PathID = 0;
	awesomeness = Quaternion.identity;
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
	testarray.tempvoltage = myspeed-1;	
if( !PlayButton.gameObject.activeSelf)
{		
	if(!pathsel)
{	
	
	//myspeed = voltage + 1; 
	
	pathsel = true;
		/*******************************NEW TEST CODE SECTION, PLACE IN GIANT IF STATEMENT LATER IF NO CHANGES DURING RUN **************************************/
	var i : float;
	var j : float;
//	var tempvoltage : float;	
	var branches : float;
	branches = testarray.pathsplit.Length;
	var totresist : float;
	var curr_resist : float;
	

	curr_resist = 0;

	i = 0;
	j = 0;	
	testarray.mtest = testarray.pathsplit.Length;
			//HOPEFULLY CALCULATE FOR EACH PATH
	for(;;)
	{
		if( i >= testarray.pathsplit.Length)
			break;
		testarray.pathsplit[i].pathresist = 0;	
		testarray.pathsplit[i].diodecount = 0;
		j = 0;
		for(;;)
		{
			curr_resist = 0;
			if( j >= testarray.pathsplit[i].subArray.Length)
				break;	
				//FIND OUT RESISTANCE
			if(testarray.pathsplit[i].subArray[j].tag == "Resistor")
			{
				curr_resist =  parseInt(testarray.pathsplit[i].subArray[j].name);
				
			}
			if(testarray.pathsplit[i].subArray[j].tag == "DStop")
			{
				if(testarray.pathsplit[i].subArray[j-1].tag == "DStart")
				{
					testarray.pathsplit[i].diodecount++;

				}
				else	
				{

					testarray.pathsplit[i].pathresist = -1;
					break;
					
				}
			}
			if(testarray.pathsplit[i].subArray[j].tag == "SwitchOff")
			{
				testarray.pathsplit[i].pathresist = -1;

				break;
			
			}	
		
			testarray.pathsplit[i].pathresist += curr_resist;
				
			j++;	
		}
		i++;
	}
			/********************************PARALLEL WORK *******************************************/
	if(testarray.pathsplit.Length > 1)
	{	
	curr_resist = 0;	
	
		//FIND CURRENT RATIO
	if(testarray.pathsplit.Length > 1)	
	{
		i = 1;	
		totresist = 0;
		
		for(;;)
		{
			if(i >= testarray.pathsplit.Length)
				break;
			if(testarray.pathsplit[i].pathresist >= 0)	
				totresist += testarray.pathsplit[i].pathresist;	
			i++;	
			curr_resist = 1/totresist;	
		}
		
		
	}
	else
	{
		totresist = testarray.pathsplit[i].pathresist;
	}
	i = 1;	
	
		//FINDING EQUIVALENT RESISTENCE
	for(;;)
	{
		if(i >= testarray.pathsplit.Length)
			break;
		if(testarray.pathsplit[i].pathresist >0)
			curr_resist = curr_resist * testarray.pathsplit[i].pathresist;	
		i++;	
	}
	if(testarray.pathsplit.Length > 1)	
	{
		i = 1;
				//FOUND EQUIVALENT RESISTENCE, GETTING CURRENT OF PATH
		for(;;)
		{
			if(i >= testarray.pathsplit.Length)
				break;
			if(testarray.pathsplit[i].pathresist == 0)
			{
				testarray.pathsplit[i].current_ratio = 1;
				
			}
			else if(testarray.pathsplit[i].pathresist == -1)
			{
				testarray.pathsplit[i].current_ratio = 0;
				
			}
			else	
				testarray.pathsplit[i].current_ratio = curr_resist / testarray.pathsplit[i].pathresist;	
				
			i++;			
		}
	}
	PathID = -1;
	
			//PICK PATH HERE
	if(testarray.pathsplit.Length > 1)
	{
		i = 1;
		for(;;)
		{
			if( i >= testarray.pathsplit.Length )
				break;
			if(testarray.pathsplit[i].current_ratio == 1)
				PathID = i;
			i++;		
		}
		i = 1;
		
	}
			/************************************ IF THERE IS NO PERFECT PATH ************************************/
			/*
	if(testarray.pathsplit.Length > 1)
	{	
		if(PathID == -1)
		{
			var b = parseInt(trial.name);
			if( b < 7)
				PathID = 1;
			else	
				PathID = 2;
			b++;
			if(b == 10)
				b = 0;
			trial.name = b.ToString();	
		}
		
		pathPoints = myarray[PathID-1].subArray;
		
	}		
	*/
	}
		/**************************************************************END PARALLEL WORK **********************************/
			//FIND CURRENT OF PATH HERE	
	if(	testarray.pathsplit[0].pathresist >= 0)
	{
		testarray.tot_resist = curr_resist + testarray.pathsplit[0].pathresist;	
		if(testarray.pathsplit.Length > 1)
			testarray.tempvoltage = voltage - testarray.pathsplit[0].diodecount*.7 - testarray.pathsplit[PathID].diodecount*.7; 
		else
			testarray.tempvoltage = voltage - testarray.pathsplit[0].diodecount*.7;	
		current = testarray.tempvoltage / testarray.tot_resist ;
	}
	else 
	{
		testarray.tot_resist = 0;
		current = 0;	
		testarray.tempvoltage = voltage - testarray.pathsplit[0].diodecount*.7 - testarray.pathsplit[PathID].diodecount*.7; 
	
	}
	testarray.total_current = current;		
}	
}				
		/************************************ END TEST CODE SECTION ****************************************/
		
	if(Transport.gameObject.activeSelf)
		Transport.gameObject.transform.position = transform.position;	
	if(nextpointcheck)
	{
		nextpointcheck = false;
		if(pathPoints[nextWPind-1].tag == "Resistor")
		{
			//pathPoints[nextWPind-1].tag = "Meter";		Useful for click codes to alternate between diode/switch start and stop, Either that or somehow have 2 waypoints and check tag for diode / switch
			//Maybe turn pathpoint name into its resistor value, then travel through all resistors evaluating?
			//myspeed -= parseInt(pathPoints[nextWPind-1].name)*current;
			//myspeed -= 100;
			myspeed = myspeed / 2;
		//	voltage -= parseInt(pathPoints[nextWPind-1].name)*current;
//			pathSpeeds[2] = 1000;
		}
		if(pathPoints[nextWPind-1].tag == "50Ohms")
		{
			//pathPoints[nextWPind-1].tag = "Meter";		Useful for click codes to alternate between diode/switch start and stop, Either that or somehow have 2 waypoints and check tag for diode / switch
			//Maybe turn pathpoint name into its resistor value, then travel through all resistors evaluating?
			//myspeed -= 50;
			myspeed = myspeed / 2;
//			pathSpeeds[2] = 1000;
		}
		if(pathPoints[nextWPind-1].tag == "100Ohms")
		{
			//pathPoints[nextWPind-1].tag = "Meter";		Useful for click codes to alternate between diode/switch start and stop, Either that or somehow have 2 waypoints and check tag for diode / switch
			//Maybe turn pathpoint name into its resistor value, then travel through all resistors evaluating?
			//myspeed -= 100;
			myspeed = myspeed / 4;
//			pathSpeeds[2] = 1000;
		}
		if(pathPoints[nextWPind-1].tag == "Split")
		{
			current = current * testarray.pathsplit[PathID].current_ratio;
		}
		if(pathPoints[nextWPind-1].tag == "UnSplit")
		{
			current = testarray.total_current;
		}
	
		if(pathPoints[nextWPind-1].tag == "Transport")
		{
			//pathPoints[nextWPind-1].tag = "Meter";		Useful for click codes to alternate between diode/switch start and stop, Either that or somehow have 2 waypoints and check tag for diode / switch
			//Maybe turn pathpoint name into its resistor value, then travel through all resistors evaluating?
			tempspeed = myspeed;
			Transport.gameObject.SetActive(true);
			myspeed = 10;
//			pathSpeeds[2] = 1000;
		}
		if(pathPoints[nextWPind-1].tag == "EndTransport")
		{
			//pathPoints[nextWPind-1].tag = "Meter";		Useful for click codes to alternate between diode/switch start and stop, Either that or somehow have 2 waypoints and check tag for diode / switch
			//Maybe turn pathpoint name into its resistor value, then travel through all resistors evaluating?
			myspeed = 1;
			Transport.gameObject.SetActive(false);

//			pathSpeeds[2] = 1000;
		}
		if(pathPoints[nextWPind-1].tag == "200Ohms")
		{
			//pathPoints[nextWPind-1].tag = "Meter";		Useful for click codes to alternate between diode/switch start and stop, Either that or somehow have 2 waypoints and check tag for diode / switch
			//Maybe turn pathpoint name into its resistor value, then travel through all resistors evaluating?
			//myspeed -= 200;
			myspeed = myspeed / 8;
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
	//		voltage -= .7;
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
		else if(pathPoints[nextWPind-1].tag == "Ampmeter")
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
                // if (myspeed > 0 && myspeed < 10000)
            //if (myspeed == 300)
          
          // temporary testing
		if (myspeed > 0) {
                ///winGUI.SetActive(true);
                isWin = true;
                winGUI.SetActive(true);
            }
            /*else if (myspeed > 300 && myspeed < 500)
            {
            	moreResGUI.SetActive(true);
            }
            else if (myspeed < 300 && myspeed > 0)
            {
            	lessResGUI.SetActive(true);
            }*/
            
            
            //else
            //{
            //    isWin = false;      // probably redundent
                //loseGUI.SetActive(true);
           // }

        }
				//THEY DID NOT PICK COMPONENT
		else if(pathPoints[nextWPind-1].tag == "Component")
		{
			Destroy( gameObject);

		}
		else if(pathPoints[nextWPind-1].tag == "Clone")
		{

	//		pathPoints = myarray[0].subArray;
	//		var temp = nextWPind;
			
	//		nextWPind = 2;
	//		nextWaypoint = pathPoints[nextWPind];
	//		direction = nextWaypoint.transform.position - transform.position;
			
			//Instantiate (gameObject, startpos, awesomeness);
			Instantiate (gameObject, startpos, Quaternion.identity);
			
	//		nextWPind = temp;
			/*if(counter.text == "a")
			{
				pathPoints = myarray[1].subArray;
				counter.text = "b";
			}
			else
			{
				pathPoints = myarray[0].subArray;
				counter.text = "a";
			}*/
			nextWaypoint = pathPoints[nextWPind];

	//		direction = nextWaypoint.transform.position - transform.position;
			
		}
		
		
	}
	
	
	
	if( PlayButton.gameObject.activeSelf == false)
	{
		if( Vector3.Distance( nextWaypoint.transform.position, transform.position ) < .2 )
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
		direction = nextWaypoint.transform.position - transform.position;
		transform.position = Spline.MoveOnPath( pathPoints, transform.position, t, myspeed, 100, EasingType.Linear, true, true );
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