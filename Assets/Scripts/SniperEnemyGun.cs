using UnityEngine;

public class SniperEnemyGun : MonoBehaviour
{
    private AudioSource audioSource;

    private void Update()
    {
        audioSource = GetComponent<AudioSource>();
    }
}
