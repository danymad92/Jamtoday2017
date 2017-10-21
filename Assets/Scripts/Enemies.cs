using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FreakPool;

public class Enemies : MonoBehaviour {

	public static int TotalCreated;

	public static Pool<Enemy> enemigos;

	public GameObject enemy;

	public static int TotalDestroyed;

	public int numeroCarriles;

	private float anchoCarretera;

	private float anchoCarril;

	private float largoTramoCarretera;

	private float lastCreatedTime;



	void Start()
	{
		this.numeroCarriles = 5;
		this.anchoCarretera = 100;
		this.anchoCarril = this.anchoCarretera / this.numeroCarriles;
		this.largoTramoCarretera = 30;
		GameObject e = (GameObject) Instantiate (enemy);
		enemy.transform.position = new Vector3 (-1000, -1000, -1000);
		enemigos = new Pool<Enemy> (e.GetComponent<Enemy>());
		enemigos.SetSize (20);
		StartCoroutine (createEnemyRuntime());

	}
		
	void Update()
	{
		//if (Player.CurrentLife <= 0)
		//	return;

		//if (Time.time - lastCreatedTime > 10f)
			//CreateEnemy();
	}

	public IEnumerator createEnemyRuntime() {
		while (true) {
			this.CreateEnemy ();
			yield return new WaitForSeconds (0.5f);
		}
	}
		
	public void CreateEnemy()
	{
		GameObject player = GameObject.Find ("Cylinder");
		Vector3 initialPosition = new Vector3(Random.Range(- this.numeroCarriles / 2, this.numeroCarriles / 2) * 
			Random.Range(- this.anchoCarril / 2, this.anchoCarril / 2), 0, Random.Range(player.transform.position.z +30 ,
				player.transform.position.z + this.largoTramoCarretera +30));

		Enemy enemigo = enemigos.Take ();
		enemigo.gameObject.SetActive (true);
		enemigo.gameObject.transform.SetPositionAndRotation (initialPosition, Quaternion.Euler(new Vector3(0, 180, 0)));
		
		//lastCreatedTime = Time.time;
		Enemies.TotalCreated++;
	}


}
