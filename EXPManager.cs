using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EXPManager : MonoBehaviour
{
    
    public int playerLevel = 1;
    public int maxLevel = 100;
    public Text levelText;
    public int currentExp;
    public int baseExp = 1000;
    public int[] expToLevelup;
    private HealthManager healthMan;
    private PlayerController playerMan;
    private UIManager UIMan;
    private AudioManager audioMan;
    public int currentMoney;
    public int currentHealthPotions;
    // Start is called before the first frame update
    void Start()
    {
        levelText.text = "Level: " + playerLevel;
        expToLevelup = new int[maxLevel];
        expToLevelup[1] = baseExp;
        for(int i = 2; i < expToLevelup.Length; i++)
        {
            expToLevelup[i] = Mathf.FloorToInt(expToLevelup[i - 1] * 1.25f);
        }
        healthMan = FindObjectOfType<HealthManager>();
        playerMan = FindObjectOfType<PlayerController>();
        UIMan = FindObjectOfType<UIManager>();
        audioMan = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void giveExp(int expToGive)
    {
        currentExp = currentExp + expToGive;
        upDateStats();
    }
    void upDateStats()
    {
        if (currentExp >= expToLevelup[playerLevel] + expToLevelup[playerLevel + 1])
        {
            playerLevel++;
            audioMan.Play("LevelUpSound");
            healthMan.maxHealth = healthMan.maxHealth + playerLevel;
            healthMan.currentHealth = healthMan.maxHealth;
            playerMan.damage = playerMan.damage + 1;
            if(playerLevel % 2 == 0)
            {
                playerMan.moveSpeed = playerMan.moveSpeed + 0.1f;
            }
            if (playerLevel % 10 == 0)
            {
                healthMan.playerArmor = healthMan.playerArmor + 1;
            }
        }
        levelText.text = "Level: " + playerLevel;
        UIMan.expBarUpdate();
    }
}
