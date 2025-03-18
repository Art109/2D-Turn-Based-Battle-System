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
        DesactiveUI();
        if (character is PlayerCharacter)
        {
            playerOptionsBox.SetActive(true);
            playerHUD.SetActive(true);
            battleTextPanel.SetActive(true);
        }
        else if (character is EnemyCharacter) 
        { 
            battleTextPanel.SetActive(true) ;
        }
    }

    public void DesactiveUI()
    {
        playerOptionsBox.SetActive(false);
        playerHUD.SetActive(false);
        battleTextPanel.SetActive(false);

    }
}
