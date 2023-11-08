using UnityEngine;

public class MenuButtons : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioSource _sourse;
    [SerializeField] private AudioClip _click;
    [SerializeField] private AudioClip _exit;
    
    public void Continue()
    {
        if (PlayerPrefs.GetString("LastLevel") == "-1") PlayerPrefs.SetString("LastLevel", "0");
        
        _animator.SetTrigger("StartGame");
        Invoke("LoadScene", 5);
    }
    public void Exit()
    {
        _sourse.clip = _exit;
        _sourse.Play();
        Invoke("exit", 3);
    }
    public void Settings()
    {
        _sourse.clip = _click;
        _sourse.Play();
        Application.OpenURL("https://discord.gg/KYDEVvzu22");
    }
    public void NewGame()
    {
        _sourse.clip = _click;
        _sourse.Play();
        PlayerPrefs.SetString("LastLevel", "0");
        _animator.SetTrigger("StartGame");
        Invoke("LoadScene", 5);
    }
    public void LoadScene() => SceneLoader.Instance.LoadScene(PlayerPrefs.GetString("LastLevel"));

    public void exit() => Application.Quit();
}