using UnityEngine;

public class TrainCollision : MonoBehaviour
{
    [SerializeField] private LevelComplete LevelComplete;
    [SerializeField] private Rigidbody[] _duckRigidbody;
    private bool _completed;
    private void OnCollisionEnter(Collision collision)
    {
        if (_completed == false)
        {
            if (collision.gameObject.CompareTag("BlacDuck"))
            {
                _completed = true;
                collision.rigidbody.isKinematic = false;
                LevelComplete.LevelComleted();
            }
            else if (collision.gameObject.CompareTag("WhiteDuck"))
            {
                _completed = true;
                collision.rigidbody.isKinematic = false;
                for(int i = 0; i < _duckRigidbody.Length; i++)
                {
                    _duckRigidbody[i].isKinematic = false;
                    _duckRigidbody[i].AddForce(new Vector3(1, 0, 0), ForceMode.Impulse);
                }
                LevelComplete.CriticalError();
            }
        }
    }
}
