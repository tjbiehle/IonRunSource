using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {
	public float speed;
	public GameObject Level;
	public GameObject LoseScreen;
	public GameObject Play;
	public GameObject P1;

	public GUIText Island;

	public GUIText Losing;
	public GUIText HP;
	public GUIText Button;
//	private int health;
	public float voltage;
//	public GUIText PlayerInfo;
	bool started = false;
	
	public GameObject Spot1;
	public GameObject Spot2;
	public GameObject Spot3;
//	public GameObject Spot4;

	public GUIText AV1, AV2, AV3;
	

	double current;
	double R1, R2, R3, R4;
	bool incomponent = false;
	int ratio;
	public GUIText counter;
	Vector3 movement = new Vector3 (0, 0, 100);
	Vector3 translate = new Vector3(0,0,0);
	/*		Old Garbage Code, Probably Never Needed */
	/*	
	void updateHP(string ID)
	{
		int incr1 = 0;
		int incr2 = 0;
		if(ID == "R")
		{
			incr1 = -50;
			incr2 = 20;
		}
		if (ID == "L") 
		{
			incr1 = -30;
			incr2 = 10;
		}
		if(ID == "C")
		{
			incomponent = true;
			incr2 = -100;
		}
		if(ID == "R1")
		{
			incr1 = -30;
			incr2 = 0;
		}
		if(ID == "R2")
		{
			incr1 = -70;
			incr2 = 0;
		}

		if(!incomponent)
		{
			incomponent = true;
			voltage += incr1;
			HP.text = "H: " + voltage.ToString () +"mV";
		}
		else
		{
			incomponent = false;
			voltage += incr2;
			HP.text = "H: " + voltage.ToString () +"mV";
		}
	}
	*/

	void Start()
	{
		HP.text = voltage.ToString ();
		Losing.text = "YOU \n LOST!!!!";

		ratio = 10;

		Button.text = "PLAY";
		
	}

	void OnTriggerEnter(Collider other)
	{
		/* Old Garbage Code */
		/*
				if (other.gameObject.tag == "RN_ETrig") {
						updateHP ("R");
			
						movement = new Vector3 (0, 0, 50);
						rigidbody.AddForce (movement * speed * Time.deltaTime);
				}
				if (other.gameObject.tag == "RN_WTrig") {
						updateHP ("R");
			
			
						movement = new Vector3 (50, 0, 0);
						rigidbody.AddForce (movement * speed * Time.deltaTime);
				}
				if (other.gameObject.tag == "RW_NTrig") {
						updateHP ("R");
			
			
						movement = new Vector3 (-50, 0, 0);
						rigidbody.AddForce (movement * speed * Time.deltaTime);
				}
				if (other.gameObject.tag == "RE_NTrig") {
						updateHP ("R");
			
			
						movement = new Vector3 (0, 0, -50);
						transform.position = transform.position + translate;
				}
		
				if (other.gameObject.tag == "CN_ETrig") {
						updateHP ("C");
			
						translate = new Vector3 (0, 0, 6);
						transform.position = transform.position + translate;
				}
				if (other.gameObject.tag == "CN_WTrig") {
						updateHP ("C");
			
						translate = new Vector3 (5, 0, 0);
						transform.position = transform.position + translate;
				}
				if (other.gameObject.tag == "CW_NTrig") {
			
						updateHP ("C");
			
						translate = new Vector3 (-5, 0, 0);
						transform.position = transform.position + translate;
				}
				if (other.gameObject.tag == "CE_NTrig") {
			
						updateHP ("C");
			
						translate = new Vector3 (0, 0, -6);
						transform.position = transform.position + translate;
				}
		
				if (other.gameObject.tag == "IN_ETrig") {
						updateHP ("L");
			
						movement = new Vector3 (0, 0, 50);
						rigidbody.AddForce (movement * speed * Time.deltaTime);
				}
				if (other.gameObject.tag == "IN_WTrig") {
						updateHP ("L");
			
						movement = new Vector3 (50, 0, 0);
						rigidbody.AddForce (movement * speed * Time.deltaTime);
				}
				if (other.gameObject.tag == "IW_NTrig") {
						updateHP ("L");
			
						movement = new Vector3 (-50, 0, 0);
						rigidbody.AddForce (movement * speed * Time.deltaTime);
				}
				if (other.gameObject.tag == "IE_NTrig") {
						updateHP ("L");
			
						movement = new Vector3 (0, 0, -50);
						rigidbody.AddForce (movement * speed * Time.deltaTime);
				}
		
		*/
						/*Hard Coded Path Triggers, Most Likely Will be Replaced by 10/20 */
		/*
				if (other.gameObject.tag == "STOP") {
						movement = new Vector3 (-100, 0, 0);
						rigidbody.AddForce (movement * speed * Time.deltaTime);
				}
				*/
				if (other.gameObject.tag == "S_E") {

						movement = new Vector3 (-100, 0, -100);
						rigidbody.AddForce (movement * speed * Time.deltaTime);
				}
				if (other.gameObject.tag == "E_N") {
						movement = new Vector3 (100, 0, -100);
						rigidbody.AddForce (movement * speed * Time.deltaTime);
				}
				if (other.gameObject.tag == "N_W") {
						movement = new Vector3 (100, 0, 100);
						rigidbody.AddForce (movement * speed * Time.deltaTime);
				}
				if (other.gameObject.tag == "W_S") {
						movement = new Vector3 (-100, 0, 100);
						rigidbody.AddForce (movement * speed * Time.deltaTime);
			
				}
		/*
				if (other.gameObject.tag == "Mob") {
						LoseScreen.gameObject.SetActive (true);
						Level.gameObject.SetActive (false);
			
				}
		*/
					/* Not used right now but may use for diodes later */
				if (other.gameObject.tag == "DStop") {
			
						if (!incomponent) {
								gameObject.SetActive (false);
						} else
								incomponent = !incomponent;
			
				}
				if (other.gameObject.tag == "DStart") {
						incomponent = !incomponent;
				}
		/*
				if (other.gameObject.tag == "Resistor1") {
						if (gameObject.tag == "Player")
								updateHP ("R1");
						incomponent = !incomponent;
				}
				if (other.gameObject.tag == "Resistor2") {
						if (gameObject.tag == "Player")
								updateHP ("R2");
						incomponent = !incomponent;
				}
				*/
							//Destroy balls that finish route to prevent overflow of gameobjects
				if (other.gameObject.tag == "END") 
				{
			Destroy (gameObject);

			/*			if (voltage < 35) {
								LoseScreen.gameObject.SetActive (true);
								Level.gameObject.SetActive (false);
						} else {
								Losing.text = "YOU WIN!!!!";
								LoseScreen.gameObject.SetActive (true);
								Level.gameObject.SetActive (false);
				
						}*/
			/*
			Losing.text = "YOU WIN!!!!";
			LoseScreen.gameObject.SetActive (true);
			Level.gameObject.SetActive (false);
			*/
				}	
						/* Reduce voltage when going through resistor */
				if (other.gameObject.tag == "Resist") 
				{
						
						voltage -= (float)current * stringtoint (other.gameObject.name);
					
				}	
							/*Slow down ball as traveling through resistor */
						/******************************************* Evaluate Lost Speed based on Resistor ***********************************/
				if(other.gameObject.tag == "ResistBox")
				{
					float xval = 0; 

					movement = new Vector3 (20, 0, 0);
					rigidbody.AddForce (movement * speed * Time.deltaTime);
				}
						/******************************************** HARD CODED, MUST ADAPT TO LEVEL *********************************************/
							/*Set current for "Player" based on which path of parallel was taken */
				if (other.gameObject.tag == "Branch1") 
				{
						current =  current * R3 / (R3 + R2);
				}
				if (other.gameObject.tag == "Branch2") 
				{
						current =  current * R2 / (R3 + R2);
				}

						/* If current is out of acceptable range when this trigger is reached, you lose game */
				if (other.gameObject.tag == "Test1") 
				{
					if(current <= .9 || current >= 1.2)
					{
						LoseScreen.gameObject.SetActive (true);
						Level.gameObject.SetActive (false);
					}
				}
				if (other.gameObject.tag == "Test2") 
				{
					if(current >= .8 || current <= .4)
					{
						LoseScreen.gameObject.SetActive (true);
						Level.gameObject.SetActive (false);
					}
				}
				if (other.gameObject.tag == "Test3") 
				{
					if(current <= .2 || current >= .6)
					{
						LoseScreen.gameObject.SetActive (true);
						Level.gameObject.SetActive (false);
					}
				}
						/************************************************* END OF HARD CODE SECTION, ALL MUST ADAPT TO LEVEL ************************************************/
				/* Display "Player" current and voltage on appropriate GUIText when this trigger is reached */
		if(other.gameObject.tag == "A/V1")
			{
			AV1.text = "Current: " + current +"\nVoltage: " + voltage;
			}
		if(other.gameObject.tag == "A/V2")
		{
			AV2.text = "Current: " + current +"\nVoltage: " + voltage;
		}
		if(other.gameObject.tag == "A/V3")
		{
			AV3.text = "Current: " + current +"\nVoltage: " + voltage;
		}

			/********************************************** Sort of Hard Coded May need to Adjust ************************************/
				/* Repeatedly Spawn "Players" when this trigger is reached */
		if (other.gameObject.tag == "Split") {
	//		Instantiate (gameObject );

			Vector3 offset = new Vector3 (0,0,5);
			Vector3 rotate = new Vector3(0,0,0);
		//	Instantiate (P1);
		
			Rigidbody clone;
			clone = Instantiate(gameObject , transform.position + offset, transform.rotation) as Rigidbody;
			clone.velocity = transform.TransformDirection(Vector3.forward * 10);
	//		movement = new Vector3 (-100, 0, -100);
	//		rigidbody.AddForce (movement * speed * Time.deltaTime);
			/*
			other.gameObject.SetActive (false);
			if (gameObject.tag == "Later") {
				gameObject.SetActive (false);
			}*/
		}
						/****************************************************** HARD CODED *********************************************/
		if( other.gameObject.tag == "S_EB")
		{
			int temp = ((stringtoint (counter.text)));
			temp++;
			counter.text = temp.ToString ();

			if(temp <= ratio)
			{
				movement = new Vector3 (-100, 0, -100);
				rigidbody.AddForce (movement * speed * Time.deltaTime);
			}
			if(temp >= 10)
			{
				counter.text = "0";
			}

		}
		
		
		
	}

					/********************************************************* HARD CODED *************************************************************/
	/* Unique to each circuit, evaluates current */
	void evalcurrent()
	{
			/* For Level 1, use this to get current */
		if(Island.text == "Island1")
		{
			R1 = stringtoint (Spot1.gameObject.name);
			R2 = stringtoint (Spot2.gameObject.name);
			R3 = stringtoint (Spot3.gameObject.name);


			current = voltage / ( R1 + (R2*R3)/(R2 + R3) );

		}
			/* For Level 2, do this for current */
		if(Island.text == "Island2")
		{

		}
	}
	
	void FixedUpdate()
	{
		if(Play.gameObject.activeSelf == false)
		{
			if(!started)
			{
				evalcurrent ();
		
				started = true;
						/* Always starts rolling one direction, will change with curve code */
				movement = new Vector3 (0, 0, -100);
				rigidbody.AddForce (movement * speed * Time.deltaTime);


		
			}
				/***************************************** HARD CODED *************************************************/
			ratio = (int)((R3/(R2+R3)) * 10);
				/*For having moving A/V meter with ball, does not work for clones so unneeded atm */
			/*
			PlayerInfo.text = "Voltage: " + voltage + "\n Current: " + current;
			PlayerInfo.pixelOffset = new Vector2 (gameObject.transform.position.x, gameObject.transform.position.z ) *10;
			*/

		}
		

	}
		/* Read from a string to an integer */
	int stringtoint(string a)
	{
		int value;
		value = int.Parse (a);
		return value;
	}
}