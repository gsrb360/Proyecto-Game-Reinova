using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilDefinitivo : MonoBehaviour
{
    public float velX = 30;

    private float orientacion;
    void Awake()
    {
        Destroy(gameObject, 30f);
    }

    void Update()
    {
        gameObject.transform.Translate(orientacion * velX * Time.deltaTime, 0f, 0f);
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        Destroy(gameObject, 0.1f);
    }

    public void Orientacion(float a)
    {
        orientacion = a;
    }
}
