using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPlayer : PlayerInf
{
    [SerializeField] private NavMeshAgent navAgent;
    [SerializeField] private Transform target;
    private int randomBridge;
    private int randomBlockOnBridge;
    private int randomBlock;
    [SerializeField] private Transform[] Bridge;
    private void Start()
    {
        Init();
    }
    void Init()
    {
        targetMoveNext();
        StateUpBridge();
    }
    void Update()
    {
        blockOwner = transform.childCount;
        navAgent.SetDestination(target.position);
        if (randomBlockOnBridge == blockOwner)
        {     
            if (Vector3.Distance(transform.position, target.position) < 1.2f)
            {
                Debug.LogError("Xuong cau");
                StateUpBridge();
                targetMoveNext();
            }
            else target = Bridge[randomBridge].transform.GetChild(blockOwner).transform;
        }
        else
        if (Vector3.Distance(transform.position, target.position) < 1.2f)
        {
            Debug.LogError(randomBlock);
            targetMoveNext();
        }
        else navAgent.SetDestination(target.position);
    }
    void StateUpBridge()
    {
        randomBridge = Random.Range(0, Bridge.Length);
        randomBlockOnBridge = Random.Range(0, Bridge[randomBridge].transform.childCount - 3);
    }
    void targetMoveNext()
    {
        randomBlock = Random.Range(0, GameManager.GetInstance().blockBlue.Count);
        target = GameManager.GetInstance().blockBlue[randomBlock].transform;
    }
}
