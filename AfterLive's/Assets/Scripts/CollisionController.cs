using UnityEngine;

public class CollisionController : MonoBehaviour
{
    [SerializeField] private LevelComplete _levelComplete;
    private bool _isWarning;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (_isWarning == false && collision.gameObject.CompareTag("Fence"))
        {
            _isWarning = true;
            _levelComplete.Warning();
        }
    }
}