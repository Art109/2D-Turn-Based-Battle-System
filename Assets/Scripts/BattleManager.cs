using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public static BattleManager Instance;

    public List<Character> characters = new List<Character>();
    int currentTurnIndex = 0;

    bool isBattleActive = false;


    private void Awake()
    {
        if(Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
    }


    public void StartBattle(List<Character> participants)
    {
        if (isBattleActive) return;

        isBattleActive = true;
        characters = new List<Character>(participants);

        StartTurn();
    }

    void StartTurn()
    {
        
            if (characters.Count == 0) return;
            Character currentCharacter = characters[currentTurnIndex];
            currentCharacter.TakeTurn(this);
    }

    public void EndTurn()
    {
        currentTurnIndex = (currentTurnIndex +1) % characters.Count;
        StartTurn();

    }

    public void EndBattle()
    {

    }
}
