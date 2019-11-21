using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; 
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClickNewGame : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	public string targetScene;
	Text text;
	Color initialColor;

	GameManager gameManager;

	void Awake()
	{
		gameManager = Object.FindObjectOfType<GameManager> ();
	}

	void Start()
	{
		text = GetComponentInChildren<Text> ();
		initialColor = text.color;
	}

	public void OnPointerDown  (PointerEventData evenData)
	{
		text.color = Color.cyan;
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
		text.color = initialColor;
		SceneManager.LoadScene(targetScene);
	}
}
