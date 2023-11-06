using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubjectSelection : MonoBehaviour
{
    [SerializeField] private LevelComplete _levelComplete;
    [SerializeField] private Transform _pickUpPoint;
    [SerializeField] private float _distance;
    private GameObject _pickUpObject;
    private Rigidbody _pickUpRigidbody;
    private bool _isPickUp = false;

    [SerializeField] private AudioSource _doorOpen;
    void Update()
    { 
        if (Input.GetButtonDown("Fire1") && _isPickUp == false)
        {
            CheckGround();
        }   
        else if (Input.GetButtonDown("Fire1") && _isPickUp == true)
        {
           _pickUpObject.transform.parent = null;
           _pickUpRigidbody.isKinematic = false;
           Collider Collider = _pickUpObject.GetComponent<Collider>();
           Collider.isTrigger = false;
            _isPickUp = false;
        }
    }
    private void CheckGround()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

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
            else if (hit.collider.CompareTag("Object"))
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
