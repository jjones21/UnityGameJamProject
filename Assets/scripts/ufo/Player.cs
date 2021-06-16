using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour 

{
	
	InputManager inputManager;

	[SerializeField] float playerSpeed = 5f;

	private void Awake()
	{
		inputManager = GetComponent<InputManager>();
	}

	void FixedUpdate ()
	{
		transform.Translate(inputManager.CurrentInput * Time.deltaTime * playerSpeed);
		//transform.Translate(new Vector2(cameraScroll.speed,0));
	}
}