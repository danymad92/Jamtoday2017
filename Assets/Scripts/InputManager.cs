using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {
    public CarController car1;
    public CarController car2;
	
	// Update is called once per frame
	void Update () {
        // Car 1
        if (Input.GetKey(KeyCode.A)) {
            // Car1 Left
            car1.MoveTo(Vector3.left);
        } else if (Input.GetKey(KeyCode.D)) {
            // Car1 Right
            car1.MoveTo(Vector3.right);
        } else if (Input.GetKeyDown(KeyCode.W)) {
            // Car1 Shoot
            car1.Shoot();
        } else if (Input.GetKeyDown(KeyCode.S)) {
            // Car1 Object
            car1.ReleaseObject();
        }
        // Car 2
        if (Input.GetKey(KeyCode.LeftArrow)) {
            // Car2 Left
            car2.MoveTo(Vector3.left);
        } else if (Input.GetKey(KeyCode.RightArrow)) {
            // Car2 Right
            car2.MoveTo(Vector3.right);
        } else if (Input.GetKeyDown(KeyCode.UpArrow)) {
            // Car2 Shoot
            car2.Shoot();
        } else if (Input.GetKeyDown(KeyCode.DownArrow)) {
            // Car2 Object
            car2.ReleaseObject();
        }
        // Pause
        if (Input.GetKeyDown(KeyCode.Escape)) {
            PauseController.PauseGame();
        }
    }


}
