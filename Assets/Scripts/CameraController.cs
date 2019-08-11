using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour 
{
	public PlayerController player;
	public float smoothTime = 0.3f; 

	public RawImage background;
	public float parallaxSpeed = 0.03f;

	public Vector2 minPosition;
	public Vector2 maxPosition;
	private Vector2 velocity;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		float smoothX = Mathf.SmoothDamp (transform.position.x, player.transform.position.x, ref velocity.x, smoothTime); 
		float smoothY = Mathf.SmoothDamp (transform.position.y, player.transform.position.y, ref velocity.y, smoothTime);

		//con limites
		transform.position = new Vector3 (Mathf.Clamp(smoothX, minPosition.x, maxPosition.x),
											Mathf.Clamp(smoothY, minPosition.y, maxPosition.y),
												gameObject.transform.position.z);

		//sin limites
		//transform.position = new Vector3(smoothX, smoothY, transform.position.z);

		//movimiento fondo
		background.uvRect = new Rect (transform.position.x * parallaxSpeed, 0f, 1f, 1f);

		 
	}
}
