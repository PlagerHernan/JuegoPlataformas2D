using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; 
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonLoad : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	GameObject game;
	GameManager gameManager;
	Text text;
	Color initialColor;

	void Awake()
	{
		gameManager = Object.FindObjectOfType<GameManager> ();
	}

	void Start()
	{
		game = GameObject.Find ("Game");
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
		//PlayerPrefs.DeleteAll ();

		//si hay una partida guardada (se guarda automaticamente al superar un nivel (NextLevel() en Game.cs))
		if (PlayerPrefs.HasKey("health") && PlayerPrefs.HasKey("level")) 
		{
			//recupera datos de playerPref y se los asigna a gameManager (luego Game.cs los recupera en Start())
			float health = PlayerPrefs.GetFloat ("health");
			gameManager.Health = health;

			int level = PlayerPrefs.GetInt ("level");
			gameManager.Level = level;

			SceneManager.LoadScene (level);
		}
		else
		{
			Debug.Log ("no hay nada guardado");
			text.color = initialColor;
		}

	}
}
