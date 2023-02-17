using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlock : SingletonObject<SpawnBlock>
{
    [SerializeField] List<GameObject> block;
    [SerializeField] bool isCreateNew = false;

    private bool _isHadObject = false;

    public GameObject SpawnBlockRed(Vector3 pos)
    {
        for (int i = 0; i < block.Count; i++)
        {
            if (!block[i].gameObject.activeSelf)
            {
                block[i].transform.position = pos;
                block[i].gameObject.SetActive(true);
                return block[i];
            }
        }

        GameObject more = Instantiate(block[Random.Range(0,4)].gameObject, gameObject.transform);
        more.transform.position = pos;
        more.gameObject.SetActive(true);
        block.Add(more);
        return more.gameObject;
    }   
}
