using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; 
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonLoad : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	//public string targetScene;
	GameObject game;

	void Start()
	{
		game = GameObject.Find ("Game");
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
		if (PlayerPrefs.HasKey("health")) 
		{
			float health = PlayerPrefs.GetFloat ("health"); 
			game.SendMessage ("LoadGame", health);
			SceneManager.LoadScene("Level_02");
		} 
		else
		{
			Debug.Log ("no hay nada guardado");
		}

	}
}
