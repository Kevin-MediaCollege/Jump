using UnityEngine;
using System.Collections;

public class PressurePlate:MonoBehaviour {
	public int type;
	public int uses;
	
	void OnTriggerEnter(Collider collider) {
		transform.position = new Vector3(transform.position.x, transform.position.y - 0.050f, transform.position.z);
		transform.localScale = new Vector3(1f, 0.05f, 1f);
		
		if(uses > 0 || uses == -1) {
			switch(type) {
			case 1:
				Instantiate(Resources.Load("TrapBall"), new Vector3(17.5f, 25f, 0), Quaternion.identity);
				break;
			case 2:
				Instantiate(Resources.Load("Arrow Dispenser"), new Vector3(30, 17, 0), Quaternion.identity);
				break;
			}
			
			uses--;
		}
	}
	
	void OnTriggerExit(Collider collider) {
		transform.position = new Vector3(transform.position.x, transform.position.y + 0.050f, transform.position.z);
		transform.localScale = new Vector3(1f, 0.15f, 1f);
	}
}
