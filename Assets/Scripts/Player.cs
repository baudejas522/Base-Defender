
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour

{
 public float health = 100f;
 public float maxHealth;
 public Rigidbody2D rb {get; private set;}
 public Vector2 direction {get; private set;}
 public float speed = 20f;
 public GameManagerScript gameManager;
 public AudioClip deathClip;
 private AudioSource audioSource;
 private bool isDead = false;


 private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        maxHealth = health;
    }

    private void Update()
    {
        Direction();
        AimDirection();
    }

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }


    // PLAYERS MOVEMENT
 
 private void Direction()
    {
      if(Input.GetKey(KeyCode.A)){
            direction = Vector2.left;
      } else if(Input.GetKey(KeyCode.D)){
            direction = Vector2.right;
      } else if(Input.GetKey(KeyCode.W)){
            direction = Vector2.up;
      } else if(Input.GetKey(KeyCode.S)){
            direction = Vector2.down;
      } else
        direction = Vector2.zero;
    } 
 private void FixedUpdate()
    {
        if(direction != Vector2.zero)
        {
            rb.AddForce(direction * speed);
        }
    }
 
    // PLAYERS DIRECTION
    
    private void AimDirection()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;

        Vector2 direction = (mousePos - transform.position).normalized;
        transform.up = direction; 
    }

    public void TakeDamage(float amount)
    {
        if(isDead) return;

        health -= amount;

        if(health - amount <= 0)
        {
            health = 0;
            Die();    
        }
        else
        {   health -= amount;
            audioSource.Play();
        }
        
    }
    

    private void Die()
    {
        
        gameManager.gameOver();
        audioSource.PlayOneShot(deathClip);
        Destroy(gameObject, audioSource.clip.length);
    }


}
