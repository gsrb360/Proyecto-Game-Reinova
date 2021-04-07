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
       // gameObject.transform.Translate(orientacion * velX * Time.deltaTime, 0f, 0f);
        gameObject.transform.position=new Vector3(transform.position.x+ (orientacion * 5f*Time.deltaTime),transform.position.y,transform.position.z);
        gameObject.transform.Rotate(0f,0f,orientacion*-1f*1f);
        

    }

    void OnTriggerEnter2D(Collider2D c)
    {
        Destroy(gameObject, 0.1f);
    }
     void OnCollisionEnter(Collision collision){
                 Destroy(gameObject, 0.1f);

     }

    public void Orientacion(float a)
    {
        orientacion = a;
    }
}
