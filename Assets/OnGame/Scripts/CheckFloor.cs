using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckFloor : MonoBehaviour
{
    public bool isPass;
    public int indexFloor;
    public Block block,blockRed,blockYellow,blockBlue;

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && indexFloor == 1) 
        {
            isPass = true;
            block.isFloor2 = true;
            GameManager.GetInstance().PLayerGenBlockFollowColor();

        }
        else if (other.CompareTag("Player") && indexFloor == 2)
        {
            isPass = true;
            ManagerUI.GetInstance().Win();
            Debug.LogError("Win");           
        }
        else if(other.CompareTag("BotPlayer") && indexFloor == 1)
        {
            switch ((int)other.transform.GetComponent<BotPlayer>().typePlayerColor) 
            {
                case (int)Block.TypeBlock.BlockRed:
                    blockRed.isFloor2 = true;                    
                    break;
                case (int)Block.TypeBlock.BlockBlue:
                    blockBlue.isFloor2 = true;
                    break;
                case (int)Block.TypeBlock.BlockYellow:
                    blockYellow.isFloor2 = true;
                    break;
                default:
                    break;
            }
            GameManager.GetInstance().GenBlockFollowColorBot(other.GetComponent<BotPlayer>());
        }
       
    }
}
