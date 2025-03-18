using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public static BattleManager Instance;

    public List<Character> characters = new List<Character>();
    int currentTurnIndex = 0;

    bool isBattleActive = false;

    [SerializeField] EnemyCharacter enemyTest;

    private void Awake()
    {
        if(Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            List<Character> enemy = new List<Character>();
            enemy.Add(enemyTest);    
            StartBattle(enemy);
        }
    }


    public void StartBattle(List<Character> participants)
    {
        if (isBattleActive) return;
        PlayerController.Instance.PlayerState = PlayerState.Battle;
        isBattleActive = true;
        characters.Add(PlayerController.Instance.PlayerUnit);
        foreach (Character character in participants)
        {
            characters.Add(character);
        }

        StartTurn();
    }

    void StartTurn()
    {
        
            if (characters.Count == 0) return;
            Character currentCharacter = characters[currentTurnIndex];
            BattleUIManager.Instance.UpdateUI(currentCharacter);
            currentCharacter.TakeTurn(this);
    }

    public void EndTurn()
    {
        currentTurnIndex = (currentTurnIndex +1) % characters.Count;
        StartTurn();

    }

    public void EndBattle()
    {
        BattleUIManager.Instance.DeactiveUI();
    }

}
