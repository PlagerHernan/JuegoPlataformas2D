using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDOL : MonoBehaviour 
{
	public static DDOL instance = null;

	void Awake()
	{
		//si es la 1ra instancia, la conserva
		if (instance == null) 
		{
			instance = this;
		}
		//si ya hay una instancia creada y es distinta a esta, la destruye (para que no haya repetidas)
		else if (instance != this) 
		{
			Destroy (gameObject);
		}
		//no se destruye al cambiar de escena
		DontDestroyOnLoad (this);
	}
}
