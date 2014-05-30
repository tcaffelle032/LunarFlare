using UnityEngine;
using System.Collections;

public class NPC_Spawner : MonoBehaviour {
	public int NpcNum;
	// Use this for initialization
	void Start () {

		createNPC(NpcNum);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void createNPC(int count){
		for(int i = 0; i <= count; i++){
			float rand = Random.Range(-10,10);
			GameObject.Instantiate(Resources.Load("NPC"),new Vector3(rand,3,rand),Quaternion.identity);
		}
	}
}
