using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] thoughtsPrefabs;
    private float startDelay = 1;
    private float spawnInterval = 2f;
    private float spawnRangeX = 8;
    
    private GameObject go;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(SpawnRandomThoughts), startDelay, spawnInterval);
    }

    public void SpawnRandomThoughts()
    {
        int thoughtsIndex = Random.Range(0, thoughtsPrefabs.Length);
        //Vector2 spawnPos = new Vector2(Random.Range(-13, 13), 8);
       go = Instantiate(thoughtsPrefabs[thoughtsIndex], new Vector2(Random.Range(-spawnRangeX, spawnRangeX), 1), Quaternion.identity);
        if(go.transform.position.y < -4)
        {
            Destroy(go);
        }
    }

    
}
