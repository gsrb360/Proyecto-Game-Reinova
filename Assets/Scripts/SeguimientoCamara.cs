using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguimientoCamara : MonoBehaviour {

	GameObject player;
	public float maxX = 100f;
	public float minX = -100f;
	public float maxY = 100f;
	public float minY = -100f;

	Vector2 velocidad;
	public float smoothTime = 3f;
	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (player != null) {
			//float x = Mathf.Clamp (player.transform.position.x, minX, maxX);
			//float y = Mathf.Clamp (player.transform.position.y, minY, maxY);
			//transform.position = new Vector3 (x, y, transform.position.z);

			float x = Mathf.Round(
				Mathf.SmoothDamp(transform.position.x,
				player.transform.position.x, ref velocidad.x, smoothTime
				) * 100) / 100;

			float y = Mathf.Round(
				Mathf.SmoothDamp(transform.position.y,
				player.transform.position.y, ref velocidad.y, smoothTime
				) * 100) / 100;



			transform.position = new Vector3(
				Mathf.Clamp(x, minX, maxX),
				Mathf.Clamp(y, minY, maxY), 
				transform.position.z);
		}
	}
}
