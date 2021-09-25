using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EXPManager : MonoBehaviour
{
    public static EXPManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            // DontDestroyOnLoad(gameObject); //We dont need this here because its a child gameobject of the main UI which is already set to Dont Destroy on load.
        }
        else
        {
            Destroy(gameObject); //Failsafe we shoud (hopefully) NEVER have to use this due to the starting level.
        }
    }
    public TextMeshProUGUI levelText;

    public int maxLevel = 100;
    public int baseExp = 1000;
    public int[] expToLevelup;

    private PlayerController playerMan;
    private PlayerStats pStats;
    private UIManager UIMan;
    private AudioManager audioMan;
    
    // Start is called before the first frame update
    void Start()
    {
        
        Invoke("Startup", 0.1f);
        playerMan = FindObjectOfType<PlayerController>();
        UIMan = FindObjectOfType<UIManager>();
        pStats = FindObjectOfType<PlayerStats>();
        audioMan = FindObjectOfType<AudioManager>();
        levelText.text = "Level: " + pStats.playerLevel;
    }

    public void giveExp(int expToGive)
    {
        pStats.currentExp = pStats.currentExp + expToGive;
        upDateStats();
    }
    void upDateStats()
    {
        if (pStats.currentExp >= expToLevelup[pStats.playerLevel + 1])
        {
            pStats.playerLevel++;
            pStats.currentExp = pStats.currentExp - expToLevelup[pStats.playerLevel];
            audioMan.Play("LevelUpSound");
            pStats.maxHealth = pStats.maxHealth + pStats.playerLevel;
            pStats.currentHealth = pStats.maxHealth;
            pStats.damage = pStats.damage + 1;
            if(pStats.playerLevel % 2 == 0)
            {
                pStats.moveSpeed = pStats.moveSpeed + 0.1f;
                playerMan.cacheSpeed();
            }
            if (pStats.playerLevel % 10 == 0)
            {
                pStats.playerArmor = pStats.playerArmor + 1;
                UIMan.armorGUIupdate();
            }
            if (pStats.currentExp >= expToLevelup[pStats.playerLevel] + expToLevelup[pStats.playerLevel + 1])
            {
                upDateStats();
            }
            
        }
        levelText.text = "Level: " + pStats.playerLevel;
        
        UIMan.expBarUpdate();
        UIMan.HealthBarUpdate();
    }
    private void Startup()
    {
        expToLevelup = new int[maxLevel];
        expToLevelup[1] = baseExp;
        for (int i = 2; i < expToLevelup.Length; i++)
        {
            expToLevelup[i] = Mathf.FloorToInt(expToLevelup[i - 1] * 1.10f);
        }
    }
}
