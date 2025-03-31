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

    Animator animator;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
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
                    StartCoroutine(Attack());
                    break;
                case 1:
                    //Skills
                    break;
                case 2:
                    //Itens
                    break;
                case 3:
                    //Run
                    break;
            }
        }
    }

    IEnumerator Attack()
    {
        EnemyCharacter enemyCharacter = FindAnyObjectByType<EnemyCharacter>();
        enemyCharacter.TakeDamage(20);
        animator.SetTrigger("Attack");
        yield return new WaitForSeconds(1f);
        BattleManager.Instance.EndTurn();
    }
}
