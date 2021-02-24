using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public int playerLevel = 1;
    public int maxLevel = 100;
    public Text levelText;
    public int currentExp;
    public int baseExp = 1000;
    public int[] expToLevelup;
    // Start is called before the first frame update
    void Start()
    {
        levelText.text = "Level: " + playerLevel;
        expToLevelup = new int[maxLevel];
        expToLevelup[1] = baseExp;
        for(int i = 2; i < expToLevelup.Length; i++)
        {
            expToLevelup[i] = Mathf.FloorToInt(expToLevelup[i - 1] * 1.05f);
        }
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
        levelText.text = "Level: " + playerLevel;
        if (expToLevelup[playerLevel] + expToLevelup[playerLevel + 1] >= currentExp)
        {
            playerLevel++;
        }
    }
}
