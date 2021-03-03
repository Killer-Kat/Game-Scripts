using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.SceneManagement;

public class GameStartScript : MonoBehaviour
{
    public int levelToLoad;
    AudioManager audioMan;
    Light2D lt;
    // Interpolate light color between two colors back and forth
    float duration = 2.0f;
   
    // Start is called before the first frame update
    void Start()
    {
        audioMan = FindObjectOfType<AudioManager>();
        audioMan.Play("BackGround Music LV0");
        lt = GetComponent<Light2D>();
        lt.intensity = 1;
    }
    public void StartGame()
    {
       
    }
    // Update is called once per frame
    void Update()
    {
        // set light color
        float t = Mathf.PingPong(Time.time, duration) / duration;
        lt.intensity = t;
    }
}
