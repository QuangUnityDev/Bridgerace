using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckProcessBridge : MonoBehaviour
{
    public Transform cubeCheckPlayer;
    //public Transform cubeCheckEnemy;
    public PlayerInf player;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.childCount > 0)
        {
            cubeCheckPlayer.transform.position = new Vector3(transform.GetChild(0).transform.position.x + 1.1f, cubeCheckPlayer.transform.position.y, transform.GetChild(0).transform.position.z);
        }
        for (int i = 0; i < transform.childCount - 4; i++)
        {
            if (player.transform.childCount < 0)
            {
                if ((int)transform.GetChild(i).GetComponent<BlockBridge>().typeBlockColor != (int)player.typePlayerColor)
                {
                    cubeCheckPlayer.transform.position = new Vector3(transform.GetChild(i).transform.position.x, cubeCheckPlayer.transform.position.y, transform.GetChild(i).transform.position.z);       
                }
                return;
            }
            if (player.transform.childCount > 0)
            {
                if ((int)transform.GetChild(i).GetComponent<BlockBridge>().typeBlockColor == (int)player.typePlayerColor)
                {
                    cubeCheckPlayer.transform.position = new Vector3(transform.GetChild(i).transform.position.x + 2.2f, cubeCheckPlayer.transform.position.y, transform.GetChild(i).transform.position.z);
                }
                if (i == transform.childCount)
                {
                    cubeCheckPlayer.GetComponent<BoxCollider>().isTrigger = true;
                }
            }
            
        }
    }
}
