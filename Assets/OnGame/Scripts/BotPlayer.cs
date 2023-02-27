using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotPlayer : Charecter
{
    public NavMeshAgent navAgent;
    public Transform target;
    public Transform lastPos;
    private IState currentState;
    public int randomFinishState;

    private void Start()
    {
        randomFinishState = Random.Range(3, 10);
        navAgent.speed = speed;
        OnInit();
    }
    public void ChangState(IState newState)
    {        
        //Debug.LogError(newState);
        if (currentState != null)
        {
            currentState.OnExit(this);
        }
        currentState = newState;
        if (currentState != null)
        {
            currentState.OnEnter(this);
        }
    }
    void Update()
    {
        if (!GameManager.GetInstance().isStartGame) return;
        blockOwner = containBlock.childCount;
        if (currentState != null)
        {
            currentState.OnExcute(this);
        }
    }
    public void SetTarget()
    {
        switch (typePlayerColor)
        {
            case TypePlayer.PlayerRed:
                target = GameManager.GetInstance().blockRed[Random.Range(0, GameManager.GetInstance().blockRed.Count)].transform;
                break;
            case TypePlayer.PlayerBlue:
                target = GameManager.GetInstance().blockBlue[Random.Range(0, GameManager.GetInstance().blockBlue.Count)].transform;
                break;
            case TypePlayer.PlayerGreen:
                target = GameManager.GetInstance().blockGreen[Random.Range(0, GameManager.GetInstance().blockGreen.Count)].transform;
                break;
            case TypePlayer.PlayerYellow:
                target = GameManager.GetInstance().blockYellow[Random.Range(0, GameManager.GetInstance().blockYellow.Count)].transform;
                break;
            default:
                break;
        }
    }
    void OnInit()
    {
        ChangState(new IdleState());
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Block"))
        {
            if ((int)typePlayerColor == (int)other.GetComponent<Block>().typeBlockColor)
            {
                GameManager.GetInstance().RemoveBlock(other.gameObject);
                int child = containBlock.transform.childCount;
                other.transform.SetParent(containBlock.transform);
                blockOfPlayer.Add(other.gameObject);
                other.transform.SetLocalPositionAndRotation(new Vector3(containBlock.transform.localPosition.x, containBlock.transform.localPosition.y + 0.3f * child, containBlock.transform.localPosition.z), containBlock.localRotation);
                
            }
        }
    }  
}