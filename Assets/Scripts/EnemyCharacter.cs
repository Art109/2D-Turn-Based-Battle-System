using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : Character
{
    public override void TakeTurn(BattleManager battleManager)
    {
        battleManager.EndTurn();
    }
}
