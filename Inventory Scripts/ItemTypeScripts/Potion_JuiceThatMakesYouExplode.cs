using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New JuiceThatMakesYouExplode", menuName = "Inventory/Potions/JuiceThatMakesYouExplode")]
public class Potion_JuiceThatMakesYouExplode : Potion
{
    PlayerStats pStats;
    HealthManager healthMan;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void DrinkPotion() 
    {
        pStats = FindObjectOfType<PlayerStats>();
        healthMan = FindObjectOfType<HealthManager>();
        pStats.playerMan.myAnimator.Play("Explode");
        healthMan.HurtPlayer(100);
    }
}
