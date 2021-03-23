using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WorldData
{
    //Player House Data
    public bool isMainRoomUnlocked, isCraftingRoomUnlocked, isKitchenUnlocked, isBackRoomUnlocked;
    //Chests Data
    public bool[] chestStatus;
    //Locked Doors and Keys
    public bool[] doorStatus;
    public bool[] KeyRing;

    public WorldData(persistenceController Pcon)
    {
        isMainRoomUnlocked = Pcon.isMainRoomUnlocked;
        isCraftingRoomUnlocked = Pcon.isCraftingRoomUnlocked;
        isKitchenUnlocked = Pcon.isKitchenUnlocked;
        isBackRoomUnlocked = Pcon.isBackRoomUnlocked;

        chestStatus = Pcon.chestStatus;
        doorStatus = Pcon.doorStatus;
        KeyRing = Pcon.KeyRing;
    }
}