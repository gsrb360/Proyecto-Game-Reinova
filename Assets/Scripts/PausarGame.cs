using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausarGame : MonoBehaviour {

	public GameObject pausePanel;
	public GameObject gameOverPanel;
	public GameObject[] nivelCompletado;

	public void pausa(float x){
		if (x == 0f) {
			desactivar (pausePanel, true);
		} else {
			desactivar (pausePanel, false);
		}
		Time.timeScale = x;
	}

	public void gameOver(){		
		desactivar (gameOverPanel, true);
		Time.timeScale = 0;
	}

	public void completarNivel(int a){
		desactivar(nivelCompletado[a], true);
		Time.timeScale = 0;
	}

	public void desactivar(GameObject g, bool a){
		g.SetActive (a);

		foreach (Transform child in g.transform) {
			desactivar (child.gameObject, a);
		}
	}

	public void setTime(float x){
		Time.timeScale = x;
	}

}
