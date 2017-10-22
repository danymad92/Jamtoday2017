using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarObjectManager : MonoBehaviour {
    public Transform objectTransform;
    public GameObject objectPrefab;
	public GameObject arma;

	public Transform childArmaPosition;


	public bool IsObjectReady() {
		return arma != null;
    }

    public void ReleaseObject() {
		this.crearArma ();
    }

	private void crearArma() {
		if (ScoreManager.canCreateArma ()) {
			ScoreManager.resetItem ();
			GameObject e = (GameObject)Instantiate (arma);
			e.transform.position = this.childArmaPosition.position;
		}
	}
}
