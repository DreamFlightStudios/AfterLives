using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneAsync : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    private void Start()
    {
        StartCoroutine(LoadAsync());
    }
    IEnumerator LoadAsync()
    {
        Debug.Log("успех");
        AsyncOperation loadAsync = SceneManager.LoadSceneAsync(1);
        loadAsync.allowSceneActivation = false;
        while (!loadAsync.isDone)
        {
            _slider.value = loadAsync.progress;
            if (loadAsync.progress >= 0.9f && !loadAsync.allowSceneActivation)
            {
                yield return new WaitForSeconds(1.2f);
                loadAsync.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
