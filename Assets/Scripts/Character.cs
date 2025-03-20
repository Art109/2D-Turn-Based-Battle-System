using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField] string characterName;
    [SerializeField] protected float maxHp;
    [SerializeField] protected float currentHP;
    public int speed;
    [SerializeField] List<Skill> skills;

    public virtual void TakeTurn(BattleManager battleManager) { }

    public virtual void TakeDamage(int damage) 
    {
        currentHP -= damage;
    }
}
