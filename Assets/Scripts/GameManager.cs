using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonObject<GameManager>
{
    public GameObject[] brick;
    public string[,] a;
    public List<GameObject> blockRed = new List<GameObject>();
    public List<GameObject> blockBlue;
    public List<GameObject> blockGreen;
    public List<GameObject> blockYellow;
    [HideInInspector] public int[,] sa = new int[9, 12];

    private void Awake()
    {
        SpawnBlockRandom();
    }

    public void SpawnBlockRandom()
    {
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 12; j++)
            {
                if (sa[i, j] == 0)
                {
                    {
                        GameObject go = SpawnBlock.GetInstance().SpawnBlockRed(new Vector3(i, 0, j));
                        switch ((int)go.transform.GetComponent<Block>().typeBlockColor)
                        {
                            case 0:
                                blockRed.Add(go);
                                break;
                            case 1:
                                blockBlue.Add(go);
                                break;
                            case 2:
                                blockGreen.Add(go);
                                break;
                            case 3:
                                blockYellow.Add(go);
                                break;

                            default:
                                break;
                        }

                    }
                }
            }
        }
    }

}
