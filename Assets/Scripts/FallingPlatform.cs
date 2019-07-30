using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour 
{
	private Rigidbody2D rigid; 
	private Vector3 initialPosition;

	// Use this for initialization
	void Start () 
	{
		rigid = GetComponent<Rigidbody2D> ();
		initialPosition = transform.position; 
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Player") 
		{
			Invoke ("Falling", 1f);
			Invoke("Reappear", 4f);
		}
	}

	void Falling()
	{
		rigid.bodyType = RigidbodyType2D.Dynamic;
	}

	void Reappear()
	{
		rigid.bodyType = RigidbodyType2D.Kinematic;
		rigid.velocity = Vector2.zero;
		transform.position = initialPosition;
	}
}
