using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionPickup : MonoBehaviour
{
    [SerializeField]
    private string potionType;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

   
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;

        if (collisionGameObject.name == "Player")
        {
            FindObjectOfType<AudioManager>().Play("Potion");
            if (potionType == "HealthPotion")
            {
                FindObjectOfType<PlayerStats>().currentHealthPotions = FindObjectOfType<PlayerStats>().currentHealthPotions + 1;
                FindObjectOfType<UIManager>().healthPotionGUIupdate();
            }
            Destroy(gameObject);
        }
    }
}
