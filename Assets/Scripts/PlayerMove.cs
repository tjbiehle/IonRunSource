using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {
	public float speed;
	public GameObject Level;
	public GameObject LoseScreen;
	public GameObject Play;
	public GameObject P1;
	public GUIText Losing;
	public GUIText HP;
	public GUIText Button;
	private int health;
	public float voltage;
	public GUIText PlayerInfo;
	bool started = false;
	
	public GameObject Spot1;
	public GameObject Spot2;
	public GameObject Spot3;
//	public GameObject Spot4;
	
	

	double current;
	double R1, R2, R3, R4;
	bool incomponent = false;
	
	Vector3 movement = new Vector3 (0, 0, 100);
	Vector3 translate = new Vector3(0,0,0);
	
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
		/*
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
		}*/
	}
	
	void Start()
	{
		HP.text = voltage.ToString ();
		Losing.text = "YOU \n LOST!!!!";
		health = 500;
	//	voltage = 100;
		Button.text = "BLAHAH";
		PlayerInfo.pixelOffset = new Vector2 (gameObject.transform.position.x, gameObject.transform.position.z ) *10;
		PlayerInfo.text = "";
		//	float forward = 10;
		
	}
	void OnTriggerEnter(Collider other)
	{
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
		
		
		
				if (other.gameObject.tag == "STOP") {
						movement = new Vector3 (-100, 0, 0);
						rigidbody.AddForce (movement * speed * Time.deltaTime);
				}
				if (other.gameObject.tag == "S_E") {

						movement = new Vector3 (-100, 0, -100);
						rigidbody.AddForce (movement * speed * Time.deltaTime);
						other.gameObject.SetActive (false);
						if (gameObject.tag == "Later") {
								gameObject.SetActive (false);
						}
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
		
				if (other.gameObject.tag == "Mob") {
						LoseScreen.gameObject.SetActive (true);
						Level.gameObject.SetActive (false);
			
				}
		
				if (other.gameObject.tag == "DStop") {
			
						if (!incomponent) {
								gameObject.SetActive (false);
						} else
								incomponent = !incomponent;
			
				}
				if (other.gameObject.tag == "DStart") {
						incomponent = !incomponent;
				}
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
				if (other.gameObject.tag == "END") {
			/*			if (voltage < 35) {
								LoseScreen.gameObject.SetActive (true);
								Level.gameObject.SetActive (false);
						} else {
								Losing.text = "YOU WIN!!!!";
								LoseScreen.gameObject.SetActive (true);
								Level.gameObject.SetActive (false);
				
						}*/
			Losing.text = "YOU WIN!!!!";
			LoseScreen.gameObject.SetActive (true);
			Level.gameObject.SetActive (false);
				}	
				if (other.gameObject.tag == "Resist") {
						//	other.gameObject.name = "100";
						voltage -= (float)current * stringtoint (other.gameObject.name);
						HP.text = voltage.ToString ();
				}
				if (other.gameObject.tag == "Branch1") 
				{
						current =  current * R3 / (R3 + R2);
				}
				if (other.gameObject.tag == "Branch2") 
				{
						current =  current * R2 / (R3 + R2);
				}
				if (other.gameObject.tag == "Test1") 
				{
					if(current < .8 || current > 1.2)
					{
						LoseScreen.gameObject.SetActive (true);
						Level.gameObject.SetActive (false);
					}
				}
				if (other.gameObject.tag == "Test2") 
				{
					if(current < .7 || current > 1)
					{
						LoseScreen.gameObject.SetActive (true);
						Level.gameObject.SetActive (false);
					}
				}
				if (other.gameObject.tag == "Test3") 
				{
					if(current < .2 || current > .5)
					{
						LoseScreen.gameObject.SetActive (true);
						Level.gameObject.SetActive (false);
					}
				}

			
		if (other.gameObject.tag == "Split") {
	//		Instantiate (gameObject );

			Vector3 offset = new Vector3 (0,0,5);
			Vector3 rotate = new Vector3(0,0,0);
		//	Instantiate (P1);

			//clone = Instantiate(P1 , transform.position + offset,  transform.rotation) as Rigidbody;
			movement = new Vector3 (100, 0, 100);

	//		clone.rigidbody.AddForce (movement * speed * Time.deltaTime); 
	//		clone.velocity = transform.TransformDirection(Vector3.back * 10);
			movement = new Vector3 (-100, 0, -100);
			rigidbody.AddForce (movement * speed * Time.deltaTime);
			other.gameObject.SetActive (false);
			if (gameObject.tag == "Later") {
				gameObject.SetActive (false);
			}
		}
		
		
		
	}
	//Unique to each circuit
	void evalcurrent()
	{
	//	voltage = 5000;
	
		R1 = stringtoint (Spot1.gameObject.name);
		R2 = stringtoint (Spot2.gameObject.name);
		R3 = stringtoint (Spot3.gameObject.name);
	//	R4 = stringtoint (Spot4.gameObject.name);

		current = voltage / ( R1 + (R2*R3)/(R2 + R3) );
		Button.text = current.ToString ();
	}
	
	void FixedUpdate()
	{
		if(Play.gameObject.activeSelf == false)
		{
			if(!started)
			{
				evalcurrent ();
				PlayerInfo.text = "Voltage: " + voltage + "\n Current: " + current;
				started = true;
				movement = new Vector3 (00, 0, -100);
				rigidbody.AddForce (movement * speed * Time.deltaTime);
			}
			PlayerInfo.text = "Voltage: " + voltage + "\n Current: " + current;
			PlayerInfo.pixelOffset = new Vector2 (gameObject.transform.position.x, gameObject.transform.position.z ) *10;
		}
		
		
		if (health <= 0)
		{
			LoseScreen.gameObject.SetActive (true);
			Level.gameObject.SetActive (false);
		}
		/*
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0, moveVertical);

		rigidbody.AddForce (movement * speed * Time.deltaTime);
		*/
	}
	int stringtoint(string a)
	{
		int value;
		value = int.Parse (a);
		return value;
	}
}