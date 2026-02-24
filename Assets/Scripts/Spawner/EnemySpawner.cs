
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
   
 public GameObject EnemyPrefab; 
 public float minimumSpawnTime = 1.5f;
 public float maximumSpawnTime = 3.5f;
 private float timeUntilSpawn;

 private void Awake()
    {
        SetTimeUntilSpawn();
    }
 private void Update()
    {
        timeUntilSpawn -= Time.deltaTime;

        if(timeUntilSpawn <= 0)
        {
            Instantiate(EnemyPrefab, transform.position, Quaternion.identity);
            SetTimeUntilSpawn();
        }
    }


 private void SetTimeUntilSpawn()
    {
        timeUntilSpawn = Random.Range(minimumSpawnTime, maximumSpawnTime);
    }

}
