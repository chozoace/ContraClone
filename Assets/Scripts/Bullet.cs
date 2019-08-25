using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    protected bool exists;
    public bool Exists { get { return exists; } }
    protected SpriteRenderer spriteRenderer;
    protected Rigidbody2D rb2D;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb2D = GetComponent<Rigidbody2D>();
        exists = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Bullet Hit");
       // Destroy(this.gameObject);
    }

    public void ReuseBullet(Vector2 newPosition, int damage, Vector2 speedVector)
    {
        exists = true;
        spriteRenderer.enabled = true;
        transform.position = newPosition;
        GetComponent<Rigidbody2D>().velocity = speedVector;
    }

    private void OnBecameInvisible()
    {
        disableBullet();
    }

    private void disableBullet()
    {
        exists = false;
        spriteRenderer.enabled = false;
        rb2D.velocity = Vector2.zero;
    }
}
