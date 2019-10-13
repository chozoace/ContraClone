using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    protected bool exists;
    public bool Exists { get { return exists; } }
    private GameObject owner;
    public GameObject Owner { get { return owner; } set { this.owner = value; } }
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
        if(exists)
        {
            if(collision.gameObject != owner)
            {
                //Debug.Log("Collision with: " + collision.gameObject.name);
                DisableBullet();
                //deal damage
            }
        }
    }

    public void ReuseBullet(Vector2 newPosition, int damage, Vector2 speedVector)
    {
        exists = true;
        spriteRenderer.enabled = true;
        this.GetComponent<CircleCollider2D>().enabled = true;
        transform.position = newPosition;
        GetComponent<Rigidbody2D>().velocity = speedVector;
    }

    private void OnBecameInvisible()
    {
        DisableBullet();
    }

    private void DisableBullet()
    {
        exists = false;
        this.GetComponent<CircleCollider2D>().enabled = false;
        spriteRenderer.enabled = false;
        rb2D.velocity = Vector2.zero;
    }
}
