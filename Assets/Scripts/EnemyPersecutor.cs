using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPersecutor : MonoBehaviour 
{
	GameObject player;

	public float actionRadius; 
	public float maxDistanceDelta = 0.04f;
	public Vector3 guiPosition;
	Vector3 initialPosition;
	Animator animator;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		initialPosition = transform.position;
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (player != null) 
		{
			//si player entra en el radio, se mueve hacia player
			float distance = Vector3.Distance (player.transform.position, initialPosition);
			if (distance < actionRadius) 
			{
				transform.position = Vector3.MoveTowards (transform.position, player.transform.position, maxDistanceDelta * Time.deltaTime);
				animator.Play ("EnemyPersecutor_Walk");
			} 
			//si está en posicion inicial, se duerme
			else if (transform.position.x == initialPosition.x) 
			{
				animator.Play ("EnemyPersecutor_Sleep");
			}
			//si no, vuelve a posicion inicial (sólo en x, para evitar bug temblor)
			else
			{
				transform.position = Vector3.MoveTowards(transform.position, 
					new Vector3(initialPosition.x, transform.position.y, 0f), 
					(maxDistanceDelta - 1f)  * Time.deltaTime);
			}

			//si va hacia la izquierda, hago rotacion para que mire hacia allá 
			float direction = transform.position.x - player.transform.position.x;
			if (direction < 0f) 
			{
				transform.localRotation = new Quaternion(0f, 180f, 0f, 0f);
			}
			if (direction > 0f) 
			{
				transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player") 
		{
			float offset = 0.2f; //diferencia en altura entre enemy y player encima de él (para destruir enemy)
			//si player está encima del enemigo, destruye el enemigo
			if (col.transform.position.y >= transform.position.y + offset) 
			{ 
				GameObject.Destroy (gameObject);
				col.SendMessage ("JumpEnemy");
			} 
			//si no, se lastima player 
			else
			{
				col.SendMessage ("Shock", transform.position.x);
			}
		}
	}
		
	void OnDrawGizmos ()
	{
		//Gizmos.color = Color.cyan;
		//Gizmos.DrawWireSphere (transform.position, actionRadius);

		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere (guiPosition, actionRadius);
	}

//	[ ContextMenu("Rotar") ]
//	public void Rotar()
//	{
//		transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
//	}
//
//	[ ContextMenu("Rotar2") ]
//	public void Rotar2()
//	{
//		transform.localRotation = new Quaternion(0f, 180f, 0f, 0f);
//	}

}
