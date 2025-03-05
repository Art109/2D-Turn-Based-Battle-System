using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField] string characterName;
    [SerializeField] int hp;
    public int speed;
    [SerializeField] List<Skill> skills;

    public virtual void TakeTurn(BattleManager battleManager) { }
}
