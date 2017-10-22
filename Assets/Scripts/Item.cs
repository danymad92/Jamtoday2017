using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FreakPool;

public class Item : MonoBehaviour, IPooleableObject {
	
	//public GameObject[] obstaculos;

	public Mesh[] items;

	//public GameObject obstaculo;

	void Start()
	{
		this.GetComponent<MeshFilter>().mesh = items[Random.Range(0, items.Length)];
		//this.gameObject = obstaculos[Random.Range(0, obstaculos.Length)];
	}

	/// <summary>
	/// Generates an Item
	/// </summary>
	/// <returns> IPooleableObject to create </returns>
	public IPooleableObject Generate() {
		GameObject copy = Instantiate<GameObject>(this.gameObject, new Vector3(999999, 999999, 999999), Quaternion.Euler(new Vector3(-90, 0, 0)));
		copy.SetActive(false);
		return copy.GetComponent<Item>();
	}

	/// <summary>
	/// Destroys the Item
	/// </summary>
	public void DestroyObject() {
		Destroy(this.gameObject);
	}

    void OnTriggerEnter(Collider other) {
        Debug.Log(other.gameObject.name);
        if (other.CompareTag("EnemyDesactive")) {
			Items.items.Release(this);
            this.gameObject.SetActive(false);
		}
    }
}
