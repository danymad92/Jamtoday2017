using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {
    public bool game;
    public int pointsPerSecond;

    private int score;
	// Use this for initialization
	void Start () {
        game = true;
        score = 0;
        StartCoroutine(ScoreControl());
    }

	public IEnumerator ScoreControl () {
        WaitForSeconds wfs = new WaitForSeconds(1/pointsPerSecond);
		while (game) {
            ++score;
            MainCanvasController.SetScore(score);
            yield return wfs;
        }
	}
}
