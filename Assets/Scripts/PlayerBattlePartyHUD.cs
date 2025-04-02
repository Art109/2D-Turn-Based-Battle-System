using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBattlePartyHUD : MonoBehaviour
{
    public static PlayerBattlePartyHUD Instance;

    [SerializeField]List<GameObject> playerBars;
    [SerializeField]List<Image> playerHPFills;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(Instance);
        }
        else
        {
            Instance = this;
        }
    }

    private void OnEnable()
    {
        StartHUD();
    }

    void StartHUD()
    {
        foreach (GameObject bar in playerBars)
        { 
            bar.SetActive(false);
        }
        for (int i = 0; i < PlayerController.Instance.PlayerParty.Count; i++)
        {
            playerBars[i].SetActive(true);
        }
        UpdateHP();
    }


    void UpdateHP()
    {
        for (int i = 0; i < PlayerController.Instance.PlayerParty.Count; i++)
        {
            playerHPFills[i].fillAmount = PlayerController.Instance.PlayerParty[i].CurrentHP / PlayerController.Instance.PlayerParty[i].MaxHP;
        }
    }
    
    public void UpdateHP(PlayerCharacter character) 
    {
        if (character != null)
        {
            for (int i = 0; i < PlayerController.Instance.PlayerParty.Count; i++)
            {
                if (character.Equals(PlayerController.Instance.PlayerParty[i]))
                {
                    playerHPFills[i].fillAmount = PlayerController.Instance.PlayerParty[i].CurrentHP / PlayerController.Instance.PlayerParty[i].MaxHP;
                    break;
                }
            }
        }
    }


}
