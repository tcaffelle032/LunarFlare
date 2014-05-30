using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Friendly_NPC : MonoBehaviour {
	float timer = 3;
	// Use this for initialization
	void Start () {
		int rnd = Random.Range(0,3);
		setNPCName(rnd);
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

	void OnCollisionStay(Collision collision){
		if(collision.gameObject.name == "Player" && Input.GetKeyDown(KeyCode.Space)){

			EventManger.Interaction(this.gameObject.name);
		  }
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

	string setNPCName(int key){
		Dictionary<int,string> nameList = new Dictionary<int, string>();

		nameList.Add(0,"Robb");
		nameList.Add(1,"Tyler");
		nameList.Add(2,"Jason");

		return this.gameObject.name = nameList[key];
	}
}
