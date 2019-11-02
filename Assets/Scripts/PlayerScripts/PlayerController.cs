using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Actor, IDestructable
{
    private Animator animator;

    [SerializeField]
    private FloatVariable hp;

    private void Awake()
    {
        animator = this.gameObject.GetComponent<Animator>();
    }

    public void OnDeath()
    {
        //throw death Event
    }

    public void TakeDamage(float damage)
    {
        if (!animator.GetBool("hitstun"))
        {
            //modify player hp float
            hp.RuntimeValue -= damage;
            //set hitstun = true
            animator.SetBool("hitstun", true);
        }
    }
}