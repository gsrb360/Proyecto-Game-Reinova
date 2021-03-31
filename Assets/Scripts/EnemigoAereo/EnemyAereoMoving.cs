using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAereoMoving : MonoBehaviour {

	public float velocity = 3f;

	private int h = -1;
	public bool atacando = false;
	Rigidbody2D rb;
	Animator ani;

	public GameObject proyectil;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		ani = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
		
			
		
	}

	void FixedUpdate () {
		if (!atacando) {
			rb.velocity = new Vector2 (h * velocity, rb.velocity.y);
		} else {			
			rb.velocity = new Vector2 (0f, 0f);
		}

		if (h == 1) {
			transform.localScale = new Vector3 (1f, 1f, 1f);
		}

		if (h == -1) {
			transform.localScale = new Vector3 (-1f, 1f, 1f);
		}
	}

	void OnTriggerEnter2D(Collider2D c) {
		if (c.tag=="Limite") {
			h *= -1;
		}
		if (c.tag=="Player") {
			if (!atacando) {
				atacando = true;
				ani.SetTrigger ("Atacando");
				StartCoroutine ("esperarAtaque");
			}
		}
	}

	IEnumerator esperarAtaque(){
		yield return new WaitForSeconds (0.5f);
		GameObject pro_1 = Instantiate (proyectil, new Vector3(transform.position.x, transform.position.y, 1), transform.rotation);
		GameObject pro_2 = Instantiate (proyectil, new Vector3(transform.position.x, transform.position.y, 1), transform.rotation);
		GameObject pro_3 = Instantiate (proyectil, new Vector3(transform.position.x, transform.position.y, 1), transform.rotation);
		pro_1.GetComponent<Proyectil> ().Orientacion (-1f);
		pro_2.GetComponent<Proyectil> ().Orientacion (0f);
		pro_3.GetComponent<Proyectil> ().Orientacion (1f);
		StartCoroutine ("esperarDisparo");
	}

	IEnumerator esperarDisparo(){
		yield return new WaitForSeconds (0.5f);
		atacando = false;
	}
}
