using UnityEngine;
using System.Collections;

public class Arrow:MonoBehaviour {
	public int direction;
	
	private int moveSpeed = 5;
	
	void FixedUpdate() {
		if(direction > 0) {
			rigidbody.velocity = new Vector3(moveSpeed, 0, 0);
		} else if(direction < 0) {
			rigidbody.velocity = new Vector3(-moveSpeed, 0, 0);
		}
	}
	
	void OnCollisionEnter(Collision collision) {
		if(collision.collider.name != "Arrow") {
			if(collision.collider.name == "Player") {
				Destroy(collision.collider.gameObject);
				Application.LoadLevel(0);
			}
			
			Destroy(gameObject);
		}
	}
}
