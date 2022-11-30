using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileLifeTime = 10f;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileTimeGap = 0.2f;

    public bool isFiring;
    Coroutine firingCoroutine;

    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    private void Fire()
    {

        if (isFiring && firingCoroutine == null) // Firing is pressed and no other coroutine is running
        {
            firingCoroutine = StartCoroutine(FireContinuously());
            Debug.Log("Started");

        }
        else if (!isFiring && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
            Debug.Log("Stopped");
        }
    }

    IEnumerator FireContinuously()
    {
        while (true)
        {
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Debug.Log("Bullet name is " + projectile.name);
            Rigidbody2D projectile_rigidbody = projectile.GetComponent<Rigidbody2D>();
            //projectile_rigidbody.velocity = transform.up * projectileSpeed;
            projectile_rigidbody.velocity = new Vector2(0f, projectileSpeed);
            Destroy(projectile, projectileLifeTime);

            yield return new WaitForSeconds(projectileTimeGap);
        }




    }
}
