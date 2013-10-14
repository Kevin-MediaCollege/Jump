using UnityEngine;
using System.Collections;

public class Trigger:MonoBehaviour {
	public int type;
	
	void OnTriggerEnter(Collider collider) {
		if(type == 1) {
			if(collider.name == "Player") {
				Instantiate(Resources.Load("TrapBall"), new Vector3(15.5f, 25f, 0), Quaternion.identity);
			}
		}
	}
}
