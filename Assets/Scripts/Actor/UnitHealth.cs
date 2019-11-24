using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class UnitHealth : MonoBehaviour, IDestructable
{
    private Animator animator;
    private float hitstunDuration = 0.3f;

    [SerializeField]
    private FloatReference hp;

    [SerializeField]
    private FloatVariable startingHp;

    public UnityEvent deathEvent;

    private void Awake()
    {
        animator = this.gameObject.GetComponent<Animator>();
        ResetHealth();
    }

    public void ResetHealth()
    {
        hp.Value = startingHp.Value;
    }

    public float getHp()
    {
        return hp.Value;
    }

    public void OnDeath()
    {
        
    }

    public void TakeDamage(float damage)
    {
        if (!animator.GetBool("hitstun"))
        {
            hp.Value -= damage;

            if (hp.Value <= 0)
            {
                deathEvent.Invoke();
                animator.SetBool("death", true);
                animator.SetBool("playDeathAnimation", true);
            }

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
