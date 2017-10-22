using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FreakPool;

public class Item : MonoBehaviour, IPooleableObject {
	
	//public GameObject[] obstaculos;

	public Mesh[] items;
	public Material[] materials;
	//public GameObject obstaculo;

	void Start()
	{
		int value = Random.Range (0, items.Length);
		this.GetComponent<MeshFilter>().mesh = items[value];
		this.GetComponent<MeshRenderer>().material = materials[value];
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
        if (other.CompareTag("EnemyDesactive")) {
			Items.items.Release(this);
            this.gameObject.SetActive(false);
		}
    }
}
