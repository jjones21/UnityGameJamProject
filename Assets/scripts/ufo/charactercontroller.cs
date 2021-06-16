using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charactercontroller : MonoBehaviour {
	public int maxSpeed = 5;
	public Rigidbody2D rb;
	void start(){
		//body = GetComponent<Rigidbody2D> ();
	}

	// Use this for initialization

	void FixedUpate(){


		//transform.Translate (Vector2.right * Mathf.Abs (h) * Time.deltaTime);
		float Hmove = Input.GetAxis ("Horizontal");
		float Vmove = Input.GetAxis ("vertical");
		//if ((GetComponent<Rigidbody2D> ())) if ((Input.GetAxis ("vertical") == -1f))
			//Vmove = 0;
		//if ((GetComponent<Rigidbody2D> ().IsTouching) && (Input.GetAxis ("vertical") == 1f))
			//Vmove = 0;
		//if(Input.GetButton("a"))
		//Debug.Log("memed");
		GetComponent<Rigidbody2D> ().AddForce(new Vector2 (Hmove * maxSpeed, Vmove * maxSpeed));
		
	}
}
