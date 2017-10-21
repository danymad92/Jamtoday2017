using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecycleIcon : MonoBehaviour {
    public float speedRotation;

    private RectTransform rectTrf;

    void Awake() {
        rectTrf = GetComponent<RectTransform>();
    }

    void OnEnable() {
        //rectTrf.rotation = Quaternion.Euler(0, 0, 0);
    }
	
	// Update is called once per frame
	//void Update () {
 //       rectTrf.rotation = Quaternion.Euler(0, 0, rectTrf.rotation.z + speedRotation * Time.deltaTime);
	//}
}
