using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    private float color_a = 0.4f;
    void Start()
    {
        transform.position = new Vector3(3, 4, 1);
        transform.localScale = Vector3.one * 1.5f;
        
        Material material = Renderer.material;
        
        material.color = new Color(0.5f, 1.0f, 0.3f, color_a);
    }
    
    void Update()
    {
        transform.Rotate(15.0f * Time.deltaTime, 0.0f, 0.0f);
        color_a = (color_a + 0.5f * Time.deltaTime)%1.0f;
        Material material = Renderer.material;
        material.color = new Color(0.5f, 1.0f, 0.3f, color_a);
    }
}
