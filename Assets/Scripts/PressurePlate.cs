using UnityEngine;
using System.Collections;

public class PressurePlate:MonoBehaviour {
	public int type;
	public int uses;
	
	void OnTriggerEnter(Collider collider) {
		if(collider.name != "Arrow") {
			transform.position = new Vector3(transform.position.x, transform.position.y - 0.050f, transform.position.z);
			transform.localScale = new Vector3(1f, 0.05f, 1f);
			
			if(uses > 0 || uses == -1) {
				switch(type) {
				case 1:
					Instantiate(Resources.Load("Arrow"), new Vector3(-13, 25, 0), new Quaternion(0, 0, 180, 1));
					Instantiate(Resources.Load("Arrow"), new Vector3(-13, 26, 0), new Quaternion(0, 0, 180, 1));
					Instantiate(Resources.Load("Arrow"), new Vector3(-13, 27, 0), new Quaternion(0, 0, 180, 1));
					Instantiate(Resources.Load("Arrow"), new Vector3(-13, 28, 0), new Quaternion(0, 0, 180, 1));
					Instantiate(Resources.Load("Arrow"), new Vector3(-13, 29, 0), new Quaternion(0, 0, 180, 1));
					
					Instantiate(Resources.Load("TrapBall"), new Vector3(13.4f, 44.9f, 0), Quaternion.identity);
					break;
				case 2:
					Instantiate(Resources.Load("TrapBall"), new Vector3(13.4f, 12.9f, 0), Quaternion.identity);
					break;
				}
				
				if(uses != -1) {
					uses--;
				}
			}
		}
	}
	
	void OnTriggerExit(Collider collider) {
		if(collider.name != "Arrow") {
			transform.position = new Vector3(transform.position.x, transform.position.y + 0.050f, transform.position.z);
			transform.localScale = new Vector3(1f, 0.15f, 1f);
		}
	}
}
