using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{	
	public GameObject game;
	public SimpleTouchController leftController;
	public InteractiveElement buttonJump;

	Rigidbody2D rb2d; 
	Animator animator;
	ParticleSystem dust;

	public float speed = 75f;
	public float maxSpeed = 3f;
	public bool grounded;
	public float jumpForcePlayer = 9.5f;
	public bool jump;
	private float health = 1f; //1f: salud completa, 0f: sin vida
	//private Color color;
	private bool movement = true;

	// Use this for initialization
	void Start () 
	{
		rb2d = GetComponent<Rigidbody2D> ();	
		animator = GetComponent<Animator> ();
		//color = new Color (246 / 255f, 97 / 255f, 11 / 255f); //color anaranjado (alternativa para shock)
		dust = GetComponentInChildren<ParticleSystem>();
	}
	
	 //Update is called once per frame
	void Update ()
	{
		//SET ANIMATOR PARAMETERS
		animator.SetFloat ("speed", Mathf.Abs(rb2d.velocity.x)); //Mathf.Abs(): devuelve float sin signo (valor absoluto, no importa si es positivo o negativo)

		if (grounded) 
		{
			animator.SetBool("grounded", true);
		} 
		else
		{
			animator.SetBool("grounded", false);
		}

		bool userJump = Input.GetKeyDown(KeyCode.UpArrow) || buttonJump.click;

		if (userJump && grounded) 
		{
			jumpForcePlayer = 9.5f;
			jump = true; //se concreta luego en FixedUpdate()
		}

		//si se mueve hacia la izquierda
		if(rb2d.velocity.x < -0.1f) 
		{
			transform.localRotation = new Quaternion(0f, 180f, 0f, 0f); 
		}
		//si se mueve hacia la derecha
		else if(rb2d.velocity.x > 0.1f)
		{
			transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
		}
	}

	void FixedUpdate()
	{
		//fricción artificial, para que no se deslice indefinidamente (plataformas tienen physicsMaterial Deslizante, para no quedar enganchado en paredes)
		float fixedVelocity = rb2d.velocity.x;
		if (grounded) 
		{
			fixedVelocity *= 0.75f;
			rb2d.velocity = new Vector2 (fixedVelocity, rb2d.velocity.y);
		}

		//TECLADO
		float x_velocity = Input.GetAxis ("Horizontal");

		//TACTIL (JOYSTICK)
		//float x_velocity = leftController.GetTouchPosition.x;

		if (!movement) 
		{
			x_velocity = 0f;
		}

		//agrega fuerza para correr
		rb2d.AddForce (Vector2.right * speed * x_velocity); 

		//limita la velocidad 
		float limitedSpeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
		rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y);

		if (jump) 
		{
			Jump (jumpForcePlayer);
		}
	}

	public void Jump(float jumpForce)
	{
		rb2d.velocity = new Vector2 (rb2d.velocity.x, 0f); //antes de agregar fuerza, me aseguro que la velocidad vertical sea cero, para no añadir impulso al impulso (evitar doble salto)
		rb2d.AddForce (Vector2.up * jumpForcePlayer, ForceMode2D.Impulse);	
		jump = false;
	}

	public void JumpEnemy()
	{
		jumpForcePlayer = 3f; //salto pequeño
		jump = true;
	}

	void Shock(float positionEnemy)
	{
		//spriteRend.color = color; 
		animator.Play ("Player_Shock");
		movement = false; 
		jump = true;

		float side = Mathf.Sign (positionEnemy - transform.position.x); //si player está a la izquierda de enemy retorna 1, si está a la derecha retorna -1
		rb2d.AddForce (Vector2.left * side * jumpForcePlayer, ForceMode2D.Impulse); //salto hacia atrás y al costado

		health = Mathf.Clamp (health - 0.25f, 0f, 1f); 
		game.SendMessage ("Damage", health);
	}
	void Unshock() //llamado desde evento en Player_Shock.anim
	{
		//spriteRend.color = Color.white; //transparente (color original)
		movement = true;
	}

	//cuando cae y ya no está visible en la escena
	void OnBecameInvisible()
	{
		health = 0f;
		game.SendMessage ("Damage", health);
	}

	[ ContextMenu("PlayDust") ]
	public void PlayDust()
	{
		dust.Play ();
	} 

	[ ContextMenu("StopDust") ]
	public void StopDust()
	{
		dust.Stop();
	} 

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.name == "Flag") 
		{
			game.SendMessage ("NextLevel");
		}
	}
}
