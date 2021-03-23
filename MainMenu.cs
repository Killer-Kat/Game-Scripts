using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject loadingScreen;
   public void PlayGame ()
        
    {
        SceneManager.LoadScene("Level 0 Game Start");
    }
    public void LoadGame()
    {
        Instantiate(loadingScreen, transform.position, transform.rotation);
        SceneManager.LoadScene("Level 0 Game Start");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    
}
