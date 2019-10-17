using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; 
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClickNewGame : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	public string targetScene;

	GameManager gameManager;

	void Awake()
	{
		gameManager = Object.FindObjectOfType<GameManager> ();
	}

	public void OnPointerDown  (PointerEventData evenData)
	{
		GetComponentInChildren<Text> ().color = Color.cyan;
	}

	public void OnPointerUp  (PointerEventData evenData)
	{
		Invoke ("ChangeScene", 0.15f);
	}

	void ChangeScene()
	{
		GetComponentInChildren<Text> ().color = Color.black;
		//game.SendMessage ("StartNewGame");

		gameManager.Health = 1f;
		SceneManager.LoadScene(targetScene);
	}
}
