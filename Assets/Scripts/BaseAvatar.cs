using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseAvatar : MonoBehaviour
{
    [SerializeField] protected float Health;
    [SerializeField] protected GameObject gameObject;
    public virtual void TakeDamage(float damage)
    {
        Health -= damage;
    }
    public virtual void Die()
    {
        if (Health <=0)
        {
            Destroy(gameObject);
        }
    }
}
