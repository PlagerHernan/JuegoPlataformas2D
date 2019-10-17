using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour 
{
	//public InteractiveElement buttonPause;
	public GameObject infoPause;
	public GameObject userInterface;

	private Canvas canvasPause;
	public bool pause;

	void Start () 
	{
		canvasPause = GetComponent<Canvas> ();
		canvasPause.enabled = false;
	}

	void Update () 
	{
		//bool activeButtonPause = buttonPause.click;

		if (Input.GetKeyDown(KeyCode.Space)) //|| activeButtonPause) 
		{
			pause = !pause;
		}

		if (pause) 
		{
			EnterPause ();
		} 
		else
		{
			ExitPause ();
		}
	}

	public void EnterPause()
	{
		Time.timeScale = 0f; //pausa el juego
		canvasPause.enabled = true;
		infoPause.SetActive(true);
		userInterface.SetActive (false);
	}
	public void ExitPause()
	{
		canvasPause.enabled = false;
		infoPause.SetActive(false);
		userInterface.SetActive (true);
		Time.timeScale = 1f; //reanuda el juego
	}
}
