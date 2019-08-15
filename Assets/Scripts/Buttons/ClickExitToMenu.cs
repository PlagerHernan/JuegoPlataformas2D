using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; 
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClickExitToMenu : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	public Pause csPause;

	public void OnPointerDown  (PointerEventData evenData)
	{
		GetComponentInChildren<Text> ().color = Color.cyan;
	}

	public void OnPointerUp  (PointerEventData evenData)
	{
		ChangeScene();

		csPause.pause = false;
	}

	void ChangeScene()
	{
		SceneManager.LoadScene("Menu");
	}
}
