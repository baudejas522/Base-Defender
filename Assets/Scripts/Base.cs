using System.Reflection.Emit;
using UnityEngine;
using UnityEngine.UI;

public class Base : MonoBehaviour
{
    public float maxHealth;
    public float health = 100f;
    public Image healthBar;
    public GameManagerScript gameManager;
    public float maxSpinSpeed = 150f;
    private bool isDead;
    Rigidbody2D rb;

    private void Start()
    {
        maxHealth = health;
    }
    private void Update()
    {
        HealthBar();
    }
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.angularVelocity = maxSpinSpeed;
    }
    
    public void TakeDamage(float amount)
    {
        health -= amount;

        HealthBar();

        if(health <= 0) 
        {

            gameManager.gameOver();
            Die();
        }
    }
    private void Die()
    {
        Destroy(gameObject);
    }

    private void HealthBar()
    {
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);
    }

    
}
