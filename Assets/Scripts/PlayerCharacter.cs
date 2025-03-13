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
        StartCoroutine(Attack());
    }

    IEnumerator Attack()
    {
        EnemyCharacter enemyCharacter = FindAnyObjectByType<EnemyCharacter>();
        enemyCharacter.TakeDamage(20);
        animator.SetTrigger("Attack");
        yield return new WaitForSeconds(1f);
        BattleManager.Instance.EndTurn();
    }
}
