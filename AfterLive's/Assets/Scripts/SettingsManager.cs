using Player;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [Header("Canvas")]
    [SerializeField] private GameObject _menu;
    [SerializeField] private GameObject _settings;
    [Header("Settings")]
    [SerializeField] private Slider _volume;
    [SerializeField] private Slider _sensitivity;
    [SerializeField] private Toggle _hintsActive;
    [SerializeField] private Toggle _subtitlesActive;
    [Header("Buttons")]
    [SerializeField] private Button _saveButton;
    [SerializeField] private Button _settingsButton;
    [SerializeField] private Button _backButton;
    [Header("Other")]
    [SerializeField] private AudioSource _onClickAudio;
    [SerializeField] private AudioClip _onClickAudioClip;

    private GameObject _subtitles;
    private AudioSource[] _audioSource;

    private void OnEnable()
    {
        _saveButton.onClick.AddListener(Save);
        _settingsButton.onClick.AddListener(Settings);
        _backButton.onClick.AddListener(Back);
    }
    private void OnDisable()
    {
        _saveButton.onClick.RemoveAllListeners();
        _settingsButton.onClick.RemoveAllListeners();
        _backButton.onClick.RemoveAllListeners();
    }
    private void Start()
    {
        _hintsActive.isOn = PlayerPrefs.HasKey("HintsActive");

        _subtitles = GameObject.FindGameObjectWithTag("Subtitles");
        _subtitlesActive.isOn = PlayerPrefs.HasKey("SubtitlesActive");                                                                                         
        _subtitles.SetActive(PlayerPrefs.HasKey("SubtitlesActive"));


        _sensitivity.value = PlayerPrefs.GetFloat("Sensitivity");
        PlayerMovement player = FindObjectOfType<PlayerMovement>();
        if (player != null) player.SetRotateSpeed(PlayerPrefs.GetFloat("Sensitivity"));
        
        _volume.value = PlayerPrefs.GetFloat("VolumeFloat");
        _audioSource = FindObjectsOfType<AudioSource>();
        foreach (AudioSource audioSource in _audioSource) audioSource.volume = PlayerPrefs.GetFloat("VolumeFloat");
    }

    private void Save()
    {
        _onClickAudio.clip = _onClickAudioClip;
        _onClickAudio.Play();
        
        if (_hintsActive.isOn) PlayerPrefs.SetInt("HintsActive", 1);
        else PlayerPrefs.DeleteKey("HintsActive");
        
        if(_subtitlesActive.isOn) PlayerPrefs.SetInt("SubtitlesActive", 1);
        else PlayerPrefs.DeleteKey("SubtitlesActive");
        

        PlayerPrefs.SetFloat("VolumeFloat", _volume.value);
        PlayerPrefs.SetFloat("Sensitivity", _sensitivity.value);

        PlayerMovement player = FindObjectOfType<PlayerMovement>();
        if (player != null) player.SetRotateSpeed(_sensitivity.value);

        _audioSource = FindObjectsOfType<AudioSource>();
        foreach (AudioSource audioSource in _audioSource) audioSource.volume = PlayerPrefs.GetFloat("VolumeFloat");
        _hintsActive.isOn = PlayerPrefs.HasKey("HintsActive");
        _subtitles.SetActive(PlayerPrefs.HasKey("SubtitlesActive"));
    }
    public void Settings()
    {
        _onClickAudio.clip = _onClickAudioClip;
        _onClickAudio.Play();
        _menu.SetActive(false);
        _settings.SetActive(true);
    }
    private void Back()
    {
        _onClickAudio.clip = _onClickAudioClip;
        _onClickAudio.Play();
        _menu.SetActive(true);
        _settings.SetActive(false);
    } 
}
