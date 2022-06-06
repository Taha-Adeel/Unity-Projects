using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float spawnX = Random.Range(-15, 15);
        Vector3 pos = new Vector3(spawnX, 6, 0);
        transform.position = pos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
