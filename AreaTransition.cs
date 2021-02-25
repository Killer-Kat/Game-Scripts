using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaTransition : MonoBehaviour
{
    public int levelToLoad;
    public string currentBGM;
    public string nextBGM;
    private AudioManager audioMan;
    
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
        audioMan.StopPlaying(currentBGM);
        audioMan.Play(nextBGM);
        SceneManager.LoadScene(levelToLoad);
    }
}
