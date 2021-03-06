﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarObjectManager : MonoBehaviour {
    public Transform objectTransform;
    public GameObject objectPrefab;

	public bool IsObjectReady() {
		return objectPrefab != null;
    }

    public void ReleaseObject() {
		this.crearArma ();
    }

	private void crearArma() {
		if (ScoreManager.canCreateArma ()) {
			CarCanvasController carCanvasController = GetComponentInChildren<CarCanvasController> ();
            carCanvasController.weaponIcon.SetActive(false);
			carCanvasController.ActivateTrashCount ();
			ScoreManager.resetItem ();
			GameObject e = (GameObject)Instantiate (objectPrefab);
			e.transform.position = this.objectTransform.position;
		}
	}
}
