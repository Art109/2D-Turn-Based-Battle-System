using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST}


public class BattleSystem : MonoBehaviour
{

    public BattleState state;

    public Text playerHUDName;

    [SerializeField] PlayerController player;

    List<Enemy> enemyList;
    private void Start()
    {
        state = BattleState.START;
    }

    public void SetupBattle(List<BattleUnit> battleUnits)
    {
        
    }
}
