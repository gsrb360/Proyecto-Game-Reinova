using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PasoDeNivel : MonoBehaviour {

	public Text texto;

	private int score;

	public float[] nivelScore = new float[3];

	void OnTriggerEnter2D(Collider2D c) {
		if (c.tag == "Player") {
			score = Int32.Parse (texto.text);
			Debug.Log ("" + score);
			if (score < nivelScore[0]) {
				GetComponent<PausarGame> ().completarNivel (0);
			}else if (score < nivelScore[1]) {
				GetComponent<PausarGame> ().completarNivel (1);
			}else if (score < nivelScore[2]) {
				GetComponent<PausarGame> ().completarNivel (2);
			}else {
				GetComponent<PausarGame> ().completarNivel (3);
			}
		}
	}
}
