using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "BattleUnit", menuName ="BattleUnit/New BattleUnit")]
public class BattleUnit : ScriptableObject
{
    [SerializeField] string unitName;
    [SerializeField] Sprite unitSprite;

    [TextArea][SerializeField] string description;

    [SerializeField] int damage;

    [SerializeField] int maxHP;

    public string UnitName {  get { return unitName; } }
    public string Description { get { return description; } }
    public int MaxHP { get { return maxHP; } }
    public int Damage { get { return damage; } }
    public Sprite Sprite { get { return unitSprite; } }


}
