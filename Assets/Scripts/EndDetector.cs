using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDetector : MonoBehaviour {

    private BoxGeneratorController boxGenerator;

    void Awake() {
        boxGenerator = GameObject.FindGameObjectWithTag("GameController").GetComponent<BoxGeneratorController>();
    }


    private void OnTriggerEnter(Collider other) {

        if (other.CompareTag("Player")) {
            if (other.GetComponent<CarController>().playerNumber.Equals(PLAYER_NUMBER.TWO)) {
                boxGenerator.generar();
            }
        }

    }
}
