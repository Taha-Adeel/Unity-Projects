using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float acceleration = 6.0f;
    private Rigidbody enemyRb;
    private GameObject player;
    private Vector3 lookDirection;
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        lookDirection = (player.transform.position - this.transform.position).normalized;
        enemyRb.AddForce(lookDirection * acceleration * enemyRb.mass);

        if (this.transform.position.y < -10)
            Destroy(gameObject);
    }
}
