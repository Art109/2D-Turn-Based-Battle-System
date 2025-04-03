using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField] string characterName;
    [SerializeField] protected float maxHp;
    protected Animator animator;
    public float MaxHP { get { return maxHp; } }
    [SerializeField] protected float currentHP;
    public float CurrentHP { get { return currentHP; } }
    public int speed;
    [SerializeField] List<Skill> skills;

    public virtual void TakeTurn(BattleManager battleManager) { }

    public virtual void TakeDamage(int damage) 
    {
        currentHP -= damage;
    }

    public virtual IEnumerator Attack(Character character)
    {
        character.TakeDamage(10);
        animator.SetTrigger("Attack");
        yield return new WaitForSeconds(1f);
        BattleManager.Instance.EndTurn();
    }
}
