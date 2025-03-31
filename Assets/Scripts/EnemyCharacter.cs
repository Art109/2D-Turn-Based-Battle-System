using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCharacter : Character
{
    Animator animator;

    [SerializeField] Image hpBar; 

    public List<Character> enemyParty;

    private void Start()
    {
        animator = GetComponent<Animator>();
        currentHP = maxHp;
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

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        UpdateHpUi();
    }

    void UpdateHpUi()
    {
        hpBar.fillAmount = currentHP/maxHp;
    }


}
