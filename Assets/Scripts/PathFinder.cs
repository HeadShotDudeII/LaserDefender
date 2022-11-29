using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    EnemySpawner enemySpawner;
    WaveConfigSO waveConfig;
    List<Transform> wayPoints;
    int wayPointIndex = 0;

    private void Awake()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }

    void Start()
    {
        waveConfig = enemySpawner.GetCurrentWave();
        wayPoints = waveConfig.GetWayPoints();
        transform.position = wayPoints[wayPointIndex].position;


    }

    // Update is called once per frame
    void Update()
    {
        FollowPath();

    }

    private void FollowPath()
    {
        if (wayPointIndex < wayPoints.Count)
        {
            Vector3 target = wayPoints[wayPointIndex].position;
            float delta = waveConfig.GetSpeed() * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target, delta);
            if (transform.position == target)
            {
                wayPointIndex++;
            }

        }
        else
        {
            Destroy(gameObject);
        }
    }
}
