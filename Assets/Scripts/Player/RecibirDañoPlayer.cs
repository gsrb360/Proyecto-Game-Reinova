using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecibirDañoPlayer : MonoBehaviour {

	GameObject player;

	private bool hit;
	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag ("Player");
	}

	void OnTriggerEnter2D(Collider2D c) {
		if (!hit) {
			hit = true;
			player.GetComponent<PlayerControlller> ().recibirDaño (1f);
			if (c.transform.position.x > player.transform.position.x) {
				player.GetComponent<PlayerControlller> ().Retroceso (1f);
			}else if (c.transform.position.x < player.transform.position.x) {
				player.GetComponent<PlayerControlller> ().Retroceso (-1f);
			}
			StartCoroutine ("esperarGolpe");
		}

	}

	IEnumerator esperarGolpe(){
		yield return new WaitForSeconds (1f);
		hit = false;
	}
}
