
using UnityEngine;

public class SniperBullet : MonoBehaviour
{
   
  public float lifetime = 3f;
  public float damage = 100f;
  private float speed = 10f;

  private void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

 private void Start()
    {
        Destroy(gameObject, lifetime);
    }

private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();

            if(player != null)
            {
                player.TakeDamage(damage);
            }
            Destroy(gameObject);
        }

        if (other.CompareTag("Shield"))
        {
            Shield shield = other.GetComponent<Shield>();

            if(shield != null)
            {
                shield.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}
