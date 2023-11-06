using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanal;
    [SerializeField] private GameObject _settings;
    [SerializeField] private GameObject _puseMenu;
    [SerializeField] private AudioSource _audio;
    [SerializeField] private AudioClip _OnClick;
    [SerializeField] private AudioClip _Restart;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _puseMenu.SetActive(true);
            _audio.clip = _OnClick;
            _audio.Play();
            _settings.SetActive(false);
            _pausePanal.SetActive(!_pausePanal.active);
            if (_pausePanal.active == true)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {   
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
    public void Menu()
    {
        _audio.clip = _OnClick;
        _audio.Play();
        Time.timeScale = 1f;
        Invoke("menu", 1);
    }
    public void Continue()
    {
        _audio.clip = _OnClick;
        _audio.Play();
        _pausePanal.SetActive(false);
        Time.timeScale = 1f;
        Cursor.visible = !Cursor.visible;
    }
    public void Restart()
    {
        _audio.clip = _OnClick;
        _audio.Play();
        Invoke("exit", 1);
        Time.timeScale = 1f;
    }
 
    private void exit() {SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); }
    private void menu() { SceneManager.LoadScene(0);}
}
