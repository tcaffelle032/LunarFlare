using UnityEngine;
using System.Collections;

public  class InputManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	 void Update () {
		//The input event is called whenever a key is pressed
		//Because of this, any object that is subscribed to this event
		//will be called. Allows us to futher break things apart to help
		//with troubleshoothing later on.
		if(Input.anyKeyDown){
			EventManger.KeyPressed();
		}
	}

	 
}
