using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class EnemyCharacter : Character
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
        PlayerCharacter player = FindAnyObjectByType<PlayerCharacter>();
        player.TakeDamage(10);
        animator.SetTrigger("Attack");
        yield return new WaitForSeconds(1f);
        BattleManager.Instance.EndTurn();
    }

   
}
