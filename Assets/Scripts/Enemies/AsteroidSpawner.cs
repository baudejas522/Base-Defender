using UnityEngine;
using System.Collections;

public class AsteroidSpawner : MonoBehaviour
{
public GameObject asteroidPrefab;
public Transform[] spawnPoints;
public float timeBetweenWaves = 5f;
public int asteroidsPerWave = 1;
public int currentWave = 0;
public int waveNumber = 1;
public int totalWaves = 7;

void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
       while (waveNumber < totalWaves)
        {
            for(int i = 0; i < asteroidsPerWave; i++)
            {
                SpawnAsteroid();
                yield return new WaitForSeconds(1f);
            }

            while(GameObject.FindGameObjectsWithTag("Asteroid").Length > 0)
            {
                yield return null;
            }
            
            waveNumber++;
            asteroidsPerWave +=2;

            yield return new WaitForSeconds(timeBetweenWaves);
        } 
    }

    void SpawnAsteroid()
    {
        Transform point = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(asteroidPrefab, point.position, Quaternion.identity);
    }

}


