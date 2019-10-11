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
	Text gameOverText;
	Image gameOverImage;
	Color gameOverColor;
	Color levelCompletedColor;

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
		gameOverText = gameOver.GetComponentInChildren<Text> ();
		gameOverImage = gameOver.GetComponentInChildren<Image> ();
		gameOverColor = new Color (1f, 0f, 0f, 0.3f); //red
		levelCompletedColor = new Color (0f, 1f, 0f, 0.3f); //green
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
			GameObject.Destroy (player);
			StartCoroutine(LoadScene("Menu", "Juego Terminado", gameOverColor));
		}
	}

	//llamado desde player
	public void NextLevel()
	{
		StartCoroutine(LoadScene("Level_02", "Nivel completado", levelCompletedColor));
	}

	private IEnumerator LoadScene(string scene, string text, Color color)
	{
		gameOverText.text = text;
		gameOverImage.color = color;
		gameOver.enabled = true;
		yield return new WaitForSeconds (3f);
		SceneManager.LoadScene (scene);
	}
}
