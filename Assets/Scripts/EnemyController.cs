using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour 
{
	private Rigidbody2D rb2d; 

	public float force = 1f;
	public float maxSpeed = 1f;

	// Use this for initialization
	void Start () 
	{
		rb2d = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate () 
	{
		rb2d.AddForce (Vector2.right * force, ForceMode2D.Force);	

		//limita la velocidad (idem player)
		float limitedSpeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
		rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y);

		//si está casi detentido, cambia la dirección
		if (rb2d.velocity.x < 0.01f && rb2d.velocity.x > -0.01f) //si fuera == 0f demoraría (hasta que la velocidad llega a cero)
		{
			force = -force; //cambia el signo para cambiar la dirección
			rb2d.velocity = new Vector2 (force, rb2d.velocity.y);
		}

		//si va hacia la izquierda, hago rotacion para que mire hacia allá (idem player)
		if(rb2d.velocity.x < -0.1f) 
		{
			transform.localRotation = new Quaternion(0f, 0f, 0f, 0f); 
		}
		if(rb2d.velocity.x > 0.1f)
		{
			transform.localRotation = new Quaternion(0f, 180f, 0f, 0f); 
		}
	}
}
