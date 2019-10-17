using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour 
{
	private float health = 1f; //1f: salud completa, 0f: sin vida
	private int level;

	public float Health
	{
		get
		{
			return health;
		}
		set
		{
			if (value >= 0 && value <=1) 
			{
				health = value;
			}
		}
	}

	public int Level 
	{
		get
		{
			return level;
		}
		set
		{
			level = value;
		}
	}
}
