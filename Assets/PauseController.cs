using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour {
    public static PauseController _instance;

    public static bool isPaused {
        get {
            return _instance._isPaused;
        }
    }

    private bool _isPaused;

    void Awake() {
        _instance = this;
        gameObject.SetActive(false);
    }

    void Start() {
        _isPaused = false;
    }

    public static void PauseGame() {
        _instance.Pause();
    }

    public void Pause() {
        if (isPaused) {
            Time.timeScale = 1;
            _isPaused = false;
            gameObject.SetActive(false);
        } else {
            Time.timeScale = 0;
            _isPaused = true;
            gameObject.SetActive(true);
        }
    }
}
