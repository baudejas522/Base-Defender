using UnityEngine;
using TMPro;

public class WaveUi : MonoBehaviour
{
public WaveSpawner waveSpawner;
public TextMeshProUGUI waveText;
public TextMeshProUGUI enemiesText;


    public void UpdateUI()
    {
        waveText.text = $"Wave {waveSpawner.CurrentWave}/{waveSpawner.totalWaves}";
    }

    private void Start()
    {
        UpdateUI();
    }
    private void Update()
    {
        enemiesText.text = $"Enemies: {waveSpawner.enemiesRemaining:00}";
    }
}
