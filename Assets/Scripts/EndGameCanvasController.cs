using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameCanvasController : MonoBehaviour {
	public static EndGameCanvasController _instance;

	public Text socoreTextBox;

	void Awake() {
		_instance = this;
		gameObject.SetActive(false);
	}

	// Use this for initialization
	void OnEnable () {
		socoreTextBox.text = "Score: " + ScoreManager.score;
	}

	public void GoToLevel(string level) {
		Debug.Log (level);
		Application.LoadLevel (level); 
	}

	public void SetActive(bool active) {
		gameObject.SetActive (active);
	}

	public void QuitGame() {
		#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
		#else
			Application.Quit();
		#endif
	}

}
