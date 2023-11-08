using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private Image _progressBar, _loadingScreen;
    public static SceneLoader Instance { get; private set; }
    
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        
        LoadScene("-1");
    }
    
    public async void LoadScene(string scene)
    {
        PlayerPrefs.SetString("LastLevel", scene);
        _loadingScreen.gameObject.SetActive(true);
        
        AsyncOperationHandle<SceneInstance> sceneInstance = Addressables.LoadSceneAsync(scene);
        
        while (!sceneInstance.IsDone)
        {
            _progressBar.fillAmount = sceneInstance.PercentComplete;
            await Task.Yield();
        }

        _loadingScreen.gameObject.SetActive(false);
    }
}