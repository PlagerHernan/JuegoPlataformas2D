using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyController : MonoBehaviour 
{
	private PlayerController player;
	private CircleCollider2D coll;

	// Use this for initialization
	void Start () 
	{
		player = GetComponentInParent<PlayerController> ();	
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnCollisionStay2D (Collision2D other)
	{
		if (other.gameObject.tag == "Ground") 
		{
			player.transform.parent = other.gameObject.transform; //cuando está en suelo, es hijo de él (para que se mueva junto con él en plataformas móviles)
			player.grounded = true;
		}
	}
	void OnCollisionExit2D (Collision2D other)
	{
		if (other.gameObject.tag == "Ground") 
		{
			player.transform.parent = null; //cuando sale de suelo, ya no es hijo de nadie
			player.grounded = false;
		}
	}
}
