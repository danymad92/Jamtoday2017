using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelRotate : MonoBehaviour {

    private WaitForSeconds wait;

    public float speed = 0.1f;

	// Use this for initialization
	void Start () {

        wait = new WaitForSeconds(0.01f);

        StartCoroutine(RotateWheel());
	}
	
    IEnumerator RotateWheel() {

        while (true) {
            yield return wait;

            transform.Rotate(Vector3.left * speed);
        }

    }

}
