using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    bool isBuiled;
    void Start()
    {
        isBuiled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }   
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.transform.childCount > 0 && !isBuiled)
        {
            int child = collision.transform.childCount;
            GameObject buildFill = collision.gameObject.transform.GetChild(child - 1).gameObject;
            buildFill.transform.SetParent(null);                  
            GameManager.GetInstance().BuildBridge(1, new Vector3(transform.position.x ,0 ,transform.position.z));
            transform.GetComponent<BoxCollider>().enabled = false;
            buildFill.GetComponent<Block>().AppearAgain();
            isBuiled = true;
        }
    }  
}
