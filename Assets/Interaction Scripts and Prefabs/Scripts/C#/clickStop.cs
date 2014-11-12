using UnityEngine;
using System.Collections;

public class clickStop : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	void OnMouseDown () {
		
		/*
         * When this button is pressed, the level will be reset.
         * Before the reset, we need to copy the state of each resistor, switch, etc
         * so that we can ensure the level is still at the same state as before the Go button was pressed.
         * 
         * The purpose of this button is to stop the animation of the level so the player can continue
         * to make changes to win the level.
         */
		
		Application.LoadLevel( "Ion_Run_1" );       // Change this to appropriate scene name

		/*
         * Code here will bring the level back to the point as recorded before the level reset.
         */
	}
}
