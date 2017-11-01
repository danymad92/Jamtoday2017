using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FreakPool;

public class Items : MonoBehaviour {

	public static int TotalCreated;

	public static Pool<Item>[] poolsItem;

	public GameObject[] items;

	public Vector3[] itemScale;

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
		Items.poolsItem = new Pool<Item>[this.items.Length];
		for (int i = 0; i < items.Length; i++) {
			GameObject e = (GameObject) Instantiate (this.items[i]);
			items[i].transform.position = new Vector3 (-1000, -1000, -1000);
			items[i].transform.localScale = this.itemScale [i];
			Items.poolsItem[i] = new Pool<Item> (e.GetComponent<Item>());
			Items.poolsItem[i].SetSize (20);
		}
		StartCoroutine (createItemRuntime());
	}

	public IEnumerator createItemRuntime() {
		while (true) {
			int value = Random.Range (0, this.items.Length);
			this.CreateItem (value);
			yield return new WaitForSeconds (3.5f);
		}
	}
		
	public void CreateItem(int valuePool)
	{
		int carril = Random.Range (-1, 2);
		Item item = Items.poolsItem[valuePool].Take();
		float positiony = 0f;
		if (item.position == 0) {
			positiony = 0.354f;
		}
		Vector3 initialPosition = new Vector3(
			carril * this.anchoCarril, 
			0 + positiony, 
			Random.Range(player.transform.position.z +30, player.transform.position.z + this.largoTramoCarretera +30));
		
		item.gameObject.SetActive (true);
		item.gameObject.transform.SetPositionAndRotation (initialPosition, Quaternion.Euler(new Vector3(-90, 0, 0)));
		
		//lastCreatedTime = Time.time;
		Items.TotalCreated++;
	}


}
