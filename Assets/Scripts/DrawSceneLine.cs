using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawSceneLine : MonoBehaviour 
{
	public Transform towards;

	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.cyan;
		Gizmos.DrawSphere (transform.position, 0.3f); 
		Gizmos.DrawLine(transform.position, towards.position); 
	}
}
