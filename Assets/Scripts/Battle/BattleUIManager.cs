using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleUIManager : MonoBehaviour
{
    public static BattleUIManager Instance;

    [SerializeField] GameObject playerOptionsBox;
    [SerializeField] List<TextMeshProUGUI> playerOptions;
    [SerializeField] GameObject playerHUD;
    [SerializeField] List<GameObject> playerCharactersHUD;
    [SerializeField] GameObject battleTextPanel;
    [SerializeField] TextMeshProUGUI battleText;

    
    // Start is called before the first frame update
    void Start()
    {
        if(Instance != null && Instance != this)
            Destroy(Instance);
        else
            Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateUI(Character character) 
    {
        DeactiveUI();
        if (character is PlayerCharacter)
        {
            playerOptionsBox.SetActive(true);
            
        }
        playerHUD.SetActive(true);
        battleTextPanel.SetActive(true);
    }

    public void ActionSelectionAnimation(int index)
    {
        foreach (var option in playerOptions)
        { 
            option.color = Color.white;
        }

        playerOptions[index].color = Color.black;
    }

    public void UpdatePlayerActions(PlayerCharacter character)
    {

    }

    public void DeactiveUI()
    {
        playerOptionsBox.SetActive(false);
        playerHUD.SetActive(false);
        battleTextPanel.SetActive(false);

    }
}
