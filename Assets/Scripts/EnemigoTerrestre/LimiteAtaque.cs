using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimiteAtaque : MonoBehaviour {

	public GameObject enemigo;

	void OnTriggerEnter2D(Collider2D c) {
		if (c.tag == "Player") {
			enemigo.GetComponent<EnemyTerrestreMoving> ().setAtacando (true);
		}
	}

	void OnTriggerStay2D(Collider2D c) {
		if (c.tag == "Player") {
			enemigo.GetComponent<EnemyTerrestreMoving> ().setAtacando (true);
		}
	}

	void OnTriggerExit2D(Collider2D c) {
		if (c.tag == "Player") {
			enemigo.GetComponent<EnemyTerrestreMoving> ().setAtacando (false);
		}
	}
}
