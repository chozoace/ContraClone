using UnityEngine;
using System.Collections;

public class EnemyHealth : UnitHealth
{
    public override void OnDeath()
    {
        throw new System.NotImplementedException();
    }

    public override void StopHitstun()
    {
        throw new System.NotImplementedException();
    }

    public override void TakeDamage(float damage)
    {
        //flicker white
        hp.Value -= damage;

        if (hp.Value <= 0)
        {
            animator.SetBool("death", true);
        }
    }
}
