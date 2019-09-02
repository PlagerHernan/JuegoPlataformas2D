using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; 

public class ButtonPause : MonoBehaviour, IPointerDownHandler, IPointerUpHandler  
{
	public Pause scriptPause;
	public bool boolpause;

	public void OnPointerDown  (PointerEventData evenData)
	{
	}

	public void OnPointerUp  (PointerEventData evenData)
	{
		scriptPause.pause = boolpause;
	}
}
