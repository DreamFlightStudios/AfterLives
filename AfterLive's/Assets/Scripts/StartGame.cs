using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private LevelComplete _levelComplete;
    void Start()
    {
        Invoke("Next", _audioSource.clip.length);
    }
    private void Next()
        {
        _levelComplete.startEnd();
        }
}
