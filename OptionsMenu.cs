using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    public string CurrentGameVersion;
    public Text VersionText;
    private void Start()
    {
        VersionText.text = CurrentGameVersion;
    }
    public void SetVolume(float volume)
    {

    }
}
