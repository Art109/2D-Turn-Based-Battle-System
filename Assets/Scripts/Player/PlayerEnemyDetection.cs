using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnemyDetection : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (PlayerController.Instance.PlayerState == PlayerState.Free)
        {
            if (collision.CompareTag("Enemy"))
            {
                EnemyCharacter enemy = collision.GetComponent<EnemyCharacter>();
                if (enemy != null)
                {
                    PlayerController.Instance.StopMovement();
                    BattleManager.Instance.StartBattle(enemy.enemyParty);
                    Debug.Log("Player começou a luta");
                }
            }
        }
    }
}
