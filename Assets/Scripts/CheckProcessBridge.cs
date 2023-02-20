using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckProcessBridge : MonoBehaviour
{
    public Transform cubeCheck;
    public PlayerInf player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < transform.childCount - 4; i++)
        {      
            if((int)transform.GetChild(i).GetComponent<BlockBridge>().typeBlockColor != (int)player.typePlayerColor)
            {               
                cubeCheck.position = new Vector3(transform.GetChild(i).transform.position.x + 1.1f/2, transform.position.y, transform.GetChild(i).transform.position.z);
                return;
            }
            else if((int)transform.GetChild(i).GetComponent<BlockBridge>().typeBlockColor == (int)player.typePlayerColor)
            {
                cubeCheck.position = new Vector3(transform.GetChild(i).transform.position.x + 2.2f, transform.position.y, transform.GetChild(i).transform.position.z);
            }
        }
    }
}
