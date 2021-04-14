using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControlller : MonoBehaviour {
	
	public string HorizontalAxis = "Horizontal";
	public string JumpAxis = "Jump";
	Rigidbody2D rb;
	Animator ani;
	public float velocity = 5f;
	public float jumpPower = 5f;
	public bool grounded;
	private bool dobleSalto;
	public bool defenza;
	public bool ataque;
	private bool vivo;
	public bool golpe;

	private int nAtaque = 0;

	private float vidaMax = 15f;
	private float poderMax = 100f;

	private float vida;
	private float poder;

	public Image barraVida;
	public Image barraPoder;

	public float h;

	private GameObject manager;

	public GameObject proyectil;
	// Use this for initialization
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		ani = GetComponent<Animator>();
		vida = vidaMax;
		poder = 0f;

		h = 0;

		barraVida.transform.localScale = new Vector3 (vida / vidaMax, 1f, 1f);
		barraPoder.transform.localScale = new Vector3 (poder / poderMax, 1f, 1f);

		vivo = true;

		manager = GameObject.FindWithTag ("Manager");
	}

	void Update()
	{
		ani.SetFloat("SpeedX", Mathf.Abs(rb.velocity.x));
		ani.SetFloat("SpeedY", rb.velocity.y);
		ani.SetBool ("Suelo", grounded);
	}

	void FixedUpdate()
	{
		if (vivo) {

			//Movimiento
			if (!defenza && !ataque && !golpe) {
				rb.velocity = new Vector2 (h * velocity, rb.velocity.y);
			}


			//Direccion
			if (h > 0.1f) {
				transform.localScale = new Vector3 (1f, 1f, 1f);
			}

			if (h < -0.1f) {
				transform.localScale = new Vector3 (-1f, 1f, 1f);
			}


		}

	}

	public void mover (float h){
		this.h = h;
	}

	public void Saltar(){
		if ((grounded || dobleSalto) && !ataque) {
			rb.velocity = new Vector2(rb.velocity.x, 0f);
			rb.AddForce (Vector2.up * jumpPower, ForceMode2D.Impulse);
			dobleSalto = false;
		}
	}

	public void enterDefenza(){
		if (grounded) {
			defenza = true;
			ani.SetBool ("Defender", true);
			rb.velocity = new Vector2 (0, 0);
		}
	}

	public void exitDefenza(){
		if (grounded) {
			defenza = false;
			ani.SetBool ("Defender", false);
		}
	}

	public void enterAtaque(){
		if (grounded && nAtaque < 3) {
			nAtaque++;
			ataque = true;
			ani.SetBool ("Atacando", true);
			rb.velocity = new Vector2 (0, 0);
			StartCoroutine ("esperarAtaque");
		}
	}

	public void recolectar(){
		if (grounded) {
			ani.SetTrigger ("Recolectar");
		}
	}

	public void golpeado(){
		ani.SetTrigger ("Golpeado");
	}

	public void recibirDaño(float damage){		
		vida -= damage;
		vida = Mathf.Clamp (vida, 0, vidaMax);
		barraVida.transform.localScale = new Vector3 (vida / vidaMax, 1f, 1f);
		if (vida == 0f && vivo) {
			vivo = false;
			ani.SetTrigger ("Muerto");
			StartCoroutine ("esperarMuerte");
		} else {
			if (vivo) {
				ani.SetTrigger ("Golpeado");				
			}
		}
	}

	public void ganarPoder(){
		poder += 20;
		poder = Mathf.Clamp (poder, 0, poderMax);
		barraPoder.transform.localScale = new Vector3 (poder / 100, 1f, 1f);
	}

	public void ataqueDefinitivo(){
		if (poder == 100f && !ataque && nAtaque == 0 && grounded) {
			rb.velocity = new Vector2 (0, 0);
			ani.SetTrigger ("Definitiva");
			ataque = true;
			StartCoroutine ("esperarAtaqueDefinitivo");
			poder = 0;
			barraPoder.transform.localScale = new Vector3 (poder / 100, 1f, 1f);
			StartCoroutine("proyecDefintivo");
		}
	}

	public void Retroceso(float a){
		golpe = true;
		rb.velocity = new Vector2 (0f, rb.velocity.y);
		rb.AddForce (new Vector2(-1f * a, 1f) * 5f , ForceMode2D.Impulse);
		StartCoroutine ("esperarGolpe");
	}

	//void OnCollisionEnter2D(Collision2D col)
	//{
	//	if (col.gameObject.tag == "Suelo") {
	//		dobleSalto = true;
	//	}
	//}

	//void OnCollisionStay2D(Collision2D col)
	//{
	//	if (col.gameObject.tag == "Suelo") {
	//		dobleSalto = true;
	//	}
	//}

	void OnCollisionExit2D(Collision2D col)
	{
		if (col.gameObject.tag == "Suelo") {
			dobleSalto = true;
		}
	}

	IEnumerator esperarAtaque(){
		yield return new WaitForSeconds (0.3f);
		nAtaque--;
		if (nAtaque == 0) {
			ataque = false;
			ani.SetBool ("Atacando", false);
		}
	}

	IEnumerator esperarAtaqueDefinitivo(){
		yield return new WaitForSeconds (1f);
		ataque = false;
	}

	IEnumerator esperarMuerte(){
		yield return new WaitForSeconds (1f);
		manager.GetComponent<PausarGame> ().gameOver ();
	}

	IEnumerator esperarGolpe(){
		yield return new WaitForSeconds (0.5f);
		golpe = false;
	}
	IEnumerator proyecDefintivo()
    {
		yield return new WaitForSeconds(0.7f);
		GameObject proyec = Instantiate(proyectil, new Vector3(transform.position.x + (transform.localScale.x * 1.75f), transform.position.y - 0.25f, 1), transform.rotation);
		proyec.GetComponent<ProyectilDefinitivo>().Orientacion(transform.localScale.x);
	}
}
