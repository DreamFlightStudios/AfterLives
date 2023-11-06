using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioSource _sourse;
    [SerializeField] private AudioClip _click;
    [SerializeField] private AudioClip _exit;
    public void Continue()
    {
        if (PlayerPrefs.GetInt("NextScene") < 2)
        {
            PlayerPrefs.SetInt("NextScene", 3);
        }
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
        PlayerPrefs.DeleteKey("NextScene");
        int nextScene = 2;
        PlayerPrefs.SetInt("NextScene", nextScene);
        _animator.SetTrigger("StartGame");
        Invoke("LoadScene", 5);
    }
    public void LoadScene()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("NextScene"));
    }
    public void exit()
    {
        Application.Quit();
        Debug.Log("выход");
    }
}
