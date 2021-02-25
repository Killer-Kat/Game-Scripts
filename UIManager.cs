using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private HealthManager healthMan;
    private PlayerStats pStats;
    public Slider ExpBar;
    public Text xpText;
    public Slider healthBar;
    public Text hpText;
    public Text coinText;
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
        expBarUpdate();
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.maxValue = healthMan.maxHealth;
        healthBar.value = healthMan.currentHealth;
        hpText.text = "HP: " + healthMan.currentHealth + "/" + healthMan.maxHealth;
    }
    public void expBarUpdate()
    {
        int ExpForNextLvl = pStats.expToLevelup[pStats.playerLevel] + pStats.expToLevelup[pStats.playerLevel + 1];
        ExpBar.maxValue = ExpForNextLvl;
        ExpBar.value = pStats.currentExp;
        xpText.text = "XP: " + pStats.currentExp + "/" + ExpForNextLvl;
    }
    public void coinGUIupdate()
    {
    coinText.text = "" + pStats.currentMoney;
    }
}
