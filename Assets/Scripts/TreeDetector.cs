using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeDetector : MonoBehaviour {

    private void OnTriggerEnter(Collider other) {
		//Debug.Log("tag: " + other.tag);
        if (other.CompareTag("Tree")) {
			//Debug.Log("tree");
            other.gameObject.SetActive(false);
        }

    }
}
