using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour 
{
	private Rigidbody2D rigid; 
	private EdgeCollider2D col;
	private Vector3 initialPosition;

	// Use this for initialization
	void Start () 
	{
		rigid = GetComponent<Rigidbody2D> ();
		initialPosition = transform.position; 
		col = GetComponent<EdgeCollider2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Player") 
		{
			Invoke ("Falling", 0.5f);
			Invoke("Reappear", 4f);
		}
	}

	void Falling()
	{
		rigid.bodyType = RigidbodyType2D.Dynamic; //ahora es dinámico, por tanto le afecta la gravedad y cae
		col.isTrigger = true; //ahora es Trigger, por tanto no le afectan las colisiones (evita bug quedarse rotando o encajado en la piedra y el piso)
	}

	void Reappear()
	{
		rigid.bodyType = RigidbodyType2D.Kinematic; 
		rigid.velocity = Vector3.zero;
		transform.position = initialPosition;
		col.isTrigger = false;
	}
}
