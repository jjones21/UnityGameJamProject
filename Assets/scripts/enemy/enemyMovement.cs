using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour {
	//Random rnd = new Random();
	//SpriteRenderer renderer;
	//public Sprite milksplat;
	//public Sprite alien;


	public float aggressionLvl=10f;
	public int maxSpeed= 1;
	int speed= 1;
	int timer=0;
	float rando;
	public static bool firing = false;


	// Use this for initialization
	void Start () {
		

		//alien = Resources.Load<Sprite> ("Ayylien_1");
		//milksplat = Resources.Load<Sprite> ("milksplat");
		//renderer = GetComponent<SpriteRenderer> ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
	
	rando = Random.Range (1f, 10000f);
	//Debug.Log (rando);
		if(timer==0)
		if (rando <= aggressionLvl) {
			speed = 0;
			timer = 60;
			firing = true;
		}
		if (timer != 0) {
			timer = timer - 1;

		} if (timer == 1) {
			speed = maxSpeed;
			firing = false;
		}
		if(timer== 30)
		//Debug.Log (timer);

		transform.Translate (new Vector2 (-speed, 0) * Time.deltaTime);
		//transform.Translate (new Vector2 (-speed, 0) * Time.deltaTime);

	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "lWall") {
			Destroy (gameObject);
		} 
			//renderer.sprite = milksplat;
			//Destroy (gameObject);
		}

	}


