using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject footballPrefab;
    [SerializeField] float zRange = 8.0f;
    [SerializeField] float spawnHeight = 30.0f;
    [SerializeField] float spawnRate = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnBall", 2, spawnRate);
    }

    void SpawnBall()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-2, 2), spawnHeight, Random.Range(-zRange, zRange));

        Instantiate(footballPrefab, spawnPos, footballPrefab.gameObject.transform.rotation);
    }
}
