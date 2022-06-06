using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;
    private float backgroundLength;
    // Start is called before the first frame update
    void Start()
    {
        startPos = this.transform.position;
        backgroundLength = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.x < startPos.x - backgroundLength)
            this.transform.position = startPos;
    }
}
