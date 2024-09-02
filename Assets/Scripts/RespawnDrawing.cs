using UnityEngine;
using System.Collections;

public class RespawnDrawing : MonoBehaviour {


	public Color colore = Color.white; 



	void Update()
	{

	}


	void OnDrawGizmos() 
	{
		Vector3 lineUpStop = transform.position;
		lineUpStop.y = 500;


		Gizmos.color = colore;
		Gizmos.DrawWireSphere(transform.position, 0.5f);

		Gizmos.DrawLine(transform.position, lineUpStop); 
	}
}
