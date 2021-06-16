using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScroll : MonoBehaviour {
	public float speed=1f;
	public static bool stopped = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.Translate (new Vector2 (speed, 0) * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D other){
		//Debug.Log ("entered");
		if (other.CompareTag("bossEnd")){
			//Debug.Log("found");
			stopped = true;
			speed = 0;
		}
	}
}
