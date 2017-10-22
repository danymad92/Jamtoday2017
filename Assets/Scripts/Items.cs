using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FreakPool;

public class Items : MonoBehaviour {

	public static int TotalCreated;

	public static Pool<Item> items;

	public GameObject item;

	public static int TotalDestroyed;

	public int numeroCarriles;

	public float anchoCarretera = 6;

	private float anchoCarril;

	private float centroCarrilIzquierda;

	public float largoTramoCarretera = 8;

	private float lastCreatedTime;

    public GameObject player;

	void Start()
	{

		this.anchoCarril = this.anchoCarretera / this.numeroCarriles;
		GameObject e = (GameObject) Instantiate (this.item);
		item.transform.position = new Vector3 (-1000, -1000, -1000);
		items = new Pool<Item> (e.GetComponent<Item>());
		items.SetSize (20);
		StartCoroutine (createItemRuntime());

	}

	public IEnumerator createItemRuntime() {
		while (true) {
			this.CreateItem ();
			yield return new WaitForSeconds (3.5f);
		}
	}
		
	public void CreateItem()
	{
		int carril = Random.Range (-1, 2);
		Vector3 initialPosition = new Vector3(
			carril * this.anchoCarril, 
			0, 
			Random.Range(player.transform.position.z +30, player.transform.position.z + this.largoTramoCarretera +30));

		Item item = items.Take ();
		item.gameObject.SetActive (true);
		item.gameObject.transform.SetPositionAndRotation (initialPosition, Quaternion.Euler(new Vector3(-90, 0, 0)));
		
		//lastCreatedTime = Time.time;
		Items.TotalCreated++;
	}


}
