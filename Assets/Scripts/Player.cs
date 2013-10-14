using UnityEngine;
using System.Collections;

public class Player:MonoBehaviour 
{
	private int walkSpeed = 10;
	private int jumpSpeed = 30;
	
	private bool onGround;
	
	private GameObject cam;
	private bool drawing;
	private bool down;
	private GameObject line;
	private float pos1x;
	private float pos1y;
	private float pos2x;
	private float pos2y;
	
	void Start() {
		cam = GameObject.Find("Main Camera");
	}
	
	void FixedUpdate() {
		drawCheck();
		
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
			if(collision.collider.name == "Floor") {
				onGround = true;
			}
		}
	}
	
	void OnCollisionExit(Collision collision) {
		onGround = false;
	}
	
	void drawCheck() {
		if(Input.GetMouseButtonDown(0)) {
			down = true;
		}
		if(Input.GetMouseButtonUp(0)) {
			down = false;
		}
		
		if (down && !drawing) {
			drawing = true;
			
			Vector3 p = cam.camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f));
			pos1x = p.x;
			pos1y = p.y;
			
			line = Instantiate(Resources.Load("Line"), transform.position, Quaternion.identity) as GameObject;	
			line.name = "Line";
		}
		
		if(drawing) {
			Vector3 p = cam.camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f));
			pos2x = p.x;
			pos2y = p.y;
			
			if (!down) { 
				drawing = false;
			}
			
			float distance = getDistance(pos1x, pos1y, pos2x, pos2y);
			float degree = getDegreeFromPoint(pos1x, pos1y, pos2x, pos2y);
			float newX = getNextX(pos1x, degree, distance / 2f);
			float newY = getNextY(pos1y, degree, distance / 2f);
			
			Vector3 pos = new Vector3(newX, newY, 0);
			line.transform.position = pos;
			Vector3 scl = new Vector3(distance, 1f, 1f);
			line.transform.localScale = scl;
			line.transform.localEulerAngles = new Vector3(0f, 0f, degree);
		}
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