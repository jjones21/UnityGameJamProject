using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroyer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Ground" || other.gameObject.tag == "Wall" || other.gameObject.tag == "lWall") {
			Destroy (gameObject);
		} 
	}
}

