using UnityEngine;
using System.Collections;

public class Ending:MonoBehaviour {
	void OnTriggerEnter(Collider collider) {
		if(collider.name == "Player") {
			Destroy(collider.gameObject);
			Application.LoadLevel(0);
		}
	}
}
