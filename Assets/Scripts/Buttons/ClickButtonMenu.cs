﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; 
using UnityEngine.UI;

public class ClickButtonMenu : MonoBehaviour, IPointerDownHandler, IPointerUpHandler  
{
	public Canvas targetMenu;
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
		Invoke ("ChangeMenu", 0.15f);
	}

	void ChangeMenu()
	{
		GetComponentInParent<Canvas> ().gameObject.SetActive (false); //desactiva menu actual
		targetMenu.gameObject.SetActive (true); //activa menu objetivo
		text.color = initialColor;
	}
}
