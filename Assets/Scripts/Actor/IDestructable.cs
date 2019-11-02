using UnityEngine;
using System.Collections;

public interface IDestructable
{
    void TakeDamage(float damage);
    void OnDeath();
}
