using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class activatebossUI : MonoBehaviour {

	public CanvasGroup myCanvas;
	// Use this for initialization
	void Start () {
		myCanvas = GetComponent<CanvasGroup> ();
		myCanvas.alpha = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag =="Player")
		{
			myCanvas.alpha = 1f;
		}
	}
}
