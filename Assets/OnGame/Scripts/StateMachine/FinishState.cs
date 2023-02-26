using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishState : IState
{
    public void OnEnter(BotPlayer botPlayer)
    {
        botPlayer.navAgent.SetDestination(botPlayer.lastPos.position);
    }

    public void OnExcute(BotPlayer botPlayer)
    {
        
        if (Vector3.Distance(botPlayer.transform.position,botPlayer.lastPos.position)  < 1.2f)
        {
            Debug.LogError("BotWIn");
            botPlayer.ChangState(new IdleState());
            botPlayer.ChangeAnim("Dance");
        }
        else
        if (botPlayer.blockOwner <= 0)
        {
            botPlayer.ChangState(new PatrolState());
        }
        else botPlayer.navAgent.SetDestination(botPlayer.lastPos.position);
    }

    public void OnExit(BotPlayer botPlayer)
    {
    }
}
