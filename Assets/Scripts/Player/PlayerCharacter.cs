using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : Character
{
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public override void TakeTurn(BattleManager battleManager)
    {
        PlayerBattleController.Instance.TakeAction(this);
    }

    
}
