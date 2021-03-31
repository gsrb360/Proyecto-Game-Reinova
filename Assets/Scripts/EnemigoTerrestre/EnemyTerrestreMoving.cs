using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTerrestreMoving : MonoBehaviour {

	public float disMaxX = 3f;
	public float vel = 1f;

	private GameObject player;

	private bool atacando;
	private bool ataque;
	private bool hit;

	private Animator ani;
	private Rigidbody2D rb;

	private float h = 1;
	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag ("Player");
		ani = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();

	}

	// Update is called once per frame
	void Update () {
		if (atacando) {
			if (transform.position.x > player.transform.position.x) {
				h = -1;
			} else if (transform.position.x < player.transform.position.x) {
				h = 1;
			}

			if (Mathf.Abs (transform.position.x - player.transform.position.x) < disMaxX) {				
				ataque = true;
				ani.SetBool ("Atacando", true);
			} else {
				ataque = false;
				ani.SetBool ("Atacando", false);
			}
		} else {
			ataque = false;
			ani.SetBool ("Atacando", false);
		}
	}

	void FixedUpdate () {
		if (!ataque && !hit) {
			rb.velocity = new Vector2 (h * vel, rb.velocity.y);
		} else {
			rb.velocity = new Vector2 (0f, 0f);
		}

		transform.localScale = new Vector3 (h, 1f, 1f);
	}

	public void setAtacando(bool a){
		atacando = a;
	}

	public void recibirDaño(){
		ani.SetTrigger ("Hit");
		hit = true;
		StartCoroutine ("esperarHit");
	}

	void OnTriggerEnter2D(Collider2D c) {
		if (c.tag == "Limite") {
			h *= -1;
		}
	}

	IEnumerator esperarHit(){
		yield return new WaitForSeconds (0.5f);
		hit = false;
	}
}
