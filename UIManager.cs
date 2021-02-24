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

    // Start is called before the first frame update
    void Start()
    {
        healthMan = FindObjectOfType<HealthManager>();
        pStats = FindObjectOfType<PlayerStats>();
        expBarUpdate();
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
}
