using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerBattleController :MonoBehaviour
{
    public static PlayerBattleController Instance;
    PlayerCharacter currentCharacter;
    public PlayerCharacter CurrentCharacter { get { return currentCharacter; }}

    int actionIndex = 0;
    bool actionSelected = false;


    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
    }

    private void Start()
    {
        
    }

    public void PlayerControl()
    {
        ActionSelection();
    }

    public void TakeAction(PlayerCharacter character)
    {
        
        currentCharacter = character;
        BattleUIManager.Instance.UpdatePlayerActions(currentCharacter);
        actionSelected = false;
    }

    void ActionSelection()
    {
        if (actionSelected) return;
            
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            actionIndex--;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            actionIndex++;
        }

        if(actionIndex > 3)
            actionIndex = 0;
        else if(actionIndex < 0)
            actionIndex = 3;

        BattleUIManager.Instance.ActionSelectionAnimation(actionIndex);

        if (Input.GetKeyDown(KeyCode.Z))
        {
            actionSelected = true;
            switch (actionIndex)
            { 
                case 0:
                    Attack();
                    break;
                case 1:
                    Skill();
                    break;
                case 2:
                    Item();
                    break;
                case 3:
                    Run();
                    break;
            }
        }
    }

    void Attack()
    {
        // Target Selection -> Player.Attack
        EnemyCharacter enemyCharacter = FindAnyObjectByType<EnemyCharacter>();
        StartCoroutine(currentCharacter.Attack(enemyCharacter));
    }

    void Skill()
    {
        //Skill Selection -> TypeVerifier -> TargetSelection -> Player.Skill
    }

    void Item()
    {
        //Item Selection -> ItemTypeVerifier -> UseSelection -> If ItemActionHaveTarget(Target Selection) -> ReturnActionSelection
    }

    void Run()
    {
        //EnemyVerify -> TryRun -> If Sucess EndBattle Else End Turn
    }
}
