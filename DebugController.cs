using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
//Props to matt from gamedev guide and then video for the framework and the idea https://www.youtube.com/watch?v=VzOEM-4A2OM
public class NewBehaviourScript : MonoBehaviour
{
    bool showConsole;
    

    public void OnToggleDebug(InputValue value)
    {
        showConsole = !showConsole;
    }

    private void OnGUI()
    {
        if (!showConsole) { return; }

        float y; // we all float down here

        //GUI.Box(new Rect(0, y, Screen.width, 30), "");
    }
}
