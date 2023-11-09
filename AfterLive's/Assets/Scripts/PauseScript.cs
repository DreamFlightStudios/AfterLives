using UnityEngine;
using UnityEngine.InputSystem;

public class PauseScript : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanal;
    [SerializeField] private GameObject _settings;
    [SerializeField] private GameObject _puseMenu;
    [SerializeField] private AudioSource _audio;
    [SerializeField] private AudioClip _OnClick;
    [SerializeField] private AudioClip _Restart;
    private InputSystem _input;

    private void Awake()
    {
        _input = new InputSystem();
        _input.Ui.Esc.Enable();
    }

    private void OnEnable() => _input.Ui.Esc.performed += Pause;

    private void OnDisable() => _input.Ui.Esc.performed -= Pause;

    private void Pause(InputAction.CallbackContext _)
    {
        _puseMenu.SetActive(true);
        _settings.SetActive(false);
        Continue();
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
        _pausePanal.SetActive(!_pausePanal.activeSelf);
        Time.timeScale = _pausePanal.activeSelf ? 0 : 1;
        
        if (_pausePanal.activeSelf)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else Cursor.lockState = CursorLockMode.Locked;
    }
    public void Restart()
    {
        _audio.clip = _OnClick;
        _audio.Play();
        Time.timeScale = 1f;
        Invoke("exit", 1);
    }
 
    private void exit() => SceneLoader.Instance.LoadScene(PlayerPrefs.GetString("LastLevel"));

    private void menu() => SceneLoader.Instance.LoadScene("-1");
}
