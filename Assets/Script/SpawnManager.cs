using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Object stepsPrefabs;
    public Object obstaclePrefabs;
    public Object livesPrefabs;
    private float boundX = 4f;
    private float boundY = -10f;
    private float startDelayStep = 0.1f;
    private float reapetTimeStep = 0.5f;
    private float startDelayObstacle = 0.5f;
    private float reapetTimeObstacle = 1.5f;
    private void Start()
    {
        InvokeRepeating(nameof(SpawnSteps), startDelayStep, reapetTimeStep);
        InvokeRepeating(nameof(SpawnObstacle), startDelayObstacle, reapetTimeObstacle);
    }
    private void SpawnSteps()
    {
        Vector3 pos = new Vector3(Random.Range(-boundX, boundX), boundY, 0);
        Instantiate(stepsPrefabs, pos, this.transform.rotation);
    }
    private void SpawnObstacle()
    {
        Vector3 pos = new Vector3(Random.Range(-boundX, boundX), boundY + 2f, 0);
        Instantiate(obstaclePrefabs, pos, this.transform.rotation);
    }
    private void spawnLives()
    {

    }
}
