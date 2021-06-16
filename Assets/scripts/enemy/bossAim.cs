using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossAim : MonoBehaviour {

	public GameObject a_bulletPH; //change this later
	public Transform Target;
	Transform a_firePos;
	public float speed = 1; //speed of bullet

	public float fireRate = 1.0F;
	private float nextFire = 0.0F;
	//static bool firing = false;

	// Use this for initialization
	void Start () {
		a_firePos = transform.Find("a_firePos");
	}

	// Update is called once per frame
	void Update () {

		//aims the arm and gun at UFO
		//Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
		Vector3 dir = (Target.position - transform.position).normalized;   //may need to multiply to get bullets to fly?
		float angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis (angle + 190, Vector3.forward);		

		//gives bullets a delay in firerate
		if (Time.time > nextFire) { //////////add another condition
			nextFire = Time.time + fireRate;
			Fire (); //fire a bullet
		}

	}


	void Fire()
	{
		//Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
		Vector3 dir = (Target.position - transform.position).normalized * 400; //bullets must fire using this vector of direction
		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		float xPos = dir.x;
		float yPos = dir.y;

		//rotations for bullets still needs fixing
		GameObject a_bulletInstance = Instantiate (a_bulletPH, a_firePos.position, Quaternion.AngleAxis(angle, Vector3.forward)) as GameObject;
		a_bulletInstance.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (xPos*speed, yPos*speed), 0);
	}
}
