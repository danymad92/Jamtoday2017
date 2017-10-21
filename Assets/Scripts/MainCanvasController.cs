using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainCanvasController : MonoBehaviour {
    private static MainCanvasController _instance;

    public Text scoreText;

    void Awake() {
        _instance = this;
    }

	public static void SetScore(int score) {
        _instance.scoreText.text = score.ToString("000000");
    }
}
