using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBattleController 
{
    
    PlayerCharacter currentCharacter;
    public PlayerCharacter CurrentCharacter { get { return currentCharacter; }}

    int actionIndex = 0;

    // Update is called once per frame
    public void Update()
    {
        ActionSelection();
    }

    public void TakeAction(PlayerCharacter character)
    {
        
        currentCharacter = character;
        BattleUIManager.Instance.UpdatePlayerActions(currentCharacter);
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
    }

    IEnumerator Attack()
    {
        //EnemyCharacter enemyCharacter = FindAnyObjectByType<EnemyCharacter>();
        //enemyCharacter.TakeDamage(20);
        //animator.SetTrigger("Attack");
        yield return new WaitForSeconds(1f);
        BattleManager.Instance.EndTurn();
    }
}
