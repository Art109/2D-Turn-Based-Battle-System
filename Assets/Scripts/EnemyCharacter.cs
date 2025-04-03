using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCharacter : Character
{

    [SerializeField] Image hpBar; 

    public List<Character> enemyParty;

    private void Start()
    {
        animator = GetComponent<Animator>();
        currentHP = maxHp;
    }

    public override void TakeTurn(BattleManager battleManager)
    {
        PlayerCharacter player = FindAnyObjectByType<PlayerCharacter>();
        StartCoroutine(Attack(player));
    }


    /*
    public override IEnumerator Attack(Character character) 
    { 
       
        player.TakeDamage(10);
        animator.SetTrigger("Attack");
        yield return new WaitForSeconds(1f);
        BattleManager.Instance.EndTurn();
    }*/

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        UpdateHpUi();
        if (currentHP <= 0)
        {
           StartCoroutine(Death());
        }
        
    }

    void UpdateHpUi()
    {
        hpBar.fillAmount = currentHP/maxHp;
    }

    IEnumerator Death()
    {
        animator.SetTrigger("Death");
        BattleManager.Instance.CharacterDeath(this);
        yield return new WaitForSeconds(animator.GetCurrentAnimatorClipInfo(0)[0].clip.length) ;
        Destroy(gameObject);
    }

   


}
