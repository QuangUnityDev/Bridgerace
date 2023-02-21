using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPlayer : PlayerInf
{
    [SerializeField] private NavMeshAgent navAgent;
    [SerializeField] private Transform target;
    [SerializeField] private GameObject block;
    private int randomBridge;
    private int randomBlock;
    [SerializeField] private Transform[] Bridge;
    private void Start()
    {
        
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
        //if(Vector3.Distance(transform.position,target.position) < 0.1f)
        //{
        //    targetMoveNext();
        //}
        //else navAgent.SetDestination(target.position);

    }
    void StateUpBridge()
    {
        randomBridge = Random.Range(0, Bridge.Length);
    }
    void targetMoveNext()
    {
        Debug.LogError("Muc tieu ke tiep");
        randomBlock = Random.Range(0, block.transform.childCount);
        target = block.transform.GetChild(4).transform;
    }
}
