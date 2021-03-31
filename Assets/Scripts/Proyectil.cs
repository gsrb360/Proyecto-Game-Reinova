using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour {

	public float velX = 1;
	public float velY = 1;

	private float orientacion;

	void Awake(){
		Destroy (gameObject, 30f);
	}
	// Update is called once per frame
	void Update () {
		gameObject.transform.Translate (orientacion * velX * 0.5f * Time.deltaTime, -1 * velY * Time.deltaTime, 0f);
	}

	void OnTriggerEnter2D(Collider2D c) {
		Destroy (gameObject, 0.1f);
	}

	public void Orientacion(float a){
		orientacion = a;
	}
}
