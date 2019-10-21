using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class QuitApp : MonoBehaviour, IPointerDownHandler, IPointerUpHandler 
{
	Text text;
	Color initialColor;

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
		Invoke ("ExitApp", 0.15f);
	}

	void ExitApp()
	{
		Application.Quit();
		Debug.Log ("aplicación cerrada");
		text.color = initialColor;
	}
}
