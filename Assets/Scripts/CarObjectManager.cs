using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarObjectManager : MonoBehaviour {
    public Transform objectTransform;
    public GameObject objectPrefab;


	public bool IsObjectReady() {
        return false;
    }

    public void ReleaseObject() {
        Instantiate(objectPrefab, objectTransform.position, Quaternion.identity);
    }
}
