using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaFalling : MonoBehaviour
{
    public float fallDelay = 1f;
    public float respawnDelay = 5f;

    private Rigidbody2D rb2d;
    private BoxCollider2D bx2d;
    private BoxCollider2D bx2Parent2d;

    public GameObject parent;
    

    private Vector3 start;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponentInParent<Rigidbody2D>();
        bx2d = GetComponent<BoxCollider2D>();
        bx2Parent2d = parent.GetComponent<BoxCollider2D>();

        start = parent.transform.position;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Invoke("fall", fallDelay);
            Invoke("respawn", fallDelay + respawnDelay);
        }
    }
    private void fall()
    {
        rb2d.isKinematic = false;
        bx2d.isTrigger = true;
        bx2Parent2d.isTrigger = true;
    }
    private void respawn()
    {
        parent.transform.position = start;
        rb2d.isKinematic = true;
        rb2d.velocity = Vector3.zero;
        bx2d.isTrigger = false;
        bx2Parent2d.isTrigger = false;
    }
}
