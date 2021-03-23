using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadFromSave : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void OnLevelWasLoaded(int level)
    {
        Invoke("LoadGame", 4f);
        transform.parent = GameObject.Find("Main GUI").transform;
        transform.rotation = GetComponentInParent<Transform>().rotation;
        transform.position = GetComponentInParent<Transform>().position;
        
    }
    public void LoadGame()
    {
        
        FindObjectOfType<PlayerStats>().LoadPlayer();
        FindObjectOfType<persistenceController>().LoadWorld();
        SceneManager.LoadScene(FindObjectOfType<PlayerStats>().currentScene);
        FindObjectOfType<UIManager>().UpdateAll();
        Destroy(gameObject);
    }
}
