using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySubterraneoController : MonoBehaviour {

	public float DisAtaque = 5f;

	private Animator ani;

	private bool alerta;
	private bool ataque;

	private GameObject objetivo;
	// Use this for initialization
	void Start () {
		ani = GetComponent<Animator> ();
		objetivo = GameObject.FindWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (alerta) {
			float x = Mathf.Abs (transform.position.x - objetivo.transform.position.x);
			if (x < DisAtaque) {
				ani.SetBool ("Ataque", true);
			} else {
				ani.SetBool ("Ataque", false);
			}
		}

	}

	void OnTriggerEnter2D(Collider2D c) {
		if (c.tag == "Player") {
			alerta = true;
			ani.SetBool ("Alerta", true);
		}
	}

	void OnTriggerExit2D(Collider2D c) {
		if (c.tag == "Player") {
			alerta = false;
			ani.SetBool ("Alerta", false);
		}
	}
}
