using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGrande1_Lv1 : MonoBehaviour {

	private Rigidbody2D rb;
	private Animator ani;

	public float am = 1;

	public float h = 1;

	public float vX = 6f;
	public float vY = 8f;

	public bool activo;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		ani = GetComponent<Animator> ();
	}

	void Update(){
		if (!activo) {
			transform.localPosition = new Vector3 (0f, 0f, 0f);
        }
	}

	void OnCollisionEnter2D(Collision2D col)	{
		if (col.gameObject.tag == "Suelo" && activo) {
			Movi ();
		}
	}

//	void OnCollisionStay2D(Collision2D col)	{
//		if (col.gameObject.tag == "Suelo" && activo) {
//			Movi ();
//		}
//	}

	public void Activar(bool a){
		activo = a;
		ani.SetBool ("Activo", activo);
		if (!activo) {
			h = -1;
		}
	}

	private void Movi(){
		rb.velocity = new Vector2 (0f, 0f);
		h *= -1;
		ani.SetTrigger ("Suelo");
		//			rb.AddForce (new Vector2 (vX * am * h, vY * am));
		StartCoroutine("esperarSalto");
	}

	IEnumerator esperarSalto(){
		yield return new WaitForSeconds (3.2f);
		if (activo) {
			rb.AddForce (new Vector2 (vX * am * h, vY * am));
		}
	}
}
