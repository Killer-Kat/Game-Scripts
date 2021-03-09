using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    [SerializeField]
    private int keyRef;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;

        if (collisionGameObject.name == "Player")
        {
            FindObjectOfType<AudioManager>().Play("Potion");
            FindObjectOfType<persistenceController>().KeyRing[keyRef] = true;
            Destroy(gameObject);
        }
    }
}
