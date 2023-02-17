using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.CompareTag("Block"))
        {
            collision.gameObject.SetActive(false);
            
        }
    }
}
