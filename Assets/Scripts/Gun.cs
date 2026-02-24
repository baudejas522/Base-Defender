
using UnityEngine;

public class Gun : MonoBehaviour


{
    public GameObject bulletPrefab;
    public Transform firepoint;
    public float bulletSpeed = 10f;
    private AudioSource audioSource;

    private void Update()
    {
        Shoot();
    } 
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Shoot()
    {
        if(Input.GetMouseButtonDown(0)){ 
            Fire();
        }
    }

    private void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.linearVelocity = firepoint.up * bulletSpeed;

        audioSource.Play();
    }


}
