using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int damageDealt = 10;


    public int GetDamage()
    {
        Debug.Log("damage is " + damageDealt);
        return damageDealt;
    }

    public void BulletDestroy()
    {
        Debug.Log(" Who is Die " + gameObject.name);
        if (gameObject.tag == "Bullets")
            Destroy(gameObject);
    }  // to be changed: if enemy have lots of health
       // when it collides with player it doesnot have to die.
}
