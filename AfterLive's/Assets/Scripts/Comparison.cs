using UnityEngine;

public class Comparison : MonoBehaviour
{
    [SerializeField] private GameObject _cube;
    [SerializeField] private LevelComplete LevelComplete;
    private bool _completed = false;
    private bool _error = false;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Object"))
        {
            if (collision.gameObject == _cube )
            {
                if (_completed) return;
                Debug.Log("верно");
                LevelComplete.LevelComleted();
                _completed = true;
            }
            else
            {
                if (_error) return;
                LevelComplete.Error();
                Debug.Log("неверно");
                _error = true;
                Invoke("Error", 1f);
            }
        }
    }
    private void Error()
    {
        _error = false;
    }
}
