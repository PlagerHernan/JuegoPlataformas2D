using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyController : MonoBehaviour 
{
	private CircleCollider2D coll;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnCollisionStay2D (Collision2D other)
	{
		if (other.gameObject.tag == "Ground") 
		{
			GetComponentInParent<PlayerController> ().grounded = true;
		}
	}
	void OnCollisionExit2D (Collision2D other)
	{
		if (other.gameObject.tag == "Ground") 
		{
			GetComponentInParent<PlayerController> ().grounded = false;
		}
	}
}
