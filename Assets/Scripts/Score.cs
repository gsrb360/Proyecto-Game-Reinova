using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	private int score;
	public Text texto;

	public GameObject[] basuras;
	// Use this for initialization
	void Start () {
		score = 0;
	}

	public void aumentarScore(int s){
		score += s;
		Refrescar ();
	}

	private void Refrescar(){
		string a = "" + score;
		int c = a.Length;
		for (int i = 0; i < 10-c; i++) {
			a = "0" + a;
		}
		texto.text = a;
	}

	public void recolectarBasura(){
		for (int i = 0; i < basuras.Length; i++) {
			if (basuras[i] != null) {
				basuras [i].GetComponent<Basura> ().destruir ();
			}
		}
	}
}
