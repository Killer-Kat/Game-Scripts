using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public int playerLevel = 1;
    public Text levelText;
    public int currentExp;
    // Start is called before the first frame update
    void Start()
    {
        levelText.text = "Level: " + playerLevel;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
