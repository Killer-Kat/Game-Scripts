using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lockedDoor : MonoBehaviour // I write code not tragedies:
{
    public persistenceController Pcon; //Oh, well imagine As I'm pacing the lines in a C# compiler
    private bool isLocked = true; //And I can't help but to hear No, I can't help but to hear an you declaring a bool 
    public SpriteRenderer DoorSpriteRender;//"What a beautiful C script, What a C script" says a IDE to a compiler
    public Rigidbody2D rb; //"And, yes, but what a shame, What a shame the memory optimization is poor"
    public BoxCollider2D BC;
    public int doorKey;
    public int doorRef;
    public Sprite closedDoorSprite; //I chime in with a, Haven't you people ever heard of closing the boolean door?
    public Sprite openDoorSprite; //No, it's much better to face these kinds of things With a sense of poise and rationality



    void Start()
    {
        
    }

    private void OnLevelWasLoaded(int level)
    {
        Pcon = FindObjectOfType<persistenceController>();
        if (Pcon.doorStatus[doorRef] == false)
        {
            isLocked = true;
            DoorSpriteRender.sprite = closedDoorSprite;
        }
        else if (Pcon.doorStatus[doorRef] == true)
        {
            isLocked = false;
            DoorSpriteRender.sprite = openDoorSprite;
            Destroy(rb);
            Destroy(BC);
        }
    }
    public void DoorOpen()
    {
        DoorSpriteRender.sprite = openDoorSprite;
        Destroy(rb);
        Destroy(BC);
        Pcon.doorStatus[doorRef] = true;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;
        if (isLocked == true && Pcon.KeyRing[doorKey] == true)
        {
            if (collisionGameObject.name == "Player" && Input.GetButtonDown("Interact"))
            {
                DoorOpen();
            }
        }
    }
}
