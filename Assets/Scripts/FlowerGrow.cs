using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerGrow : MonoBehaviour
{
    public string trigger;
    private void Start()
    {
        
    }

    void Update()
    {

    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag(trigger))
        {
            GetComponent<Animator>().SetBool("leaveHand",false);
            GetComponent<Animator>().SetBool("waveHand",true);
        }
       
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag(trigger))
        {
            GetComponent<Animator>().SetBool("waveHand",false);
            GetComponent<Animator>().SetBool("leaveHand",true);
        }
    }
   
}
