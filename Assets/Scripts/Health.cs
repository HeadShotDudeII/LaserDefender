using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 50;
    [SerializeField] ParticleSystem hitEffect;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.GetComponent<DamageDealer>();
        if (damageDealer != null)
        {

            Debug.Log(damageDealer.name);
            damageDealer.Die();
            TakeDamage(damageDealer.GetDamage());
            PlayHitEffect();
        }
    }

    private void TakeDamage(int damageDealt)
    {
        health -= damageDealt;

        if (health <= 0)
        {
            Destroy(gameObject);
        }

    }

    void PlayHitEffect()
    {
        if (hitEffect != null)
        {
            ParticleSystem instance = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(instance, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }
}
