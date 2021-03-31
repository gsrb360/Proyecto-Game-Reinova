using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorEnemyGrande1_Lv1 : MonoBehaviour {

	public GameObject enemy;
	// Use this for initialization


	void OnTriggerEnter2D(Collider2D c) {
		if(c.tag == "Player"){
			enemy.GetComponent<EnemyGrande1_Lv1> ().Activar (true);
		}
	}

	void OnTriggerStay2D(Collider2D c) {
		if(c.tag == "Player"){
			enemy.GetComponent<EnemyGrande1_Lv1> ().Activar (true);
		}
	}

	void OnTriggerExit2D(Collider2D c) {
		if(c.tag == "Player"){
			enemy.GetComponent<EnemyGrande1_Lv1> ().Activar (false);
		}
	}
}
