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

    private bool isSpawn;
    private int[] arr = { 0, 0, 1, 0, 0 };

    private void Start()
    {
        InvokeRepeating(nameof(SpawnSteps), startDelayStep, reapetTimeStep);
        InvokeRepeating(nameof(SpawnObstacle), startDelayObstacle, reapetTimeObstacle);
    }
    private void Update()
    {
        isSpawn = GameManager.instanceGameManager.lives > 0 ? true : false;
    }
    private Vector3 RamdomPos()
    {
        Vector3 pos = new Vector3(Random.Range(-boundX, boundX), boundY, 0);
        return pos;
    }
    private void SpawnSteps()
    {
        if (isSpawn)
        {
            Vector3 pos = RamdomPos();
            Instantiate(stepsPrefabs, pos, this.transform.rotation);
            Vector3 posLives = new Vector3(pos.x, pos.y + 0.5f, pos.z);
            SpawnLives(posLives);
        }
    }
    private void SpawnObstacle()
    {
        if (isSpawn)
        {
            Instantiate(obstaclePrefabs, new Vector3(RamdomPos().x, RamdomPos().y + 1.5f, RamdomPos().z), this.transform.rotation);
        }
    }
    private void SpawnLives(Vector3 pos)
    {
        int index = Random.Range(0, arr.Length);
        if (arr[index] == 1)
        {
            Instantiate(livesPrefabs, pos, this.transform.rotation);
        }
    }


}
