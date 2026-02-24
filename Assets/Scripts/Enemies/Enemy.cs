

using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxHealth;
    public float health = 100f;
    public float speed = 10f;
    private Vector2 direction;
    Rigidbody2D rb;
    public float damage = 10f;
    protected Transform baseTarget;
    protected bool isDead = false;


    protected virtual void Start()
    {
        maxHealth = health;
        BaseAttack();
    }

    private void Update()
    {
        enemyDirection();
    }

    protected virtual void Die()
    {
        if(isDead) return;
        isDead = true;

        WaveSpawner spawner = FindObjectOfType<WaveSpawner>();
        if(spawner != null)
        {
            spawner.enemiesRemaining--;
            spawner.waveUI.UpdateUI();
        }
        Destroy(gameObject);
    }

    public virtual void TakeDamage(float amount)
    {
        health -= amount;

        if(health <= 0)
        Die();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Base"))
        {
            Base baseScript = other.GetComponent<Base>();

            if(baseScript != null)
            {
                baseScript.TakeDamage(damage);
            }
            Die();
        }

        if (other.CompareTag("Player"))
        {
            Player playerScript = other.GetComponent<Player>();
            if (playerScript != null)
            {
                playerScript.TakeDamage(damage);
            }
            Die();
            return;
        }

        if (other.CompareTag("Shield"))
        {
            Shield shield = other.GetComponent<Shield>();
            if(shield != null)
            {
                shield.TakeDamage(damage);
            }
            Die();
            return;
        }
    }

    private void BaseAttack()
    {
        GameObject baseObj = GameObject.FindGameObjectWithTag("Base");

        if(baseObj != null)
        {
            baseTarget = baseObj.transform;
        }

        rb = GetComponent<Rigidbody2D>();
    }


    protected virtual void enemyDirection()
    {
        if(baseTarget == null) return;

        direction = (baseTarget.position - transform.position).normalized;
        
        transform.position = Vector2.MoveTowards(
            transform.position,
            baseTarget.position,
            speed * Time.deltaTime
        );

        transform.up = -direction;
    }


}
