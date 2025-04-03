using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public enum PlayerBattleSelectionState { NO_Selection, AttackSelection, SkillSelection, ItemSelection, RunSelection}

public class PlayerBattleController :MonoBehaviour
{
    public static PlayerBattleController Instance;
    PlayerCharacter currentCharacter;
    public PlayerCharacter CurrentCharacter { get { return currentCharacter; }}
    PlayerBattleSelectionState selectionState = PlayerBattleSelectionState.NO_Selection;
   
    int actionIndex = 0;


    List<EnemyCharacter> enemyList = new List<EnemyCharacter>();

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
        if (selectionState == PlayerBattleSelectionState.NO_Selection)
            ActionSelection();
        else if (selectionState == PlayerBattleSelectionState.AttackSelection)
            Attack();
        else if (selectionState == PlayerBattleSelectionState.SkillSelection)
            Skill();
        else if (selectionState == PlayerBattleSelectionState.ItemSelection)
            Item();
        else if (selectionState == PlayerBattleSelectionState.RunSelection)
            Run();

    }

    public void TakeAction(PlayerCharacter character)
    {
        
        currentCharacter = character;
        BattleUIManager.Instance.UpdatePlayerActions(currentCharacter);
        selectionState = PlayerBattleSelectionState.NO_Selection;
    }

    void ActionSelection()
    {
            
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
            switch (actionIndex)
            { 
                case 0:
                    selectionState = PlayerBattleSelectionState.AttackSelection;
                    break;
                case 1:
                    selectionState = PlayerBattleSelectionState.SkillSelection;
                    break;
                case 2:
                    selectionState = PlayerBattleSelectionState.AttackSelection;
                    break;
                case 3:
                    selectionState = PlayerBattleSelectionState.AttackSelection;
                    break;
            }
        }
    }

    bool initializedParams = false;
    EnemyCharacter enemyCharacterTargeted;
    

    void Attack()
    {
        // Target Selection -> Player.Attack
        if (!initializedParams)
        {
            enemyList = BattleManager.Instance.GetEnemyList();
            enemyCharacterTargeted = null;
            
            Debug.Log("Lista de inimigos" + enemyList);
        }
        

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            actionIndex--;
            if(actionIndex < 0)
                actionIndex = enemyList.Count - 1;
            Debug.Log(actionIndex);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            actionIndex++;
            if (actionIndex >= enemyList.Count)
                actionIndex = 0;
            Debug.Log(actionIndex);
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            enemyCharacterTargeted = enemyList[actionIndex];
        }

        Debug.Log("O inimigo selecionado no momento é " + enemyList[actionIndex]);

        if (enemyCharacterTargeted != null)
            StartCoroutine(currentCharacter.Attack(enemyCharacterTargeted));
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
