using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour, IDamageable
{
    [SerializeField] private int Health = 400;
    [SerializeField] private int touchDamage = 20;
    [SerializeField] private GameObject bloodParticle;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<IDamageable>(out IDamageable i))
        {
            i.TakeDamage(touchDamage);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<IDamageable>(out IDamageable i))
        {
            i.TakeDamage(touchDamage);
        }
    }

    public void TakeDamage(int damageAmount)    // TODO: Add in particle effects and stuff
    {
        Health -= damageAmount;

        if (Health <= 0)
        {
            Instantiate(bloodParticle, transform.position, Quaternion.identity); 
            ActionsHolder.OnEnemyKilled();
            Destroy(gameObject);
        }
    }
}
