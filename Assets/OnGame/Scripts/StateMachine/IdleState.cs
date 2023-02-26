using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
    public void OnEnter(BotPlayer botPlayer)
    {
        botPlayer.navAgent.SetDestination(botPlayer.lastPos.position);
    }

    public void OnExcute(BotPlayer botPlayer)
    {
      
    }

    public void OnExit(BotPlayer botPlayer)
    {
      
    }
}
