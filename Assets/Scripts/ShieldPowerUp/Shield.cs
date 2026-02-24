using System.Runtime.CompilerServices;
using UnityEngine;
using System.Collections;
using System.Runtime.Serialization;

public class Shield : MonoBehaviour
{   public float health = 100f;
    private AudioSource audioSource;
    private bool isDestroyed = false;
    public float damage = 300f;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void TakeDamage(float amount)
    {
        if (isDestroyed) return;

        health -= amount;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy") || other.CompareTag("Asteroid"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                health -= damage;
            }
            
            
        }
        else if (other.CompareTag("Asteroid"))
        {
            Asteroid asteroid = other.GetComponent<Asteroid>();
            if (asteroid != null)
            {
                health -= asteroid.damage;
            }
            Destroy(other.gameObject);
        }
        if(health <= 0f && !isDestroyed)
        {
            isDestroyed = true;
            audioSource.Play();
            Destroy(gameObject, audioSource.clip.length);
            
        }
    }
}
