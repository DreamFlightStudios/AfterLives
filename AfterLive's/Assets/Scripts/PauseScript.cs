using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

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
        _audio.clip = _OnClick;
        _audio.Play();
        _settings.SetActive(false);
        _pausePanal.SetActive(!_pausePanal.active);
        
        if (_pausePanal.active)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else Cursor.lockState = CursorLockMode.Locked;
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
 
    private void exit() => SceneLoader.Instance.LoadScene(SceneManager.GetActiveScene().name);

    private void menu() => SceneLoader.Instance.LoadScene("-1");
}
