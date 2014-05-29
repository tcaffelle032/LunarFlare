using UnityEngine;
using System.Collections;

public class Friendly_NPC : MonoBehaviour {
	float timer = 3;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		//Debug.Log(timer);
		if(timer <= 0)
			NPCMovement(Random.Range(0,5),3);
		var npc = this.gameObject;
		npc.transform.rotation = Quaternion.identity;
	}

	void NPCMovement(int direction,int speed){
		var npc = this.gameObject;
		timer = 3;

		switch(direction){
		case 1:
			npc.rigidbody.velocity = npc.transform.forward * speed;
			break;
		case 2:
			npc.rigidbody.velocity = -npc.transform.forward * speed;
			break;
		case 3:
			npc.rigidbody.velocity = npc.transform.right * speed;
			break;
		case 4:
			npc.rigidbody.velocity = -npc.transform.right * speed;
			break;
		 default:
			npc.rigidbody.velocity = npc.transform.forward * 0;
			break;

		}
	}
}
