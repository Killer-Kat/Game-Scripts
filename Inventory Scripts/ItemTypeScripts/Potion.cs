using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Potion : Item 
{
    public float potionDurration = 30f;
    public bool hasInstantEffect;
    public string drinkSound = "PotionDrink";
    public override void Use()
    {
        FindObjectOfType<AudioManager>().Play(drinkSound);
        DrinkPotion();
        RemoveFromInventory();
    }
    public abstract void DrinkPotion();
    
}
