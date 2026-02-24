using UnityEngine;
using System.Collections;

public class WaveSpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public Transform[] spawnPoints;
    public float timeBetweenWaves = 5f;
    public int enemiesPerWave = 5;
    public int currentWave = 0;
    public int enemiesRemaining = 0;
    public int waveNumber = 1;
    public int totalWaves = 5;
    public int CurrentWave => waveNumber;
    public WinUI winUI;
    public WaveUi waveUI;


    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {

        while (waveNumber < totalWaves)
        {

            waveUI.UpdateUI();

            enemiesRemaining = enemiesPerWave;

            for(int i = 0; i < enemiesPerWave; i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(1f);
            }

            while(enemiesRemaining > 0)
            {
                yield return null;
            }
            
            waveNumber++;
            enemiesPerWave +=2;
            waveUI.UpdateUI();
            

            yield return new WaitForSeconds(timeBetweenWaves);
        }

        winUI.ShowWin();
    }

    void SpawnEnemy()
    {
        Transform point = spawnPoints[Random.Range(0, spawnPoints.Length)];

        GameObject randomEnemy = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

        Instantiate(randomEnemy, point.position, Quaternion.identity);

    }

    public void StartNextWave(int enemyCount)
    {
        currentWave++;
        enemiesRemaining = enemyCount;
    }

    public void OnEnemyKilled()
    {
        enemiesRemaining--;
        
        if(enemiesRemaining <= 0)
        {
            
        }
    }
}

