using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class StepControl : MonoBehaviour {


	[HideInInspector]
	public float fatigueValue = 0;

	public float staminaValue = 480; 

	public GameObject waterObject; 
	public AudioSource AudioSourceStep;
	public AudioClip terrainStepSound;
	public AudioClip swimmingSound;

	Vector3 lastPosition = Vector3.zero;
	float speed;
	float stepSpeed;
	//public AudioClip waterStepSound;
	//public GameObject waterSwimParticles;



	void Start()
	{

	}


	void FixedUpdate()
	{
		speed = 0;
		speed = (transform.position - lastPosition).magnitude;
		lastPosition = transform.position;
		stepSpeed = Mathf.Round(speed * 1000);
	}


	void Update() 
	{
		StepSound();
		FatigueCalculation();
		WaterSwim();
		StaminaControl();
	}


	void StepSound()
	{
		RaycastHit hit;
		
		if (Physics.Raycast(transform.position, -transform.up, out hit, 25))
		{
			if (hit.transform.tag == "Terrain")
			{
				AudioSourceStep.clip = terrainStepSound;
								
				if (stepSpeed > 4)
				{
					if (audio.volume < 1)
					{
						audio.volume += 0.1f;
					}

					if (!audio.isPlaying && (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0))
					{
						audio.Play();
					}
				}
				else
				{
					audio.volume -= 0.02f;
					if (audio.volume <= 0.01f)
					{
						audio.Stop();
					}
				}

				//waterSwimParticles.particleEmitter.emit = false;
			}
			/*else if (hit.transform.tag == "Water" && hit.transform.tag == "Terrain")
			{
				AudioSourceStep.clip = waterStepSound;
				
				if (!audio.isPlaying)
				{
					audio.Play();
				}
			}*/

			else if (hit.transform.tag == "Water")
			{
				AudioSourceStep.clip = swimmingSound;

				if (stepSpeed > 2)
				{
					if (audio.volume < 1)
					{
						audio.volume += 0.1f;
					}
					
					if (!audio.isPlaying)
					{
						audio.Play();
					}

					//waterSwimParticles.particleEmitter.emit = true;
				}
				else
				{
					audio.volume -= 0.02f;
					if (audio.volume <= 0.01f)
					{
						audio.Stop();
					}

					//waterSwimParticles.particleEmitter.emit = false;
				}
			}

			else
			{
				audio.Stop();

				//waterSwimParticles.particleEmitter.emit = false;
			}
		}
	}


	void WaterSwim()
	{
		/*RaycastHit hit;
		
		if (Physics.Raycast(transform.position, -transform.up, out hit, 25))
		{
			//Debug.Log(hit.transform.tag);
			if (hit.transform.tag == "Water")
			{
				waterSwimParticles.particleEmitter.emit = true;
			}
			else
			{
				waterSwimParticles.particleEmitter.emit = false;
			}
		}*/
	}


	void FatigueCalculation()
	{
		if (stepSpeed < 40 && stepSpeed > 4)
		{
			fatigueValue = (40 - stepSpeed) * 5;
		}
		else
		{
			fatigueValue = 0;
		}
	}


	/*void ChangePhysicMode()
	{
		if (Input.GetKey(KeyCode.E))
		{
			
			if (gravityEnabled)
			{
				gravityEnabled = false;
			}
			else
			{
				gravityEnabled = true;
			}
		}
		
		
		if (gravityEnabled)
		{
			//rigidbody.useGravity = true;
		}
		else
		{
			//rigidbody.useGravity = false;
		}
	}*/


	void StaminaControl()
	{
		if (Input.GetKey(KeyCode.LeftShift))
		{
			if (staminaValue > 0)
			{
				staminaValue -= 1f;
			}
			else
			{
				if (staminaValue < 479)
				{
					staminaValue += 0.1f;
				}
			}
		}
		else
		{
			if (staminaValue < 479)
			{
				staminaValue += 0.1f;
			}
		}
	}

}
