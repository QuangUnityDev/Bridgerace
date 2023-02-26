using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    void OnEnter(BotPlayer botPlayer);
    void OnExcute(BotPlayer botPlayer);
    void OnExit(BotPlayer botPlayer);
}
