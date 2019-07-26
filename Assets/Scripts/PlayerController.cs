using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
	private Rigidbody2D rb2d; 
	private Animator animator;

	public float speed = 75f;
	public float maxSpeed = 3f;

	// Use this for initialization
	void Start () 
	{
		rb2d = GetComponent<Rigidbody2D> ();	
		animator = GetComponent<Animator> ();
	}
	
	 //Update is called once per frame
	void Update ()
	{
		animator.SetFloat ("speed", Mathf.Abs(rb2d.velocity.x)); //Mathf.Abs(): devuelve float sin signo (valor absoluto, no importa si es positivo o negativo)
	}

	void FixedUpdate()
	{
		float x_velocity = Input.GetAxis ("Horizontal");
		//Debug.Log (x_velocity);

		//rb2d.velocity = new Vector2 (x_velocity * speed, rb2d.velocity.y);

		rb2d.AddForce (Vector2.right * speed * x_velocity); 

		//limito la velocidad 
		//modo A
//		if (rb2d.velocity.x > maxSpeed) 
//		{
//			rb2d.velocity = new Vector2 (maxSpeed, rb2d.velocity.y);
//		}
//		if (rb2d.velocity.x < -maxSpeed) 
//		{
//			rb2d.velocity = new Vector2 (-maxSpeed, rb2d.velocity.y);
//		}
		//modo B (refactorizado)
		float limitedSpeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
		rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y);

		Debug.Log(rb2d.velocity);

		//si va hacia la izquierda, hago rotacion para que mire hacia allá
		if(rb2d.velocity.x < -0.1f) 
		{
			transform.localRotation = new Quaternion(0f, 180f, 0f, 0f); 
		}
		if(rb2d.velocity.x > 0.1f) //if (Mathf.) 
		{
			transform.localRotation = new Quaternion(0f, 0f, 0f, 0f); 
		}
	}
}
