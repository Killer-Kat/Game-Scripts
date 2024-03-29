﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public int coinValue = 1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;

        if (collisionGameObject.name == "Player")
        {
            FindObjectOfType<AudioManager>().Play("Coin");
            PlayerStats.Instance.currentMoney = PlayerStats.Instance.currentMoney + coinValue;
            FindObjectOfType<UIManager>().coinGUIupdate();
            Destroy(gameObject);
        }
    }
}
