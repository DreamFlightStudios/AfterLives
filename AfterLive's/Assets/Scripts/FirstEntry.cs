using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstEntry : MonoBehaviour
{
    void Start()
    {
        if (PlayerPrefs.HasKey("FirstEntry") == false)
        {
            PlayerPrefs.SetInt("HintsActive", 1);
            PlayerPrefs.SetInt("SubtitlesActive", 1);
            PlayerPrefs.SetFloat("Sensitivity", 2f);
            PlayerPrefs.SetFloat("VolumeFloat", 0.8f);
            PlayerPrefs.SetInt("FirstEntry", 1);
        }
    }
}
