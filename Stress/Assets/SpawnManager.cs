using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] thoughtsPrefabs;
    private float startDelay = 2;
    private float spawnInterval = 1.5f;
    private float spawnRangeX = 13;
    private float spawnRangeY = 2;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(SpawnRandomThoughts), startDelay, spawnInterval);
    }

    public void SpawnRandomThoughts()
    {
        int thoughtsIndex = Random.Range(0, thoughtsPrefabs.Length);
        //Vector2 spawnPos = new Vector2(Random.Range(-13, 13), 8);
        Instantiate(thoughtsPrefabs[thoughtsIndex], new Vector2(Random.Range(-spawnRangeX, spawnRangeX),Random.Range(-spawnRangeY, spawnRangeY)), Quaternion.identity);
    }
}
