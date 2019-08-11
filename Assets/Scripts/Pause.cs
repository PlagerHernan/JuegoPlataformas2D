using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour 
{
	private Canvas canvasPause;
	private bool pause;

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
			canvasPause.enabled = true;
			Time.timeScale = 0f; //pausa el juego
		} 
		else
		{
			canvasPause.enabled = false;
			Time.timeScale = 1f; //reanuda el juego
		}
	}
}
