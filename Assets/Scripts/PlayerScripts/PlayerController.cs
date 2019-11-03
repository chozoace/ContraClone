using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Actor, IDestructable
{
    private Animator animator;
    private float hitstunDuration = 0.3f;

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
            hp.RuntimeValue -= damage;
            animator.SetBool("hitstun", true);
        }
    }

    public void StopHitstun()
    {
        StartCoroutine(StopHitstunCoroutine());
    }

    private IEnumerator StopHitstunCoroutine()
    {
        yield return new WaitForSeconds(hitstunDuration);
        gameObject.GetComponent<Animator>().SetBool("hitstun", false);
        //continue shooting if button is still being held
    }
}