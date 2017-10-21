using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarManager : MonoBehaviour {
    private static CarManager _instance;

    public float movementSpeedValue = 1.0f;
    public float advanceSpeedValue = 1.0f;

    public static float movementSpeed {
        get {
            return _instance.movementSpeedValue;
        }
        set {
            _instance.movementSpeedValue = value;
        }
    }

    public static float forwardSpeed {
        get {
            return _instance.advanceSpeedValue;
        }
        set {
            _instance.advanceSpeedValue = value;
        }
    }

    void Awake() {
        _instance = this;
    }
}
