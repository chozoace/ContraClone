using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    protected bool exists;
    protected SpriteRenderer renderer;
    protected Rigidbody2D rigidbody2D;

    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Bullet Hit");
       // Destroy(this.gameObject);
    }

    private void OnBecameInvisible()
    {
        disableBullet();
    }

    void disableBullet()
    {
        exists = false;
        renderer.enabled = false;
        rigidbody2D.velocity = Vector2.zero;
        //this.gameObject.layer = 14;
    }
}
