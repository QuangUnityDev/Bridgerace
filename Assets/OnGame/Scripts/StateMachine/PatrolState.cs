using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : IState
{
    public void OnEnter(BotPlayer botPlayer)
    {
        botPlayer.SetTarget();
        botPlayer.ChangeAnim("Run");
        botPlayer.navAgent.SetDestination(botPlayer.target.position);
    }

    public void OnExcute(BotPlayer botPlayer)
    {   
        if (botPlayer.randomFinishState <= botPlayer.containBlock.childCount)
        {
            botPlayer.ChangState(new FinishState());
            return;
        }
        if(Vector3.Distance(botPlayer.transform.position,botPlayer.target.position) < 1.3f || botPlayer.target == null)
        {
            botPlayer.SetTarget();
            botPlayer.ChangeAnim("Run");
            botPlayer.navAgent.SetDestination(botPlayer.target.position);
        }
    }

    public void OnExit(BotPlayer botPlayer)
    {
        
    }
}
