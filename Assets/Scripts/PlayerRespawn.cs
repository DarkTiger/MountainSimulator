using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PlayerRespawn : MonoBehaviour {


	public Transform respawnPoint;
	public GameObject respawnGroup;
	//private Transform[] respawns;
	private int respawnIndex = 0;

	private List<Transform> respawnList; 

	[HideInInspector]
	public Vector3 respawnPosition; 


	void Start() 
	{

		Transform[] respawns = respawnGroup.GetComponentsInChildren<Transform>();
		respawnList = new List<Transform>();
		
		
		foreach (Transform respawn in respawns) 
		{
			if (respawn != respawnGroup.transform)
			{
				respawnList.Add(respawn);
			}
		}


		//respawns = respawnGroup.GetComponentsInChildren<Transform>();

		respawnPosition = respawnList[respawnIndex].position;
		transform.position = respawnPoint.position;

	}


	void Update()
	{

		if (Input.GetKeyUp(KeyCode.PageUp))
		{
			if (respawnIndex < respawnList.Count - 1)
			{
				respawnIndex++;
			}
			else
			{
				respawnIndex = 0;
			}

			respawnPosition = respawnList[respawnIndex].position;
			transform.position = respawnPosition;
		}

		else if (Input.GetKeyUp(KeyCode.PageDown))
		{
			if (respawnIndex > 0)
			{
				respawnIndex--;
			}
			else
			{
				respawnIndex = respawnList.Count - 1;
			}
			
			respawnPosition = respawnList[respawnIndex].position;
			transform.position = respawnPosition;
		}
	}
	

}
