using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    [SerializeField] BattleUnit enemyBase;
    SpriteRenderer spriteRenderer;

    string enemyName;
    string enemyDescription;
    int damage;
    int maxHP;
    [SerializeField]int currentHP;



    [Header("EnemyHud Settings")]
    [SerializeField] GameObject canvas;
    [SerializeField]Text textName;
    [SerializeField]Image HpBar;
    float currentHPfill;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        enemyName = enemyBase.UnitName;
        enemyDescription = enemyBase.Description;
        damage = enemyBase.Damage;
        maxHP = enemyBase.MaxHP;
        currentHP = maxHP;
        textName.text = enemyName;

        spriteRenderer.sprite = enemyBase.Sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    void EnemyHudUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            if (canvas.activeInHierarchy)
            {
                canvas.SetActive(false);
            }
            else 
            {
                canvas.SetActive(true);
            
            }
        }
    }

    void UpdateHpHUD()
    {
        currentHPfill = (float)currentHP / (float)maxHP;
        HpBar.fillAmount = currentHPfill;
    }
}
