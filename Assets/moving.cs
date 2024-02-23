using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving : MonoBehaviour
{
    public float cameraSpeed = 5f;  // Speed at which the camera moves forward

    private void Update()
    {
        // Move the camera forward smoothly
        transform.Translate(Vector3.forward * Time.deltaTime * cameraSpeed);
    }
}
