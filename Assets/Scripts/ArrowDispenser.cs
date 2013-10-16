using UnityEngine;
using System.Collections;

public class ArrowDispenser:MonoBehaviour {
	private int amount = 10;
	private int direction = 1;	// UP: 0 - LEFT: 1 - DOWN: 2 - RIGHT: 3
	
	void Start() {
		gameObject.name = "Arrow Dispenser";
		
		for(int i = 0; i < amount; i++) {
			Instantiate(Resources.Load("Arrow"), new Vector3(transform.position.x - 1, transform.position.y, transform.position.z), new Quaternion(0, 0, direction * -90, 0));
		}
	}
}
