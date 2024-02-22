using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class color_changer : MonoBehaviour
{
    public Transform sphereTransform;
    public Color newColor = Color.blue;
    public float threshold = 1.0f;

    private Renderer sphereRenderer;
    private Color ogColor;

    void Start()
    {
        sphereRenderer = sphereTransform.GetComponent<Renderer>();
        if(sphereRenderer != null)
        {
            ogColor = sphereRenderer.material.color;
        }

        Debug.LogError("Sphere renderer not found on: " + sphereTransform.gameObject.name);
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, sphereTransform.position);

        if (distance < threshold)
        {
            ChangeSphereColor(newColor);
        }
        else
        {
            ChangeSphereColor(ogColor);
        }
    }

    void ChangeSphereColor(Color color)
    {
        if (sphereRenderer != null)
        {
            sphereRenderer.material.color = color;
        }
    }
}
