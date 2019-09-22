
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class WaveSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject spawnPoint;
    public float timeBetweenWaves = 5f;
    private float countDown = 2f;
    public Text waveCountDownText;
    private float waveNumber = 0f;
    void Update()
    {
        if (countDown <= 0f) {
            StartCoroutine(SpawnWave());
            countDown = timeBetweenWaves;

        }
        countDown -= Time.deltaTime;

        waveCountDownText.text = Mathf.Round(countDown).ToString();
        
    }

    IEnumerator SpawnWave() {
        waveNumber++;
        for (int i = 0; i < waveNumber ; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.56f);
        }

        
    }

    void SpawnEnemy() {
        Instantiate(enemyPrefab,spawnPoint.transform.position, spawnPoint.transform.rotation);

    }
}
