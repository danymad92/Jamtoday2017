using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CurvesController : MonoBehaviour {

	public Vector4 offset;
	public float maxOffsetX = 100.0f;
	public float changeOffsetXOdds = 5.0f;
	public float deltaCurve = 0.3f;


	private float dir = 0.0f;
	private float updateTime;

	public Material[] materials;


	// Use this for initialization
	void Start () {
		Debug.Log("Vaya dos imbeciles... Suerte capullos! :)");
	}

	void OnEnable () {
	}

	void OnDisable() {
	}

	public void EnableCurves() {
		Debug.Log ("Curves Enabled");
		UnityEngine.Random.seed = (int)System.DateTime.Now.Ticks;

		for (int i = 0; i < materials.Length; i++) {
			materials [i].SetVector ("_QOffset", Vector4.zero);
		}

		StartCoroutine (ChangeCurve ());
	}

	public void DisableCurves() {
		Debug.Log ("Curves Disabled");

		for (int i = 0; i < materials.Length; i++) {
			materials [i].SetVector ("_QOffset", Vector4.zero);
		}

		StopCoroutine (ChangeCurve ());

	}

	IEnumerator ChangeCurve () {
		Debug.Log ("Change Curve");
		while (true) {
				//Si el juego está parado

				if ((Mathf.Abs (offset.x - (maxOffsetX * dir)) < 5.0f) &&
				( UnityEngine.Random.Range(0.0f,100.0f) < changeOffsetXOdds)) {
					dir = UnityEngine.Random.Range (-2.0f, 2.0f);//-1,0,1
				}

				// Update curve towards direction
				float newDir = maxOffsetX * dir;
				if (offset.x + deltaCurve < newDir) {
                    Debug.Log("Abajo");
					offset.x += deltaCurve;
                    offset.y -= deltaCurve;
				} else if (offset.x - deltaCurve > newDir) {
                    Debug.Log("Arriba");
                    offset.x -= deltaCurve;
                    offset.y += deltaCurve;
                    if (offset.y >= 0) {
                            offset.y = 0;
                        }
                    }

				if (Time.time - updateTime > 0.1f) {

					updateTime = Time.time;
					for (int i = 0; i < materials.Length; i++) {
						materials [i].SetVector ("_QOffset", offset);
					}
				}

			if (Time.timeScale == 0) { 				
				yield return new WaitForFixedUpdate (); 			
			}
			yield return new WaitForSeconds (0.1f);
			if (Time.timeScale == 0) { 				
				yield return new WaitForFixedUpdate (); 			
			}
		}
	}

	void OnApplicationQuit(){
		for (int i = 0; i < materials.Length; i++) {
			materials [i].SetVector ("_QOffset", Vector4.zero);
		}
	}
}
