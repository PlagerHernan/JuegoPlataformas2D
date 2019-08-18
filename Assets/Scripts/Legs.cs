using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Legs : MonoBehaviour 
{
	private PlayerController player;
	private CircleCollider2D coll;
	Rigidbody2D rb2dPlayer;

	// Use this for initialization
	void Start () 
	{
		player = GetComponentInParent<PlayerController> ();	
		rb2dPlayer = GetComponentInParent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnCollisionEnter2D (Collision2D other)
	{
		if (other.gameObject.tag == "Platform") 
		{
			rb2dPlayer.velocity = Vector2.zero;
			player.transform.parent = other.gameObject.transform; //cuando está en suelo, es hijo de él (para que se mueva junto con él en plataformas móviles)
			player.grounded = true;
		}
	}

	void OnCollisionStay2D (Collision2D other)
	{
		if (other.gameObject.tag == "Ground") 
		{
			player.grounded = true;
		}
	}

	void OnCollisionExit2D (Collision2D other)
	{
		if (other.gameObject.tag == "Ground") 
		{
			player.grounded = false;
		}

		if (other.gameObject.tag == "Platform") 
		{
			player.transform.parent = null; //cuando sale, ya no es hijo de nadie
			player.grounded = false;
		}
	}
}
