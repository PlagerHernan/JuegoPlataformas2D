using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour 
{
	GameObject player;
	public Image healthBar;
	Canvas gameOver; 
	Canvas userInterface;
	GameObject pause;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.Find("Player");

		pause = GameObject.Find("Pause");
		pause.SetActive (true);

		userInterface = GameObject.Find ("UserInterface").GetComponent<Canvas>();
		userInterface.enabled = true;

		gameOver = GameObject.Find ("GameOver").GetComponent<Canvas>();
		gameOver.enabled = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	//recibe de player el daño, y modifica la barra de salud
	public void Damage(float playerHealth)
	{
		healthBar.rectTransform.localScale = new Vector3 (playerHealth, 1f, 1f);

		//si player ha muerto
		if (healthBar.rectTransform.localScale.x == 0f) 
		{
			userInterface.enabled = false;
			pause.SetActive (false);
			gameOver.enabled = true;
			GameObject.Destroy (player);
			Invoke ("ExitToMenu", 2f);
		}
	}

	void ExitToMenu()
	{
		SceneManager.LoadScene ("Menu");
	}

	public void NextLevel()
	{
		
		SceneManager.LoadScene ("Level_02");
	}
}
