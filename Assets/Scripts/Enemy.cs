using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Stats")]
    [SerializeField] float health = 100;
    [SerializeField] int score = 150;

    [Header("Projectile Configuration")]
    float shotCounter = 0;
    [SerializeField] float minTimeBetweenShots = 1f;
    [SerializeField] float maxTimeBetweenShots = 3f;
    [SerializeField] GameObject laserPrefab = null;
    [SerializeField] float projectileSpeed = 10f;

    [Header("Death Explosion")]
    [SerializeField] GameObject explosionParticles = null;
    [SerializeField] float durationOfExplosion = 1f;
    
    [Header("Enemy Shooting Audio")]
    [SerializeField] AudioClip shootSoundFX = null;
    [SerializeField] [Range(0, 1f)] float shootSFXVolume = 1f;

    [Header("Enemy Death Audio")]
    [SerializeField] AudioClip deathSoundFx = null;
    [SerializeField] [Range(0, 1f)] float deathSFXVolume = 1f;

    private void Start()
    {
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    private void Update()
    {
        CountDownAndShoot();
    }

    private void CountDownAndShoot()
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0)
        {
            Fire();
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    private void Fire()
    {
        GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(shootSoundFX, transform.position, shootSFXVolume);
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) return;
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        FindObjectOfType<GameSession>().AddToScore(score);
        GameObject particle = Instantiate(explosionParticles, transform.position, transform.rotation);
        Destroy(gameObject);
        Destroy(particle, durationOfExplosion);
        AudioSource.PlayClipAtPoint(deathSoundFx, Camera.main.transform.position, deathSFXVolume);
    }
}
