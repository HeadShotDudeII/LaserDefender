using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileLifeTime = 10f;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileTimeGap = 0.2f;

    [Header("Ai")]
    [SerializeField] bool isAi;
    [SerializeField] float projectileTimeGapVariance = 0.2f;
    [SerializeField] float projectileMinTimeGap = 0.2f;



    [HideInInspector] public bool isFiring;
    Coroutine firingCoroutine;
    AudioPlayer audioPlayer;

    private void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    private void Start()
    {
        if (isAi)
        {
            isFiring = true;
        }
    }

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
            //Debug.Log("Bullet name is " + projectile.name);
            Rigidbody2D projectile_rigidbody = projectile.GetComponent<Rigidbody2D>();
            projectile_rigidbody.velocity = transform.up * projectileSpeed;
            //projectile_rigidbody.velocity = new Vector2(0f, projectileSpeed);
            Destroy(projectile, projectileLifeTime);

            float fireTimeGap = Random.Range(projectileTimeGap - projectileTimeGapVariance, projectileTimeGap + projectileTimeGapVariance);
            audioPlayer.PlayShootingClip();

            yield return new WaitForSeconds(Mathf.Clamp(fireTimeGap, projectileMinTimeGap, float.MaxValue));
        }




    }
}
