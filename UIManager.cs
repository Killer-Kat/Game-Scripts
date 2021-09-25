using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    private PlayerStats pStats;

    public Slider ExpBar;
    public TextMeshProUGUI xpText;
    public Slider healthBar;
    public TextMeshProUGUI hpText;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI healthPotionText;
    public TextMeshProUGUI armorText;
    private GameObject[] GUIs;

    //This is so that I dont generate multiple GUI's 
    private void OnLevelWasLoaded(int level)
    {
        GUIs = GameObject.FindGameObjectsWithTag("MainGUI");

        if (GUIs.Length > 1)
        {
            Destroy(GUIs[1]);
        }
    }

    void Start()
    {
        pStats = FindObjectOfType<PlayerStats>();
        Invoke("expBarUpdate", 1);
        Invoke("HealthBarUpdate", 1);
        healthPotionGUIupdate();
        DontDestroyOnLoad(gameObject);
    }
    public void UpdateAll()
    {
        HealthBarUpdate();
        expBarUpdate();
        coinGUIupdate();
        healthPotionGUIupdate();
        armorGUIupdate();
    }
   
    public void HealthBarUpdate()
    {
        healthBar.maxValue = pStats.maxHealth;
        healthBar.value = pStats.currentHealth;
        hpText.text = "HP: " + pStats.currentHealth + "/" + pStats.maxHealth;
    }
    public void expBarUpdate()
    {
        int ExpForNextLvl = EXPManager.Instance.expToLevelup[pStats.playerLevel + 1];
        ExpBar.maxValue = ExpForNextLvl;
        ExpBar.value = pStats.currentExp;
        xpText.text = "XP: " + pStats.currentExp + "/" + ExpForNextLvl;
    }
    public void coinGUIupdate()
    {
    coinText.text = "" + pStats.currentMoney;
    }
    public void healthPotionGUIupdate()
    {
        healthPotionText.text = "" + pStats.currentHealthPotions;
    }
    public void armorGUIupdate()
    {
        armorText.text = "Armor: " + (pStats.playerArmor + pStats.armormod);
    }
}
