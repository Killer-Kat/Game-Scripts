using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private HealthManager healthMan;
    private PlayerStats pStats;
    private EXPManager EXPMan;

    public Slider ExpBar;
    public Text xpText;
    public Slider healthBar;
    public Text hpText;
    public Text coinText;
    public Text healthPotionText;
    public Text armorText;
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
        healthMan = FindObjectOfType<HealthManager>();
        pStats = FindObjectOfType<PlayerStats>();
        EXPMan = FindObjectOfType<EXPManager>();
        Invoke("expBarUpdate", 1);
        Invoke("HealthBarUpdate", 1);
        healthPotionGUIupdate();
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update() //I know I need to change this, its old code from a tutorial
    {
        
    }
    public void HealthBarUpdate()
    {
        healthBar.maxValue = pStats.maxHealth;
        healthBar.value = pStats.currentHealth;
        hpText.text = "HP: " + pStats.currentHealth + "/" + pStats.maxHealth;
    }
    public void expBarUpdate()
    {
        int ExpForNextLvl = EXPMan.expToLevelup[pStats.playerLevel] + EXPMan.expToLevelup[pStats.playerLevel + 1];
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
        armorText.text = "Armor: " + pStats.playerArmor;
    }
}
