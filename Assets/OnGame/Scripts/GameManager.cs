using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonObject<GameManager>
{
    public GameObject[] brick;
    public List<GameObject> blockRed, blockBlue, blockGreen, blockYellow;
    public Transform blockRedContain, blockBlueContain, blockGreenContain, blockYellowContain;
    public PlayerController playerController;
    public List<Transform> posFloor;
    [SerializeField] private Block block;

    private void Awake()
    {
        SpawnBlockRandom();
    }
    public void PLayerGenBlockFollowColor()
    {
        blockGreenContain.transform.position = posFloor[0].position;
        block.OnInit();
    }
    public void GenBlockFollowColorBot(BotPlayer playerController)
    {
        switch (playerController.typePlayerColor)
        {
            case BotPlayer.TypePlayer.PlayerRed:
                blockRedContain.transform.position = posFloor[0].position;
                break;
            case BotPlayer.TypePlayer.PlayerBlue:
                blockBlueContain.transform.position = posFloor[0].position;
                break;
            case BotPlayer.TypePlayer.PlayerGreen:
                blockGreenContain.transform.position = posFloor[0].position;
                break;
            case BotPlayer.TypePlayer.PlayerYellow:
                blockYellowContain.transform.position = posFloor[0].position;
                break;
            default:
                break;
        }
        block.OnInit();
    }
    public void ReturnBlock(GameObject gameObject)
    {
        switch (gameObject.GetComponent<Block>().typeBlockColor)
        {
            case (Block.TypeBlock.BlockRed):
                blockRed.Add(gameObject);
                gameObject.transform.SetParent(blockRedContain);
                break;
            case (Block.TypeBlock.BlockBlue):
                blockBlue.Add(gameObject);
                gameObject.transform.SetParent(blockBlueContain);
                break;
            case (Block.TypeBlock.BlockGreen):
                blockGreen.Add(gameObject);
                gameObject.transform.SetParent(blockGreenContain);
                break;
            case (Block.TypeBlock.BlockYellow):
                blockYellow.Add(gameObject);
                gameObject.transform.SetParent(blockYellowContain);
                break;
            default:
                break;
        }
    }
    public void RemoveBlock(GameObject gameObject)
    {
        switch (gameObject.GetComponent<Block>().typeBlockColor)
        {
            case (Block.TypeBlock.BlockRed):
                blockRed.Remove(gameObject);
                break;
            case (Block.TypeBlock.BlockBlue):
                blockBlue.Remove(gameObject); ;
                break;
            case (Block.TypeBlock.BlockGreen):
                blockGreen.Remove(gameObject);
                break;
            case (Block.TypeBlock.BlockYellow):
                blockYellow.Remove(gameObject);
                break;
            default:
                break;
        }
    }
    public void SpawnBlockRandom()
    {
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 12; j++)
            {
                {
                    GameObject go = SpawnBlock.GetInstance().SpawnBlockRed(new Vector3(i, 0, j));
                    switch ((int)go.transform.GetComponent<Block>().typeBlockColor)
                    {
                        case 0:
                            blockRed.Add(go);
                            go.transform.SetParent(blockRedContain);
                            break;
                        case 1:
                            blockBlue.Add(go);
                            go.transform.SetParent(blockBlueContain);
                            break;
                        case 2:
                            blockGreen.Add(go);
                            go.transform.SetParent(blockGreenContain);
                            break;
                        case 3:
                            blockYellow.Add(go);
                            go.transform.SetParent(blockYellowContain);
                            break;

                        default:
                            break;
                    }

                }
            }
        }
    }

}
