using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlatform : MonoBehaviour 
{
	public Transform target;
	public PlayerController player;

	private Vector3 from;
	private bool boolTarget;

	// Use this for initialization
	void Start () 
	{
		from = transform.position;
		target.parent = null; //target ya no es hijo de platform, para que no se mueva junto con él 
	}

	void Update () 
	{
		if (transform.position == from || !boolTarget) //si está en posicion de origen o viene de allí, se moverá a target 
		{
			transform.position = Vector3.MoveTowards (transform.position, target.position, 2f * Time.deltaTime);
			boolTarget = false;
		}
		if (transform.position == target.position || boolTarget) //si está en target o viene de allí, se moverá a posición de origen
		{
			transform.position = Vector3.MoveTowards (transform.position, from, 2f * Time.deltaTime); 
			boolTarget = true;
		}
	}
}
