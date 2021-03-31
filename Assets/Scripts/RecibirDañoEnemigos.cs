using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecibirDañoEnemigos : MonoBehaviour {

	public GameObject enemigo;

	public int nHit = 0;
	public int maxHit = 1;

	private GameObject player;

	void Start () {
		player = GameObject.FindWithTag ("Player");
	}

	void OnTriggerEnter2D(Collider2D c) {
		if (c.tag == "Ataque 1") {
			nHit++;
			player.GetComponent<PlayerControlller> ().ganarPoder ();

		}

		if (c.tag == "Ataque 2") {
			nHit += 5;
		}


		if (nHit >= maxHit) {
			Destroy (enemigo, 0.5f);
		}

	}
}
