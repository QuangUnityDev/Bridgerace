using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckFloor : MonoBehaviour
{
    public bool isPass;
    public int indexFloor;

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && indexFloor == 1) 
        {
            isPass = true;
            GameManager.GetInstance().PLayerGenBlockFollowColor();  

        }
        else if(other.CompareTag("BotPlayer") && indexFloor == 1)
        {
            GameManager.GetInstance().GenBlockFollowColorBot(other.GetComponent<BotPlayer>());
        }
    }
}
