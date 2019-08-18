using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; 

public class InteractiveElement : MonoBehaviour, IPointerDownHandler, IPointerUpHandler  
{
	public bool click = false;

	public void OnPointerDown  (PointerEventData evenData)
	{
		click = true;
	}

	public void OnPointerUp  (PointerEventData evenData)
	{
		click = false;
	}
}
