using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public List<Character> characters;
    int currentTurnIndex = 0;

    private void Start()
    {
        //characters.Sort(a,b) => b.speed.CompareTo(a.speed));
        StartTurn();
    }

    void StartTurn()
    {
        if(characters.Count == 0) return;
        Character currentCharacter = characters[currentTurnIndex];
        currentCharacter.TakeTurn(this);
    }

    public void EndTurn()
    {
        currentTurnIndex = (currentTurnIndex +1) % characters.Count;
        StartTurn();

    }
}
