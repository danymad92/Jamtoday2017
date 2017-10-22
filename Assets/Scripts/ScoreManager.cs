using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {
    public bool game;
    public int pointsPerSecond;

    private int score;

	private static int items;
	// Use this for initialization
	void Start () {
        game = true;
        score = 0;
        StartCoroutine(ScoreControl());
		ScoreManager.items = 0;
    }

	public IEnumerator ScoreControl () {
        WaitForSeconds wfs = new WaitForSeconds(1/pointsPerSecond);
		while (game) {
            ++score;
            MainCanvasController.SetScore(score);
            yield return wfs;
        }
	}

	public static int getItems() {
		return ScoreManager.items;
	}

	public static void setItems(int items) {
		ScoreManager.items = items;
	}

	public static void resetItem() {
		ScoreManager.items = 0;
	}

	public static void addItem() {
		if (ScoreManager.items < 3) {
			++ScoreManager.items;
		}
	}

	public static bool canCreateArma() {
		return ScoreManager.items >= 3;
	}
}
