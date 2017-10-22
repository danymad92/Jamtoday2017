using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameCanvasController : MonoBehaviour {

	public Text socoreTextBox;

	// Use this for initialization
	void OnEnable () {
		socoreTextBox.text = "Score: " + ScoreManager.score;
	}

	public void GoToLevel(string level) {
		Debug.Log (level);
		Application.LoadLevel (level); 
	}

}
