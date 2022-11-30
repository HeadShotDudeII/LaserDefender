using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 50;
    int counter = 0;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.GetComponent<DamageDealer>();
        if (damageDealer != null)
        {
            counter++;
            Debug.Log(damageDealer.name);
            damageDealer.Die();
            TakeDamage(damageDealer.GetDamage());
            Debug.Log("counter is " + counter);
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
}
