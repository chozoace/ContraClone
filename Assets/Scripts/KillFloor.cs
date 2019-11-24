using UnityEngine;
using System.Collections;

public class KillFloor : MonoBehaviour
{
    float damage = 9001;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("enter");
        collision.GetComponent<IDestructable>()?.TakeDamage(damage);
    }
}
