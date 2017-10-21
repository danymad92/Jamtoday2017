using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	
	public float Speed;

	void Start()
	{
		Speed = 4;
	}
		
	void Update()
	{
		CheckMovement();
	}

	/// <summary>
	/// Comprueba el movimiento de la nave
	/// </summary>
	private void CheckMovement()
	{
		this.transform.Translate(0, 0, Speed * Time.deltaTime);

		//if (this.transform.position.y <= -25)
			//Destroy(this.gameObject);
	}
}
