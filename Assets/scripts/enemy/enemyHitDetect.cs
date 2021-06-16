using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHitDetect : MonoBehaviour {
	
	Animator ani;
	// Use this for initialization
	void Start () {
		ani = GetComponent <Animator>();
		ani.SetBool ("isShot", false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "m_bullet") {
			//Debug.Log ("hit");
			ani.SetBool ("isShot", true);
		}

	}
}
