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
    private UIManager UIMan;
    private AudioManager audioMan;
    
    // Start is called before the first frame update
    void Start()
    {
        
        Invoke("Startup", 0.1f);
        playerMan = FindObjectOfType<PlayerController>();
        UIMan = FindObjectOfType<UIManager>();
        audioMan = FindObjectOfType<AudioManager>();
        levelText.text = "Level: " + PlayerStats.Instance.playerLevel;
    }

    public void giveExp(int expToGive)
    {
        PlayerStats.Instance.currentExp = PlayerStats.Instance.currentExp + expToGive;
        upDateStats();
    }
    void upDateStats()
    {
        if (PlayerStats.Instance.currentExp >= expToLevelup[PlayerStats.Instance.playerLevel + 1])
        {
            PlayerStats.Instance.playerLevel++;
            PlayerStats.Instance.currentExp = PlayerStats.Instance.currentExp - expToLevelup[PlayerStats.Instance.playerLevel];
            audioMan.Play("LevelUpSound");
            PlayerStats.Instance.maxHealth = PlayerStats.Instance.maxHealth + PlayerStats.Instance.playerLevel;
            PlayerStats.Instance.currentHealth = PlayerStats.Instance.maxHealth;
            PlayerStats.Instance.damage = PlayerStats.Instance.damage + 1;
            if(PlayerStats.Instance.playerLevel % 2 == 0)
            {
                PlayerStats.Instance.moveSpeed = PlayerStats.Instance.moveSpeed + 0.1f;
                playerMan.cacheSpeed();
            }
            if (PlayerStats.Instance.playerLevel % 10 == 0)
            {
                PlayerStats.Instance.playerArmor = PlayerStats.Instance.playerArmor + 1;
                UIMan.armorGUIupdate();
            }
            if (PlayerStats.Instance.currentExp >= expToLevelup[PlayerStats.Instance.playerLevel] + expToLevelup[PlayerStats.Instance.playerLevel + 1])
            {
                upDateStats();
            }
            
        }
        levelText.text = "Level: " + PlayerStats.Instance.playerLevel;
        
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
