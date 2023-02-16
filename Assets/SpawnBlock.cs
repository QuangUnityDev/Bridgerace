using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlock : SingletonObject<SpawnBlock>
{
    [SerializeField] List<GameObject> blockRed;
    [SerializeField] bool isCreateNew = false;

    private bool _isHadObject = false;

    public GameObject SpawnBlockRed(Vector3 pos)
    {
        for (int i = 0; i < blockRed.Count; i++)
        {
            if (!blockRed[i].gameObject.activeSelf)
            {
                blockRed[i].transform.position = pos;
                blockRed[i].gameObject.SetActive(true);
                return blockRed[i];
            }
        }

        GameObject more = Instantiate(blockRed[Random.Range(0,4)].gameObject, gameObject.transform);
        more.transform.position = pos;
        more.gameObject.SetActive(true);
        blockRed.Add(more);
        return more.gameObject;
    }
}
