using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCharacter : Character
{

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

    public override IEnumerator Attack(Character character)
    {
        character.TakeDamage(20);
        animator.SetTrigger("Attack");
        yield return new WaitForSeconds(1f);
        BattleManager.Instance.EndTurn();
    }


}
