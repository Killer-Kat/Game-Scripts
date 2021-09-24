using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
//Props to matt from gamedev guide and then video for the framework and the idea https://www.youtube.com/watch?v=VzOEM-4A2OM
public class DebugController : MonoBehaviour
{
    bool showConsole;

    string input;

    public void OnToggleDebug(InputValue value)
    {
        showConsole = !showConsole;
        Debug.Log("debug key");
    }
    private void OnGUI()
    {
        if (!showConsole) { return; }

        float y = 0f; // we all float down here

        GUI.Box(new Rect(0, y, Screen.width, 30), "");
        GUI.backgroundColor = new Color(0, 0, 0, 0);
        input = GUI.TextField(new Rect(10f, y + 5f, Screen.width - 20f, 20f), input);
    }
}
