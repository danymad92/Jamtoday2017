using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {
    public bool available;
    public GameObject bulletPrefab;
    public Transform weaponTransform;

	// Use this for initialization
	void Start () {
        available = false;
	}

    public void Shoot() {
        
    }
}
