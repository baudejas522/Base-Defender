
using UnityEngine;

public class Asteroid : MonoBehaviour
{
 [SerializeField] float lifetime = 10f;
  public float health = 100f;
  public float maxHealth;
  public float speed = 5f;
  public float damage = 100f;
  private Vector2 direction; 
  Rigidbody2D rb;
  private Transform Targetplayer;

  private void Start()
    {
        maxHealth = health;
        AsteroidDirection();
        Destroy(gameObject, lifetime);
    }

  private void Die()
    {
        Destroy(gameObject);
    }


    public void TakeDamage(float amount)
    {
        health -= amount;
        
        if(health <= 0)
        Die();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Shield"))
        {
            Shield shield = other.GetComponent<Shield>();
            if(shield != null)
            {
                shield.TakeDamage(damage);
            }
            Destroy(transform.root.gameObject);
            return;
        }
        
        if (other.CompareTag("Player"))
        {
            Player playerScript = other.GetComponent<Player>();

            if(playerScript != null)
            {
                playerScript.TakeDamage(damage);
            }
            Die();
            return;
        }
    }

  private void PlayerAttack()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");

        if(playerObj != null)
        {
            Targetplayer = playerObj.transform;
        }
        rb = GetComponent<Rigidbody2D>();
    }

  private void AsteroidDirection()
    { 
        rb = GetComponent<Rigidbody2D>();
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if(playerObj != null)
        {
            Vector2 direction = (playerObj.transform.position - transform.position).normalized;
            rb.AddForce(direction * speed);
        }
    }



}
