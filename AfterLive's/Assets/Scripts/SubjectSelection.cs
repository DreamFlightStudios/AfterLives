using UnityEngine;
using UnityEngine.InputSystem;

public class SubjectSelection : MonoBehaviour
{
    [SerializeField] private LevelComplete _levelComplete;
    [SerializeField] private Transform _pickUpPoint;
    [SerializeField] private float _distance;
    [SerializeField] private AudioSource _doorOpen;

    private Camera _camera;
    private InputSystem _input;
    private GameObject _pickUpObject;
    private Rigidbody _pickUpRigidbody;
    private bool _isPickUp;

    private void Awake()
    {
        _input = new InputSystem();
        _input.Player.Shoot.Enable();
        
        _camera = Camera.main;
    }

    private void OnEnable() => _input.Player.Shoot.performed += Shoot;
    private void OnDisable() => _input.Player.Shoot.performed -= Shoot;

    private void Shoot(InputAction.CallbackContext _)
    {
        if (_isPickUp)
        {
            _pickUpObject.transform.parent = null;
            _pickUpRigidbody.isKinematic = false;
            Collider Collider = _pickUpObject.GetComponent<Collider>();
            Collider.isTrigger = false;
            _isPickUp = false;
        }
        else if (!_isPickUp) CheckGround();
    }

    private void CheckGround()
    {
        RaycastHit hit;
        Ray ray = _camera.ScreenPointToRay(_input.Ui.MousePosition.ReadValue<Vector2>());

        if (Physics.Raycast(ray, out hit, _distance))
        {
            if (hit.collider.CompareTag("Object"))
            {
                _pickUpObject = hit.collider.gameObject;
                _pickUpRigidbody = _pickUpObject.GetComponent<Rigidbody>();
                _pickUpRigidbody.isKinematic = true;
                Collider Collider = _pickUpObject.GetComponent<Collider>();
                 Collider.isTrigger = true;
                _pickUpObject.transform.rotation = Quaternion.identity;
                _pickUpObject.transform.position = _pickUpPoint.position;
                _pickUpObject.transform.parent = _pickUpPoint;
                _isPickUp = true;
            }
            else if (hit.collider.CompareTag("Train"))
            {
                _pickUpObject = hit.collider.gameObject;
                Animator _pickUpAnimator = _pickUpObject.GetComponent<Animator>();
                _pickUpAnimator.SetTrigger("Move");
            }
            else if (hit.collider.CompareTag("Door"))
            {
                _pickUpObject = hit.collider.gameObject;
                Animator _pickUpAnimator = _pickUpObject.GetComponent<Animator>();
                _pickUpAnimator.SetTrigger("Move");
                _doorOpen.Play();
                _levelComplete.LevelComleted();
            }
        }
    }
}
