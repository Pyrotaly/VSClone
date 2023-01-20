using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour, IDamageable
{
    [SerializeField] private int Health = 400;
    [SerializeField] private int touchDamage = 20;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject deathParticle;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

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

        StartCoroutine(TakenDamageFlash());
        if (Health <= 0)
        {
            OnDeath();
        }
    }

    public virtual void OnDeath()
    {
        ActionsHolder.OnEnemyKilled?.Invoke();
        Instantiate(deathParticle, transform.position, Quaternion.identity);
        Destroy(this.gameObject, .005F);
    }

    private IEnumerator TakenDamageFlash()
    {
        spriteRenderer.color = new Color(1, 0, 0, 0.5f);
        yield return new WaitForSeconds(0.3f);
        spriteRenderer.color = Color.white;
        yield return new WaitForSeconds(0.3f);
    }
}
