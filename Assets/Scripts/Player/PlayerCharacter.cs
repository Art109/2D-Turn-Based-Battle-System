using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        PlayerBattlePartyHUD.Instance.UpdateHP(this);
    }


}
