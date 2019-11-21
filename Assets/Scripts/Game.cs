using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour 
{
	AudioSource[] audios;
	AudioSource gameSounds;
	AudioSource gameMusic;
	public AudioClip audioDie;
	public AudioClip audioWin;

	GameObject player;
	float playerHealth;
	Image healthBar;
	Canvas gameOver; 
	Canvas userInterface;
	GameObject pause;
	Text gameOverText;
	Image gameOverImage;

	Color gameOverColor;
	Color levelCompletedColor;

	GameManager gameManager;
	Scene activeScene;

	void Awake()
	{
		gameManager = Object.FindObjectOfType<GameManager> ();
	}

	// Use this for initialization
	void Start () 
	{
		audios = GetComponents<AudioSource> ();
		gameMusic = audios [0];
		gameSounds = audios [1];

		gameOverColor = new Color (1f, 0f, 0f, 0.3f); //red
		levelCompletedColor = new Color (0f, 1f, 0f, 0.3f); //green

		player = GameObject.Find("Player");

		pause = GameObject.Find("Pause");
		pause.SetActive (true);

		userInterface = GameObject.Find ("UserInterface").GetComponent<Canvas>();
		userInterface.enabled = true;

		healthBar = GameObject.Find ("HealthBar").GetComponent<Image> ();

		gameOver = GameObject.Find ("GameOver").GetComponent<Canvas>();
		gameOver.enabled = false;
		gameOverText = gameOver.GetComponentInChildren<Text> ();
		gameOverImage = gameOver.GetComponentInChildren<Image> ();
		//-----------------------------------------------------------------------------------
		userInterface.enabled = true;
		pause.SetActive (true);
		//Instantiate (playerPrefab, new Vector3 (-7f, -3.7f, 0f), new Quaternion(0f,0f,0f,0f));
		//player.transform.position = new Vector3 (-7f, -3.7f, 0f); //recoloca a player en inicio

		playerHealth = gameManager.Health; //obtiene salud de GameManager
		healthBar.rectTransform.localScale = new Vector3 (playerHealth, 1f, 1f); //configura barra de salud 

		activeScene = SceneManager.GetActiveScene (); 
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

//	public void StartNewGame()
//	{
//		
//	}

//	public void LoadGame(float health)
//	{
//		playerHealth = health;
//		healthBar.rectTransform.localScale = new Vector3 (playerHealth, 1f, 1f);
//	}
//
	//recibe de player el daño, y modifica la barra de salud. Si cayó a precipicio: die true
	public void Damage(bool die)
	{
		playerHealth = Mathf.Clamp (playerHealth - 0.25f, 0f, 1f);
		healthBar.rectTransform.localScale = new Vector3 (playerHealth, 1f, 1f);

		//si player ha muerto
		if (healthBar.rectTransform.localScale.x == 0f || die) 
		{
			gameSounds.clip = audioDie;
			gameSounds.Play ();
			Exit ();
		}
	}

	//llamado desde player
	public void NextLevel()
	{
		//guarda datos con playerPref (luego recuperados por ButtonLoad.cs)
		PlayerPrefs.SetInt ("level", activeScene.buildIndex + 1);
		PlayerPrefs.SetFloat ("health", playerHealth);

		//brinda info a gameManager, para recibirla en el próximo nivel en Start()
		gameManager.Health = playerHealth; 

		gameSounds.clip = audioWin;
		gameSounds.Play ();
		StartCoroutine(ChangeScene(activeScene.buildIndex + 1, "Nivel completado", levelCompletedColor)); //activeScene.buildIndex + 1: nivel siguiente al actual
	}

	//llamado desde player
	public void GameWon()
	{
		gameSounds.clip = audioWin;
		gameSounds.Play ();
		StartCoroutine(ChangeScene(0, "Felicitaciones! Has ganado!", levelCompletedColor)); //escena 0: menú
	}


	//llamado desde Damage() o desde ClickExitToMenu.cs
	public void Exit()
	{
		StartCoroutine(ChangeScene(0, "Juego Terminado", gameOverColor)); //escena 0: menú
	}

	//coroutine
	private IEnumerator ChangeScene (int scene, string text, Color color)
	{
		gameMusic.Stop();
		GameObject.Destroy (player);
		pause.SetActive (false);
		userInterface.enabled = false;
		gameOverText.text = text;
		gameOverImage.color = color;
		gameOver.enabled = true;
		yield return new WaitForSeconds (4.5f);
		gameOver.enabled = false;
		SceneManager.LoadScene (scene);
	}
}
