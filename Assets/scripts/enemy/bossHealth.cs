using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class bossHealth : MonoBehaviour {


	public int maxHealth = 50;

	public Text bosshealthText;
	int curHealth;
	public float flashSpeed;
	//SpriteRenderer SR;
	SpriteRenderer[] sprites;

	// Use this for initialization
	void Start () {
		//SR = GetComponent<SpriteRenderer> ();
		sprites = GetComponentsInChildren<SpriteRenderer>();
		curHealth = maxHealth;
		setbosshealthText ();
	}

	// Update is called once per frame
	void Update () {
		if (curHealth < 1) {
			SceneManager.LoadSceneAsync ("Win_Screen",LoadSceneMode.Single);
			//end the game - win screen
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "m_bullet") {

			curHealth -= 1;
			setbosshealthText ();
			//Debug.Log(curHealth);
			StartCoroutine(Flash(flashSpeed));
			Destroy(other.gameObject); //destroys our bullet
		}
	}

	IEnumerator Flash(float x)
	{

		for (int i = 0; i < sprites.Length; i++) {
			sprites [i].material.color = Color.red;
		}

		yield return new WaitForSeconds (x);

		for (int i = 0; i < sprites.Length; i++) {

			sprites [i].material.color = Color.white;

		}
	}

	void setbosshealthText()
	{
		bosshealthText.text = curHealth.ToString();
	}
}
