using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour, IDamageable
{
    [SerializeField] private int Health = 400;

    [SerializeField] private int touchDamage = 20;

    private void OnCollisionEnter2D(Collision2D collision)      //Knock player?
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

    public void TakeDamage(int damageAmount)    //Add in particle effects and stuff
    {
        Health -= damageAmount;

        if (Health <= 0)
        {
            //TODO : Make enemy explode
            Destroy(gameObject);
        }
    }
}
