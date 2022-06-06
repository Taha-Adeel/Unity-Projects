using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;

    [SerializeField] float speed;
    

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        this.transform.Translate(Vector3.forward * horizontalInput * speed * Time.deltaTime);
        this.transform.Translate(Vector3.left * verticalInput * speed * Time.deltaTime);
    }
}
