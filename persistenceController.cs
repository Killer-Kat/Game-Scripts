using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class persistenceController : MonoBehaviour
{
    //Using this array we store a bool for every chest, the chest can use its unique number that corisponds to its position in the array to check if it has been opened without the need
    //for the chest to persist, only the script.
    public bool[] chestStatus;
    public int totalChests;
    //Keys
    //I spent a long time thinking about if I wanted to use an array of bools or if I should just use a bunch of named bools and I couldnt figure it out.
    public bool[] doorStatus; //False door is closed, true door is open.
    public int totalDoors;
    public bool[] KeyRing;
    //Key 0 is the door to the cave shop
    void Start()
    {
        chestStatus = new bool[totalChests];
        for (int i = 0; i < chestStatus.Length; i++)
        {
            chestStatus[i] = false;
        }
        doorStatus = new bool[totalDoors];
        for (int i = 0; i < doorStatus.Length; i++)
        {
            doorStatus[i] = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
