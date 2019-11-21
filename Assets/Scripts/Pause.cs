using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour 
{
	public GameObject userInterface;
	private AudioSource gameMusic;

	private Canvas canvasPause;
	public bool pause;

	void Start () 
	{
		canvasPause = GetComponent<Canvas> ();
		canvasPause.enabled = false;
		gameMusic = GameObject.Find ("Game").GetComponent<AudioSource>();

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
		gameMusic.pitch = Time.timeScale = 0f;
		Time.timeScale = 0f; //pausa el juego
		canvasPause.enabled = true;
		userInterface.SetActive (false);
	}
	public void ExitPause()
	{
		canvasPause.enabled = false;
		userInterface.SetActive (true);
		gameMusic.pitch = Time.timeScale = 1f;
		Time.timeScale = 1f; //reanuda el juego
	}
}
