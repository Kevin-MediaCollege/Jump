using UnityEngine;
using System.Collections;

public class Player:MonoBehaviour {
	private int walkSpeed = 10;
	private int jumpSpeed = 30;
	
	private bool onGround;
	
	void FixedUpdate() {
		Vector3 speed = new Vector3(0, rigidbody.velocity.y - 1, 0);
			
		if(Input.GetKey("d")) {
			if(!onGround) {
				speed.x = walkSpeed / 2;
			} else {
				speed.x = walkSpeed;
			}
		} else if(Input.GetKey("a")) {
			if(!onGround) {
				speed.x = -walkSpeed / 2;
			} else {
				speed.x = -walkSpeed;
			}
		}
			
		if(Input.GetKey("space") && onGround) {
			speed.y = jumpSpeed;
			onGround = false;
		}
		
		rigidbody.velocity = speed;
		
		Debug.Log (onGround);
	}
	
	void OnCollisionStay(Collision collision) {
		if(collision.contacts[0].normal.y > 0.7f) {
			if(collision.collider.name == "Floor") {
				onGround = true;
			}
		}
	}
	
	void OnCollisionExit(Collision collision) {
		onGround = false;
	}
}