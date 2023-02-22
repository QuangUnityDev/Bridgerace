using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckProcessBridge : MonoBehaviour
{
    public GameObject cubeCheckPlayer;
    //public Transform cubeCheckEnemy;
    public PlayerInf player;
    private bool isPassBridge;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        for (int i = 0; i < transform.childCount - 3; i++)
        {
            if ((int)transform.GetChild(i).GetComponent<BlockBridge>().typeBlockColor != (int)player.typePlayerColor)
            {
                if(BlockBridge.isOnBridge == true)
                {
                    cubeCheckPlayer.GetComponent<BoxCollider>().isTrigger = true;
                }
                else
                {
                    cubeCheckPlayer.GetComponent<BoxCollider>().isTrigger = false;
                }
                if (player.transform.childCount > 0)
                {
                    cubeCheckPlayer.transform.position = new Vector3(transform.GetChild(i).transform.position.x + 1.1f, cubeCheckPlayer.transform.position.y, transform.GetChild(i).transform.position.z);
                }
                else
                    cubeCheckPlayer.transform.position = new Vector3(transform.GetChild(i).transform.position.x, cubeCheckPlayer.transform.position.y, transform.GetChild(i).transform.position.z);
                return;
            }
            if ((int)transform.GetChild(transform.childCount - 4).GetComponent<BlockBridge>().typeBlockColor == (int)player.typePlayerColor && BlockBridge.isOnBridge == true)
            {
                cubeCheckPlayer.GetComponent<BoxCollider>().isTrigger = true;
            }
            else
            {
                cubeCheckPlayer.GetComponent<BoxCollider>().isTrigger = false;
            }
        }


    }
    private void OnTriggerExit(Collider other)
    {
        cubeCheckPlayer.GetComponent<BoxCollider>().isTrigger = false;
    }
}
