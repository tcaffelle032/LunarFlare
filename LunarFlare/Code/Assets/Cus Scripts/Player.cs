using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public int playerSpeed;
	bool cameraFov;
	int cameraDirection;
	// Use this for initialization
	void Start () {

		EventManger.OnKeyPress += playerMovement; //Subscribe to the event
		EventManger.OnPlayerInteraction += playerInteract;

		cameraFov = false;
		cameraDirection = 0;
	}

	void OnDisable(){
		EventManger.OnKeyPress -= playerMovement; //Unsubscribe, very important
		EventManger.OnPlayerInteraction -= playerInteract;
	}

	// Update is called once per frame
	void Update () {
		GameObject player = GameObject.Find("Player");		 

		 if(!Input.anyKey) {

			playerStopped(false);
		}
		player.transform.rotation=Quaternion.identity;	//makes sure the player stays upright

		Camera camera = Camera.FindObjectOfType<Camera>();// keeps camera focused on player
		camera.transform.LookAt(player.transform.position);

		cameraFOV(camera,cameraFov,cameraDirection);

	}

	void playerInteract(string npcName){
			Debug.Log(npcName);
	}

	void playerMovement(){
		//find both the camera and the player in the scene to be manipulated
		var player = GameObject.Find("Player");
		var camera = GameObject.Find("Main Camera");
		//Animator for animation
		Animator animate = this.GetComponent<Animator>();

		//for each of the movement functions we increase the players velocity
		//not the direct postion. That way it can be handeled by the physics 
		//engine.
		if(Input.GetKeyDown(KeyCode.W)){
			player.rigidbody.velocity = player.transform.forward * playerSpeed;		
			animate.SetBool("Walk_Up",true);
			cameraFov = true;
			cameraDirection = 2;


		}

		else if(Input.GetKeyDown(KeyCode.S)){
			player.rigidbody.velocity = -player.transform.forward * playerSpeed;
			animate.SetBool("Walk_Down",true);
			cameraFov = true;
			cameraDirection = 1;

		}
		else if(Input.GetKeyDown(KeyCode.D)){
			player.rigidbody.velocity = player.transform.right * playerSpeed;	
			animate.SetBool("Walk_Right",true);
			camera.rigidbody.velocity = camera.transform.right * playerSpeed/2;
		}
		else if(Input.GetKeyDown(KeyCode.A)){
			player.rigidbody.velocity = -player.transform.right * playerSpeed;
			player.transform.rotation = new Quaternion(0,-1,0,0);
			animate.SetBool("Walk_Left",true);
			camera.rigidbody.velocity = -camera.transform.right * playerSpeed/2;
		}
	}
	//Idle function to make sure everything stays in place and the correct animation is called
	//Extra steps are taken to make sure the player is truly idle
	void playerStopped(bool isIdle){
		Animator animate = this.GetComponent<Animator>();
		var player = GameObject.Find("Player");
		var camera = GameObject.Find("Main Camera");

		animate.SetBool("Walk_Down",false);
		animate.SetBool("Walk_Right",false);
		animate.SetBool("Walk_Left",false);
		animate.SetBool("Walk_Up",false);

		player.rigidbody.velocity = new Vector3(0,Physics.gravity.y,0);
		camera.rigidbody.velocity = camera.transform.right *0;
		cameraFov = false;
	}

	void cameraFOV(Camera camera,bool moving,int direction){
		if(moving && direction ==1 && camera.camera.fieldOfView <= 35)
		{
			camera.camera.fieldOfView += .25f;
		}
		else if (moving && direction ==2 && camera.camera.fieldOfView >= 21)
		{
			camera.camera.fieldOfView-= .25f;
		}

	}
}
