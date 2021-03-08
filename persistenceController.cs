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

    
    // Start is called before the first frame update
    void Start()
    {
        chestStatus = new bool[totalChests];
        for (int i = 0; i < chestStatus.Length; i++)
        {
            chestStatus[i] = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
