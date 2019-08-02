using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Legs : MonoBehaviour 
{
	private PlayerController player;
	private CircleCollider2D coll;

	private float offset = 0.3f; //diferencia en altura entre enemy y player encima de él

	// Use this for initialization
	void Start () 
	{
		player = GetComponentInParent<PlayerController> ();	
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnCollisionEnter2D (Collision2D other)
	{
		if (other.gameObject.tag == "Platform") 
		{
			player.rb2d.velocity = Vector2.zero;
			player.transform.parent = other.gameObject.transform; //cuando está en suelo, es hijo de él (para que se mueva junto con él en plataformas móviles)
			player.grounded = true;
		}

		if (other.gameObject.tag == "Enemy")
		{	
			//si player está encima del enemigo, destruye el enemigo
			if ((player.transform.position.y - other.gameObject.transform.position.y) > offset) {
				GameObject.Destroy (other.gameObject);
				player.jumpForcePlayer = 3f;
				player.jump = true;
			} 
//			else 
//			{
//				player.spriteRend.color = Color.red;
//			}
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
