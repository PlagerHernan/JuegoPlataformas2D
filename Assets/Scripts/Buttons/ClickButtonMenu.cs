using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; 
using UnityEngine.UI;

public class ClickButtonMenu : MonoBehaviour, IPointerDownHandler, IPointerUpHandler  
{
	public Canvas targetMenu;

	public void OnPointerDown  (PointerEventData evenData)
	{
		GetComponentInChildren<Text> ().fontSize = 37;
	}

	public void OnPointerUp  (PointerEventData evenData)
	{
		Invoke ("ChangeMenu", 0.15f);
	}

	void ChangeMenu()
	{
		GetComponentInParent<Canvas> ().gameObject.SetActive (false); //desactiva menu actual
		targetMenu.gameObject.SetActive (true); //activa menu objetivo
		GetComponentInChildren<Text> ().fontSize = 30;
	}
}
