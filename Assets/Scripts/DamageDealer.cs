using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int damageDealt = 10;

    public int GetDamage()
    {
        Debug.Log("damage is " + damageDealt);
        return damageDealt;
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
