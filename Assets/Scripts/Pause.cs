using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour 
{
	public GameObject keys;

	private Canvas canvasPause;
	public bool pause;

	// Use this for initialization
	void Start () 
	{
		canvasPause = GetComponent<Canvas> ();
		canvasPause.enabled = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.Space)) 
		{
			pause = !pause;
		}

		if (pause) 
		{
			Time.timeScale = 0f; //pausa el juego
			canvasPause.enabled = true;
			//settingsMenu.enabled = true;
			keys.SetActive(true);
		} 
		else
		{
			canvasPause.enabled = false;
			//settingsMenu.enabled = false;
			keys.SetActive(false);
			Time.timeScale = 1f; //reanuda el juego
		}
	}
}
