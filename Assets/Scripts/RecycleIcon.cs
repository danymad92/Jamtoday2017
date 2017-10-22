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

    void Update() {
        rectTrf.Rotate(0, 0, speedRotation);
    }
}
