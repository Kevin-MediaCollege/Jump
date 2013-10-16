using UnityEngine;
using System.Collections;

public class Player:MonoBehaviour {
	private int walkSpeed = 10;
	private int jumpSpeed = 30;
	
	private GameObject line;
	private GameObject cam;
	
	private bool isDrawing;
	private bool onGround;
	private bool isDown;
	
	private float startX;
	private float startY;
	private float endX;
	private float endY;
	
	void Start() {
		cam = GameObject.Find("Main Camera");
	}
	
	void Update() {
		if(Input.GetMouseButtonDown(0)) {
			isDown = true;
		} else if(Input.GetMouseButtonUp(0)) {
			isDown = false;
		}
		
		if (isDown && !isDrawing) {
			isDrawing = true;
			
			Vector3 position = cam.camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f));
			startX = position.x;
			startY = position.y;
			
			line = Instantiate(Resources.Load("Line"), transform.position, Quaternion.identity) as GameObject;	
			line.name = "Line";
		}
		
		if(isDrawing) {
			Vector3 position = cam.camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f));
			
			endX = position.x;
			endY = position.y;
			
			if (!isDown) { 
				isDrawing = false;
			}
			
			float distance = getDistance(startX, startY, endX, endY);
			float degree = getDegreeFromPoint(startX, startY, endX, endY);
			float newX = getNextX(startX, degree, distance / 2f);
			float newY = getNextY(startY, degree, distance / 2f);
			
			Vector3 pos = new Vector3(newX, newY, 0);
			line.transform.position = pos;
			Vector3 scl = new Vector3(distance, 0.5f, 1f);
			line.transform.localScale = scl;
			line.transform.localEulerAngles = new Vector3(0f, 0f, degree);
		}
	}
	
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
	}
	
	void OnCollisionStay(Collision collision) {
		if(collision.contacts[0].normal.y > 0.7f) {
			if(collision.collider.name == "Floor" || collision.collider.name == "Line") {
				onGround = true;
			}
		}
	}
	
	void OnCollisionExit(Collision collision) {
		onGround = false;
	}
	
	float getNextX(float x, float d, float s) {
		return x + (s * Mathf.Cos(d * Mathf.PI / 180f));
	}

	float getNextY(float y, float d, float s) {
		return y + (s * Mathf.Sin(d * Mathf.PI / 180f));
	}

	float getDistance(float x1, float y1, float x2, float y2) {
		return Mathf.Sqrt((x1-x2)*(x1-x2) + (y1-y2)*(y1-y2));
	}

	float getDegreeFromPoint(float x1, float y1, float x2, float y2) {
		return Mathf.Atan2((y2 - y1), (x2 - x1)) * 180f / Mathf.PI;
	}
}