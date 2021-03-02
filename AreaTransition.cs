﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaTransition : MonoBehaviour
{
    public int levelToLoad;
    public int NextAreaTransitionIndex; // Stores a value used to check which exit this transition leads to in the next level.
    public bool isNextLevelLit;
    public string currentBGM;
    public string nextBGM;
    private AudioManager audioMan;
    PlayerController playerMan;
    
    // Update is called once per frame
    void Start()
    {
        audioMan = FindObjectOfType<AudioManager>();
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;

        if(collisionGameObject.name == "Player")
        {
            LoadScene();
        }
    }
    void LoadScene()
    {
        playerMan = FindObjectOfType<PlayerController>();
        playerMan.areaTransitionIndex = NextAreaTransitionIndex;
        playerMan.nextLevelLit = isNextLevelLit;
        FindObjectOfType<PlayerStats>().currentScene = levelToLoad;
        audioMan.StopPlaying(currentBGM);
        audioMan.Play(nextBGM);
        SceneManager.LoadScene(levelToLoad);
    }
}
