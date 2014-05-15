using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public int playerSpeed;
	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		GameObject player = GameObject.Find("Player");
		 
		if(Input.anyKey){
			playerMovement(player);
		}
		else if(!Input.anyKey) {
			player.rigidbody.velocity = Vector3.zero;
		}


			player.transform.rotation =  Quaternion.identity;


	
	}

	void playerMovement(GameObject player){


		if(Input.GetKeyDown(KeyCode.W)){
			player.rigidbody.velocity = player.transform.forward * playerSpeed;			
		}

		else if(Input.GetKeyDown(KeyCode.S)){
			player.rigidbody.velocity = -player.transform.forward * playerSpeed;		
		}
		else if(Input.GetKeyDown(KeyCode.D)){
			player.rigidbody.velocity = player.transform.right * playerSpeed;	
		}
		else if(Input.GetKeyDown(KeyCode.A)){
			player.rigidbody.velocity = -player.transform.right * playerSpeed;	
		}
	


	}
}
