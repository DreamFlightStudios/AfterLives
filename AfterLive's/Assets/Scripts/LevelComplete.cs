using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    [Header("Subtitles")]
    [SerializeField] private TMP_Text _subtitles;
    [Header("Text")]
    [SerializeField] private string _introductoryWords;
    [SerializeField] private string _finalWords;
    [SerializeField] private string _errorWords;
    [SerializeField] private string _criticalErrorWords;
    [SerializeField] private string _warningWords;
    [SerializeField] private string _hintWords = null;
    [Header("Other")]
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioSource _announcer;
    [SerializeField] private AudioClip _warningClip;
    [SerializeField] private AudioClip _completeClip;
    [SerializeField] private AudioClip _ErrorClip;
    [SerializeField] private AudioClip _CriticalErrorClip;
    [SerializeField] private AudioClip _hintClip;
    [SerializeField] private int _timeDelay = 1;
    [Header("Prefabs")]
    [SerializeField] private GameObject[] _confetti;
    [SerializeField] private ParticleSystem[] _confettiParticleSystem;
    [SerializeField] private AudioSource[] _confettiAudioSource;
    bool _completed = false;

    private void Start()
    {
        _subtitles.text += $"Пустота: {_introductoryWords}";
        TestCicle(_introductoryWords);
        Invoke("Hint", 90);
    }
    private void Hint()
    {
        if (_completed == false  && PlayerPrefs.HasKey("HintsActive") == false || _hintWords == "") return;
        _subtitles.text += $"Пустота: {_hintWords}";
        TestCicle(_hintWords);
        _announcer.clip = _hintClip;
        _announcer.Play();
    }
    public void LevelComleted()
    {
        if (_completed == true) return;
        _announcer.clip = _completeClip;
        _announcer.Play();
        _subtitles.text = $"Пустота: {_finalWords}";
        TestCicle(_finalWords);
        _animator.SetTrigger("LevelComplete");
        for (int i = 0; i < _confettiParticleSystem.Length; i++)
        {
            _confettiParticleSystem[i].Play();
        }
        for (int i = 0; i < _confettiAudioSource.Length; i++)
        {
            _confettiAudioSource[i].Play();
        }
    }
    public void Warning()
    {
        _announcer.clip =_warningClip;
        _announcer.Play();
        _subtitles.text += $"Пустота: {_warningWords}";
        Invoke("ClearText", _announcer.clip.length + _timeDelay);
    }
    public void CriticalError()
    {
        _announcer.clip = _CriticalErrorClip;
        _announcer.Play();
        _subtitles.text = $"Пустота: {_criticalErrorWords}";
        TestCicle(_criticalErrorWords);
        Invoke("Continue", _announcer.clip.length + _timeDelay);
        _animator.SetTrigger("StartGame");
    }
    public void startEnd()
    {
        _animator.SetTrigger("LevelComplete");
        Invoke("LoadNextScene", 8);
    }
    public void Error()
    {
        _announcer.clip = _ErrorClip;
        _announcer.Play();
        _subtitles.text = $"Пустота: {_errorWords}";
        TestCicle(_errorWords);
    }
    private void TestCicle(string currentText)
    {
        Invoke("ClearText", _announcer.clip.length + _timeDelay);
    }
    private void ClearText()
    {
       _subtitles.text = "";
    }
    public void BackMenu()
    {
        _animator.SetTrigger("LevelComplete");
        Invoke("LSMenu", 6);
    }
    private void LSMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadNextScene()
    {
        if (PlayerPrefs.GetInt("NextScene") == 8)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            int nextScene = PlayerPrefs.GetInt("NextScene") + 1;
            PlayerPrefs.SetInt("NextScene", nextScene);
            SceneManager.LoadScene(PlayerPrefs.GetInt("NextScene"));
        }
    }
    private void Continue()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
