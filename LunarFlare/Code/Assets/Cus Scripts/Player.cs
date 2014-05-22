using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public int playerSpeed;
	// Use this for initialization
	void Start () {

		EventManger.OnKeyPress += playerMovement;
	}

	void OnDisable(){
		EventManger.OnKeyPress -= playerMovement;
	}

	// Update is called once per frame
	void Update () {
		GameObject player = GameObject.Find("Player");		 

		 if(!Input.anyKey) {

			playerStopped(false);
		}
		player.transform.rotation=Quaternion.identity;	
		Camera camera = Camera.FindObjectOfType<Camera>();
		camera.transform.LookAt(player.transform.position);

	}

	void playerMovement(){
		var player = GameObject.Find("Player");
		var camera = GameObject.Find("Main Camera");
		Animator animate = this.GetComponent<Animator>();

		if(Input.GetKeyDown(KeyCode.W)){
			player.rigidbody.velocity = player.transform.forward * playerSpeed;		
			animate.SetBool("Walk_Up",true);
		}

		else if(Input.GetKeyDown(KeyCode.S)){
			player.rigidbody.velocity = -player.transform.forward * playerSpeed;
			animate.SetBool("Walk_Down",true);
		}
		else if(Input.GetKeyDown(KeyCode.D)){
			player.rigidbody.velocity = player.transform.right * playerSpeed;	
			animate.SetBool("Walk_Right",true);


			camera.rigidbody.velocity = camera.transform.right * playerSpeed;

		}
		else if(Input.GetKeyDown(KeyCode.A)){
			player.rigidbody.velocity = -player.transform.right * playerSpeed;
			player.transform.rotation = new Quaternion(0,-1,0,0);
			animate.SetBool("Walk_Left",true);
			camera.rigidbody.velocity = -camera.transform.right * playerSpeed;
		}
	}
	void playerStopped(bool isIdle){
		Animator animate = this.GetComponent<Animator>();
		AnimatorStateInfo stateInfo = animate.GetCurrentAnimatorStateInfo(0);
		var player = GameObject.Find("Player");
		var camera = GameObject.Find("Main Camera");

		animate.SetBool("Walk_Down",false);
		animate.SetBool("Walk_Right",false);
		animate.SetBool("Walk_Left",false);
		animate.SetBool("Walk_Up",false);

		player.rigidbody.velocity = new Vector3(0,Physics.gravity.y,0);
		camera.rigidbody.velocity = camera.transform.right *0;
	}

}
