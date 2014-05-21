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
			player.rigidbody.velocity = new Vector3(0,Physics.gravity.y,0);
			playerStopped(false);
		}
		player.transform.rotation =  Quaternion.identity;
	}

	void playerMovement(GameObject player){
		Animator animate = this.GetComponent<Animator>();
		AnimatorStateInfo stateInfo = animate.GetCurrentAnimatorStateInfo(0);

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

		}
		else if(Input.GetKeyDown(KeyCode.A)){
			player.rigidbody.velocity = -player.transform.right * playerSpeed;
			player.transform.rotation = new Quaternion(0,-1,0,0);
			animate.SetBool("Walk_Left",true);
		}
	}
	void playerStopped(bool isIdle){
		Animator animate = this.GetComponent<Animator>();
		AnimatorStateInfo stateInfo = animate.GetCurrentAnimatorStateInfo(0);

		animate.SetBool("Walk_Down",false);
		animate.SetBool("Walk_Right",false);
		animate.SetBool("Walk_Left",false);
		animate.SetBool("Walk_Up",false);
	}

}
