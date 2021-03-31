using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basura : MonoBehaviour {

	public Button re;
	private GameObject manager;

	public bool activo;

	void Start () {
		manager = GameObject.FindWithTag ("Manager");

	}

	void OnTriggerEnter2D(Collider2D c) {
		if(c.tag == "Player"){
			desactivar (re.gameObject, true);
			activo = true;
		}
	}

	void OnTriggerStay2D(Collider2D c) {
		if(c.tag == "Player"){
			desactivar (re.gameObject, true);
			activo = true;
		}
	}

	void OnTriggerExit2D(Collider2D c) {
		if(c.tag == "Player"){
			desactivar (re.gameObject, false);
			activo = false;
		}
	}

	public void desactivar(GameObject g, bool a){
		g.SetActive (a);

		foreach (Transform child in g.gameObject.transform) {
			desactivar (child.gameObject, a);
		}
	}

	public void destruir(){
		if (activo) {
			manager.GetComponent<Score> ().aumentarScore (100);
			desactivar (re.gameObject, false);
			activo = false;
			Destroy (gameObject, 0.1f);
		}
	}
}
