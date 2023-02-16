using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonObject<GameManager>
{
    public GameObject[] brick;
    public string[,] a;
    [SerializeField] int numberBlock;
    [SerializeField] GameObject blockRed;
    [HideInInspector]public int[,] sa = new int[6, 5];
    enum typeBrick
    {
        block0 = 1,
    }
    private void Awake()
    {
        LoadText();
        SpawnBlockRandom();
    }
    public void SpawnBlockRandom()
    {
       
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (sa[i, j] == 0)
                {
                    {
                        sa[i, j] = 1;
                        SpawnBlock.GetInstance().SpawnBlockRed(new Vector3(i, 0.2f, j));
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
        a = new string[6, 5];
        for (int i = 0; i < 6; i++)
        {
            // save[0] {0,1,0,0}
            //Debug.Log(save[0]);
            string[] temp = save[i].Split(",");
            for (int j = 0; j < 5; j++)
            {
                // lay gia tri tung phan tu
                a[i, j] = temp[j];
                Debug.Log(a[i, j]);
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
                GameObject go = Instantiate(brick[0], new Vector3(x, 0, z), Quaternion.identity, transform);

                break;
            default:
                break;
        }
    }
}
