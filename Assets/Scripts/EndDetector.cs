using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDetector : MonoBehaviour {

    private BoxGeneratorController boxGenerator;
    private TreeGeneratorController treeGenerator;

    void Awake() {
        boxGenerator = GameObject.FindGameObjectWithTag("GameController").GetComponent<BoxGeneratorController>();
        treeGenerator = GameObject.FindGameObjectWithTag("GameController").GetComponent<TreeGeneratorController>();
    }


    private void OnTriggerEnter(Collider other) {
        Debug.Log("tag: " + other.tag);
        if (other.CompareTag("Player")) {
            if (other.GetComponent<CarController>().playerNumber.Equals(PLAYER_NUMBER.TWO)) {
                boxGenerator.generar();
                treeGenerator.generar();
            }
        }
        if (other.CompareTag("Tree")) {
            Debug.Log("tree");
            other.gameObject.SetActive(false);
        }

    }
}
