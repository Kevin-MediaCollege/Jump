using UnityEngine;
using System.Collections;

public class TrapBall:MonoBehaviour {
	public int direction;
	
	private int rollingSpeed = 5;
	private bool onGround;
	
	void Start() {
		gameObject.name = "TrapBall";	
	}
		
	void FixedUpdate() {
		Vector3 speed = new Vector3(0, rigidbody.velocity.y - 1, 0);
				
		if(onGround) {
			if(direction > 0) {
				speed.x = rollingSpeed;
			} else if(direction < 0) {
				speed.x = -rollingSpeed;
			}
		}
		
		rigidbody.velocity = speed;
	}
	
	void OnCollisionEnter(Collision collision) {
		if(collision.contacts[0].normal.y > 0.7f) {
			onGround = true;
		}
		
		if(collision.collider.name == "Player") {
			Destroy(collision.collider.gameObject);
			Application.LoadLevel(0);
		}
	}
}
