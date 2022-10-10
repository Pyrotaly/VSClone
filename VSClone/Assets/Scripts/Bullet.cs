using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int bulletDamage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<IDamageable>(out IDamageable i))
        {
            i.Damage(bulletDamage);
        }

        Destroy(this.gameObject);
    }
}
