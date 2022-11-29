using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> wavesList;
    [SerializeField] float timeBetweenWaves = 0f;
    [SerializeField] float spawnInterval = 1f;
    [SerializeField] float spawnTimeVariance = 0.2f;
    [SerializeField] float minSpawnTime = 0.2f;
    WaveConfigSO currentWave;
    bool isLooping;
    void Start()
    {

        StartCoroutine(SpawnEnemies());
    }

    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }



    IEnumerator SpawnEnemies()
    {
        do
        {
            foreach (WaveConfigSO wave in wavesList)
            {
                currentWave = wave;
                for (int i = 0; i < currentWave.GetEnemyCount(); i++)
                {

                    Instantiate(currentWave.GetEnemyPrefab(i), currentWave.GetStartingWayPoints().position, Quaternion.identity, transform);
                    yield return new WaitForSeconds(GetSpawnTime());
                }
                yield return new WaitForSeconds(timeBetweenWaves);
            }
        }
        while (isLooping);


    }

    public float GetSpawnTime()
    {
        float spawnTime = Random.Range(spawnInterval - spawnTimeVariance, spawnInterval + spawnTimeVariance);
        Debug.Log(spawnTime);

        return Mathf.Clamp(spawnTime, minSpawnTime, float.MaxValue);
    }
}
