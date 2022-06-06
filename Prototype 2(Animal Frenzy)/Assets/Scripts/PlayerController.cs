using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalSpeed = 10.0f;
    public float xRange = 10.0f;
    private float horizontalInput;

    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
           
    }

    // Update is called once per frame
    void Update()
    {
        // Move player
        horizontalInput = Input.GetAxis("Horizontal");
        this.transform.Translate(Vector3.right * horizontalSpeed * Time.deltaTime * horizontalInput);

        // Keep the player in bounds.
        if (this.transform.position.x < -xRange)
            this.transform.position = new Vector3(-xRange, this.transform.position.y, this.transform.position.z);
        if (this.transform.position.x > xRange)
            this.transform.position = new Vector3(xRange, this.transform.position.y, this.transform.position.z);

        // Launch projectiles
        if (Input.GetKeyDown(KeyCode.Space)){
            Instantiate(projectilePrefab, this.transform.position + Vector3.up, projectilePrefab.transform.rotation);
        }
    }
}