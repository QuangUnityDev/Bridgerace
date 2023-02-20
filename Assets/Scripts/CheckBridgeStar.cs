using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBridgeStar : MonoBehaviour
{   
    //public static int typePlayer;
    public static GameObject typePlayer;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.transform.childCount > 0 || BlockBridge.isOnBridge)
        {
            this.gameObject.GetComponent<BoxCollider>().isTrigger = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        this.gameObject.GetComponent<BoxCollider>().isTrigger = false;
    }
}
