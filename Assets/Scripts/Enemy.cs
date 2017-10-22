using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FreakPool;

public class Enemy : MonoBehaviour, IPooleableObject {
	
	//public GameObject[] obstaculos;

	public Mesh[] obstaculos;

	public GameObject player;

	public int positionArrayEnemies;


	//public GameObject obstaculo;

	void Start()
	{
		this.GetComponent<MeshFilter>().mesh = obstaculos[Random.Range(0, obstaculos.Length)];
		//this.gameObject = obstaculos[Random.Range(0, obstaculos.Length)];
	}

	/// <summary>
	/// Generates an Enemy
	/// </summary>
	/// <returns> IPooleableObject to create </returns>
	public IPooleableObject Generate() {
		GameObject copy = Instantiate<GameObject>(this.gameObject, new Vector3(999999, 999999, 999999), Quaternion.Euler(new Vector3(0, 180, 0)));
		copy.SetActive(false);
		return copy.GetComponent<Enemy>();
	}

	/// <summary>
	/// Destroys the Enemy
	/// </summary>
	public void DestroyObject() {
		Destroy(this.gameObject);
	}

	void OnCollisionEnter(Collision other) {
        Debug.Log("Collision: " + other.gameObject.name);
		if (other.gameObject.CompareTag ("Player")) {
			Debug.Log ("Timescale = 0");
			Time.timeScale = 0;
            ScoreManager.game = false;
            // TODO Mostrar menú final de partida
            SoundManager.instance.engine.Stop();
            SoundManager.instance.carHit.Play();
		}
	}

    void OnTriggerEnter(Collider other) {

        Debug.Log("Collider: " + other.gameObject.name);
		if (other.CompareTag ("EnemyDesactive")) {
			Enemies.enemigos.Release (this);
			this.gameObject.SetActive (false);
		} else if (other.CompareTag ("Item")) {
			other.transform.position = this.transform.GetChild (0).position;
			Debug.Log ("Colisión item con valla");
		}
    }
}
