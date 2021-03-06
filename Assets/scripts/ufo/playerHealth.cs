using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class playerHealth : MonoBehaviour {


	public int maxHealth = 10;

	public Text healthText;
	int curHealth;
	public float flashSpeed;
	SpriteRenderer SR;
	// Use this for initialization
	void Start () {
		SR = GetComponent<SpriteRenderer> ();
		curHealth = maxHealth;
		setHealthText ();
	}
	
	// Update is called once per frame
	void Update () {
		if (curHealth < 1) {
			SceneManager.LoadSceneAsync ("Lose_Screen",LoadSceneMode.Single);
			//end the game - lose screen
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "a_bullet") {
			//reduce UFO health number by 1

			curHealth -= 1;
			setHealthText ();
			Debug.Log(curHealth);
			StartCoroutine(Flash(flashSpeed));
			Destroy (other.gameObject);
		}
			}

	IEnumerator Flash(float x)
	{
		Material m = this.SR.material;
		Color32 c = this.SR.material.color;
		//this.SR.material = null;
		this.SR.material.color = Color.red;
		//SR.enabled = false;
		yield return new WaitForSeconds (x);
		//this.SR.material = m;
		this.SR.material.color = c;
		//SR.enabled = true;
	}

	void setHealthText()
	{
		healthText.text = curHealth.ToString();
	}
}
