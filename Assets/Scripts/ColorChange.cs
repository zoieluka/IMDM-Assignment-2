using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    public string trigger;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag(trigger))
        {
            Debug.Log("Enter");
            
            
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.name == "Sphere")
        {
            Debug.Log("Exit");
        }
    }
}
