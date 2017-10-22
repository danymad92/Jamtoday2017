using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGeneratorController : MonoBehaviour {

	public GameObject[] trees;
	//public GameObject[] partesCamino;
	//public float generarCadaSegundos = 1.0f;

	public Vector3 posicion;
	public float tamanoTerrenoZ = 1.0f;

	//public int inicioTiempoPuente = 2;
	//public int finalTiempoPuente = 5;

	//public int inicioEsperaPuente = 10;
	//public int finalEsperaPuente = 20;

	//private float ultimoMomentoCreacion;
	//private int posicionActualCamino = 0;
	//private int posicionActualPuente = 0;

	//private bool hayPuentes = false;
	//private bool mostrandoPuente = false;
	//private float tiempoRestanteParaNuevoPuente;
	//private float duracionDelPuente;

	// Use this for initialization
	void Start () {
		if (trees.Length <= 0) {
			Debug.LogError ("Indica los árboles para generar el camino para usar el script");
		}

        // init trees
        //this.ultimoMomentoCreacion = Time.time;
        //this.posicionActualCamino = -1;
        for (int i = 0 ; i < trees.Length ; i++) {
            trees[i].SetActive(false);
        }

        // init puentes
        //this.hayPuentes = this.partesPuente.Length > 0;
        //if (this.hayPuentes) {
        //	this.duracionDelPuente = Time.time + (float)Random.Range(this.inicioTiempoPuente, this.finalTiempoPuente);
        //          this.tiempoRestanteParaNuevoPuente = Time.time + (float)Random.Range(this.inicioEsperaPuente, this.finalEsperaPuente);
        //	this.posicionActualPuente = -1;
        //	for (int i = 0; i < this.partesPuente.Length; i++) {
        //		this.partesPuente [i].SetActive (false);
        //	}
        //}
    }


	//private void generaPuente() {
	//	this.posicionActualPuente++;
	//	if (this.posicionActualPuente >= this.partesPuente.Length) {
	//		this.posicionActualPuente = 0;
	//	}

	//	this.ultimoMomentoCreacion = Time.time;
	//	this.partesPuente [this.posicionActualPuente].SetActive (true);
	//	this.partesPuente [this.posicionActualPuente].transform.position = this.posicion;
	//	this.posicion.z += this.tamanoTerrenoZ;
	//}

	//private void generaCamino() {
	//	this.posicionActualCamino++;
	//	if (this.posicionActualCamino >= this.partesCamino.Length) {
	//		this.posicionActualCamino = 0;
	//	}

	//	this.ultimoMomentoCreacion = Time.time;
	//	this.partesCamino [this.posicionActualCamino].SetActive (true);
	//	this.partesCamino [this.posicionActualCamino].transform.position = this.posicion;
	//	this.posicion.z += this.tamanoTerrenoZ;
	//}

	public void generar() {
        int treeIndex = Random.Range(0, trees.Length);
        if (!trees[treeIndex].activeSelf) {
            trees[treeIndex].SetActive(true);
            trees[treeIndex].transform.position = this.posicion;
        }
        posicion.z += this.tamanoTerrenoZ;


        //if (Time.time - this.ultimoMomentoCreacion < this.generarCadaSegundos) {
        //	return;
        //}

        //if (!this.hayPuentes) {
        //	this.generaCamino ();
        //	return;
        //}

        // verificamos que tenemos que mostrar

        //if (this.mostrandoPuente) {
        //	this.generaPuente ();

        //	if (Time.time >= this.duracionDelPuente) {
        //		this.mostrandoPuente = false;
        //		this.tiempoRestanteParaNuevoPuente = Time.time + (float) Random.Range (this.inicioEsperaPuente, this.finalEsperaPuente);
        //	}
        //} else {
        //	this.generaCamino ();

        //	if (Time.time >= this.tiempoRestanteParaNuevoPuente) {
        //		this.mostrandoPuente = true;
        //		this.duracionDelPuente = Time.time + (float) Random.Range (this.inicioTiempoPuente, this.finalTiempoPuente);
        //	}
        //}
    }

}
