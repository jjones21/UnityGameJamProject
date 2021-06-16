using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManaging: MonoBehaviour {

	public Button startButton;
	public Button instructionsButton;
	public Button MMButton;
	// Use this for initialization
	void Start () {
		Button startbtn = startButton.GetComponent<Button> ();
		Button instrbtn = instructionsButton.GetComponent<Button> ();
		Button mmbtn = MMButton.GetComponent<Button> ();

		startbtn.onClick.AddListener (startGame);
		instrbtn.onClick.AddListener (instructions);
		mmbtn.onClick.AddListener (mainmenu);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void startGame()
	{
		SceneManager.LoadSceneAsync ("Cow_UFO_game",LoadSceneMode.Single);
	}

	void instructions()
	{
		SceneManager.LoadSceneAsync ("Instructions", LoadSceneMode.Single);
	}

	void mainmenu()
	{
		SceneManager.LoadSceneAsync ("Main_Menu", LoadSceneMode.Single);
	}
}

