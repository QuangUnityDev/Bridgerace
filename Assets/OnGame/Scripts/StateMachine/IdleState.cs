using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
    public void OnEnter(BotPlayer botPlayer)
    {
       
    }

    public void OnExcute(BotPlayer botPlayer)
    {
        
        if (GameManager.GetInstance().isStartGame)
        {
            botPlayer.ChangState(new PatrolState());
        }
        else botPlayer.ChangState(new IdleState());
    }

    public void OnExit(BotPlayer botPlayer)
    {
      
    }
}
