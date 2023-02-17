using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonObject<GameManager>
{
    public GameObject[] brick;
    public GameObject[] blockBuildBridge;
    public string[,] a;
    [SerializeField] GameObject blockRed;
    [HideInInspector]public int[,] sa = new int[9, 12];
    enum typeBrick
    {
        block0 = 1,
        block1 = 2,
        wall = 0
    }
    public void BuildBridge(int typeBlock,Vector3 pos)
    {
        Instantiate(blockBuildBridge[typeBlock], pos,Quaternion.identity);
    }
    private void Awake()
    {
        LoadText();
        //InvokeRepeating(nameof(SpawnBlockRandom),0,5);
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
                        SpawnBlock.GetInstance().SpawnBlockRed(new Vector3(i, 0.2f, j));
                        sa[i, j] = 1;
                    }
                }
            }
        }
    }
    private void LoadText()
    {
        string data = Resources.Load<TextAsset>("Maps/Map1").text;
        //Tach mang thanh 
        string[] save = data.Split(new string[] { "\n" }, System.StringSplitOptions.None);
        a = new string[9, 32];
        for (int i = 0; i < 9; i++)
        {
            // save[0] {0,1,0,0}
            //Debug.Log(save[0]);
            string[] temp = save[i].Split(",");
            for (int j = 0; j < 32; j++)
            {
                // lay gia tri tung phan tu
                a[i, j] = temp[j];
                //Debug.Log(a[i, j]);
                RendMap(a[i, j], i, j);

            }

        }

    }
    void RendMap(string a, float x, float z)
    {
        int b = int.Parse(a);
        switch (b)
        {
            case (int)(typeBrick.block0):
                Instantiate(brick[0], new Vector3(x, 0, z), Quaternion.identity, transform);
                break;
            case (int)(typeBrick.block1):
                Instantiate(brick[1], new Vector3(x, 0.5f, z), Quaternion.identity, transform);
                break;
            case (int)(typeBrick.wall):
                Instantiate(brick[2], new Vector3(x, 0.5f , z), Quaternion.identity, transform);
                break;
            default:
                break;
        }
    }    
}
