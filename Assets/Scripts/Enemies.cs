﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FreakPool;

public class Enemies : MonoBehaviour {

	public static int TotalCreated;

	public static Pool<Enemy> enemigos;

	public GameObject enemy;

	public static int TotalDestroyed;

	public int numeroCarriles;

	public float anchoCarretera = 6;

	private float anchoCarril;

	public float largoTramoCarretera = 8;

	private float lastCreatedTime;

    public GameObject player;

	void Start()
	{

		this.anchoCarril = this.anchoCarretera / this.numeroCarriles;
		GameObject e = (GameObject) Instantiate (enemy);
		enemy.transform.position = new Vector3 (-1000, -1000, -1000);
		enemigos = new Pool<Enemy> (e.GetComponent<Enemy>());
		enemigos.SetSize (20);
        e.gameObject.SetActive(false);
		StartCoroutine (createEnemyRuntime());

	}

	public IEnumerator createEnemyRuntime() {
		while (true) {
			this.CreateEnemy ();
			yield return new WaitForSeconds (2.5f);
		}
	}
		
	public void CreateEnemy()
	{
		
		int carril = Random.Range (-1, 2);
		Vector3 initialPosition = new Vector3(
			carril * this.anchoCarril, 
			0, 
			Random.Range(player.transform.position.z +30, player.transform.position.z + this.largoTramoCarretera +30));

		Enemy enemigo = enemigos.Take ();
		enemigo.gameObject.SetActive (true);
		enemigo.gameObject.transform.SetPositionAndRotation (initialPosition, Quaternion.Euler(new Vector3(0, 180, 0)));
		
		//lastCreatedTime = Time.time;
		Enemies.TotalCreated++;
	}


}
