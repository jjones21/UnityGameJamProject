using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nipps : MonoBehaviour {

	public GameObject m_bullet; //can plug in the bullet prefab in here
	Transform firePos;
	Transform firePos2;

	public float fireRate = 0.2F;
	private float nextFire = 0.0F;

	bool canShoot = true;
	public float speed = 3; //speed of bullet

	Animator ani;

	// Use this for initialization
	void Start () {
		ani = GetComponent <Animator>();

		firePos = transform.Find("firePos");
		firePos2 = transform.Find ("firePos2");
	}


	void Update(){
		Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
		Vector3 dir = Input.mousePosition - pos;  
		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);

		if(Input.GetMouseButton(0) && Time.time > nextFire) //Fires bullets
		{
			nextFire = Time.time + fireRate;
			FireR ();
			if (canShoot == true) {
				StartCoroutine (leftshoot ());
			}
		}
	}

	// Update is called once per frame
	void FixedUpdate () {

		if (Input.GetMouseButton (0)) {
			ani.SetBool ("holdingLeft", true);
		} else {
			ani.SetBool ("holdingLeft", false);
		}
	}

	public IEnumerator leftshoot() //creates alternating fire between left and right
	{
		canShoot = false;
		yield return new WaitForSeconds(fireRate/2);
		FireL ();
		canShoot = true;
	}

	void FireR() //this method is called when we hold down the mouse
	{
		Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
		Vector3 dir = (Input.mousePosition - pos).normalized * 400; //bullets must fire using this vector of direction
		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		float xPos = dir.x;
		float yPos = dir.y;

		GameObject m_bulletInstanceR = Instantiate (m_bullet, firePos.position, Quaternion.AngleAxis(angle + 90, Vector3.forward)) as GameObject;
		m_bulletInstanceR.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (xPos*speed, yPos*speed), 0);
	}

	void FireL()
	{
		Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
		Vector3 dir = (Input.mousePosition - pos).normalized * 400; //bullets must fire using this vector of direction
		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		float xPos = dir.x;
		float yPos = dir.y;

		GameObject m_bulletInstanceL = Instantiate (m_bullet, firePos2.position, Quaternion.AngleAxis(angle + 90, Vector3.forward)) as GameObject;
		m_bulletInstanceL.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (xPos*speed, yPos*speed), 0);
	}
}
