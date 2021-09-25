using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New JuiceThatMakesYouExplode", menuName = "Inventory/Potions/JuiceThatMakesYouExplode")]
public class Potion_JuiceThatMakesYouExplode : Potion
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void DrinkPotion() 
    {
        PlayerStats.Instance.playerMan.myAnimator.Play("Explode");
        HealthManager.Instace.HurtPlayer(100);
    }
}
