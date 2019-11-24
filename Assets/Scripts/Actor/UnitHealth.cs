using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public abstract class UnitHealth : MonoBehaviour, IDestructable
{
    protected Animator animator;

    [SerializeField]
    protected FloatReference hp;

    [SerializeField]
    protected FloatVariable startingHp;

    public UnityEvent deathEvent;

    public abstract void TakeDamage(float damage);
    public abstract void OnDeath();
    public abstract void StopHitstun();

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
}
