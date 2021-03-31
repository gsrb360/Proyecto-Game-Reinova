using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorDescripcion : MonoBehaviour {

	public Image des;

	public void CambiarDescripcion(string name){
		des.sprite = Resources.Load<Sprite> ("Sprites/"+name);
	}
}
