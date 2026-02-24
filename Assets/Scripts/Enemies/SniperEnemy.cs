
using System.Security;
using UnityEngine;

public class SniperEnemy : Enemy
{
    public float stopDistance = 5f;
    private float nextFireTime;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float fireRate = 2f;
    private float fireTimer;
    private Transform playerTarget;

    private void Update()
    {
        Shoot();
        enemyDirection();
    }
    protected override void Start()
    {
        base.Start();

        health *= 0.7f;
        speed *=0.6f;

        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if(player != null)
            playerTarget = player.transform;
    }

    protected override void enemyDirection()
    {
        if(baseTarget == null) return;

        float distance = Vector2.Distance(transform.position, baseTarget.position);

        if(distance > stopDistance)
        {
            base.enemyDirection();
        }
        if(playerTarget != null)
        {
            Vector2 direction = (playerTarget.position - transform.position).normalized; 
            transform.up = -direction;
            firePoint.up = -direction;
        }

    }
    void Shoot()
    {
        if(baseTarget == null) return;

        fireTimer += Time.deltaTime;

        if(fireTimer >= fireRate)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            fireTimer = 0f;
        }
    }
    
    
        
   
}

