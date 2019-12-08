using UnityEngine;
using System.Collections;

public class PlayerHealth : UnitHealth
{
    private float hitstunDuration = 0.3f;

    public override void OnDeath()
    {
        throw new System.NotImplementedException();
    }

    public override void TakeDamage(float damage)
    {
        if (!animator.GetBool("hitstun"))
        {
            hp.Value -= damage;

            if (hp.Value <= 0)
            {
                //deathEvent.Invoke();
                animator.SetBool("death", true);
                animator.SetBool("playDeathAnimation", true);
            }

            animator.SetBool("hitstun", true);
        }
    }

    public override void StopHitstun()
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
